using AutoMapper;
using Contact.Business.Concrete;
using Contact.Business.Concrete.Containers.Microsoftioc;
using Contact.Business.Interfaces;
using Contact.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Contact.DataAccess.Interfaces;
using Contact.WebApi.CustomFilters;
using Contact.WebApi.Mapping.AutoMapperProfile;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                builder => builder.WithOrigins($"{Configuration.GetConnectionString("UiServerConnectionString")}"));
            });


            services.AddControllers().AddFluentValidation();

            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IContactDal, EfContactRepository>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IContactInformationDal, EfContactInformationRepository>();
            services.AddScoped<IContactInformationService, ContactInformationManager>();

            //services.AddDependencies();
            services.AddScoped(typeof(ValidId<>));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder
                .WithOrigins(Configuration.GetConnectionString("UiServerConnectionString"), Configuration.GetConnectionString("UiServerConnectionString"))
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
