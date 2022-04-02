using Contact.Business.Interfaces;
using Contact.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Contact.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Concrete.Containers.Microsoftioc
{
    public static class CustomExtension
    {
       public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IContactDal, EfContactRepository>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IContactInformationDal, EfContactInformationRepository>();
            services.AddScoped<IContactInformationService, ContactInformationManager>();

            services.AddScoped<IInformationTypeDal, EfInformationTypeRepository>();
            services.AddScoped<IInformationTypeService, InformationTypeManager>();


        }

    }
}
