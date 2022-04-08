using AutoMapper;
using Contact.Business.Concrete;
using Contact.Business.Interfaces;
using Contact.DataAccess.Concrete.EntityFrameworkCore;
using Contact.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Contact.DataAccess.Interfaces;
using Contact.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactUnitTest.WebApi
{
    public  class ContactsApiControllerTest
    {
        protected DbContextOptions<ContactContext> _contextOptions { get; private set; }
        public void SetContextOptions(DbContextOptions<ContactContext> contextOptions)
        {
            _contextOptions = contextOptions;
            Seed();
        }

        public void Seed()
        {

            using (ContactContext context = new ContactContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Contacts.Add(new Contact.Entities.Concrete.Contact() { Name = "Coşkun", SurName = "Gülçiçek", Company = "A Şirketi" });
                context.Contacts.Add(new Contact.Entities.Concrete.Contact() { Name = "Alev", SurName = "Şahin", Company = "Şahin Şirketi" });

                context.SaveChanges();
            }
        }
    }
}
