using AutoMapper;
using Contact.Business.Interfaces;
using Contact.DataAccess.Concrete.EntityFrameworkCore;
using Contact.Entities.Dtos.Contact;
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
    public class ContactsApiControllerTestWithInMemory : ContactsApiControllerTest
    {
        public Mock<IContactService> _contactServiceMock = new Mock<IContactService>();
        public Mock<IContactInformationService> _contactInformationServiceMock = new Mock<IContactInformationService>();
        public Mock<IMapper> _mapperMock = new Mock<IMapper>();
        public ContactsApiControllerTestWithInMemory()
        {
            SetContextOptions(new DbContextOptionsBuilder<ContactContext>().UseInMemoryDatabase("ContactUnitTestInMemoryDb").Options);
        }

        [Fact]
        public async Task Add_ModelValidContact_ReturnCreatedWithEntity()
        {
            var contact = new ContactAddDto();
            using (var context = new ContactContext())
            {
            contact = new ContactAddDto {Name = "Adil",SurName = "Gök",Company = "Aed Cleaning",Content = "İçerik",Email ="Adil@gmail.com",Location="Adana",PhoneNumber="0532" };

                var _contactService = new Mock<IContactService>();
                var _contactInformationService = new Mock<IContactInformationService>();
                var _mapper = new Mock<IMapper>();



                var controller = new ContactsController(_contactServiceMock.Object,_contactInformationService.Object,_mapperMock.Object);
            var result = await controller.Add(contact);

            var redirect = Assert.IsType<CreatedResult>(result);
            }

           using ( var context = new ContactContext())
            {
                var contactEqual = context.Contacts.FirstOrDefault(x => x.Name == "Alev");

                Assert.Equal(contact.Name, contactEqual.Name);
            }
        }
    }
}
