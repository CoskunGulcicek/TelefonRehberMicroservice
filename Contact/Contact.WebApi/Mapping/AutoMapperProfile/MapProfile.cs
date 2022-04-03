using AutoMapper;
using Contact.Entities.Concrete;
using Contact.Entities.Dtos.ContactInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Contact.Entities.Dtos.Contact.ContactAddDto, Contact.Entities.Concrete.Contact>();
            CreateMap<Contact.Entities.Concrete.Contact, Contact.Entities.Dtos.Contact.ContactAddDto>();

            CreateMap<Contact.Entities.Dtos.Contact.ContactGetDto, Contact.Entities.Concrete.Contact>();
            CreateMap<Contact.Entities.Concrete.Contact, Contact.Entities.Dtos.Contact.ContactGetDto>();

            CreateMap<Contact.Entities.Dtos.Contact.ContactUpdateDto, Contact.Entities.Concrete.Contact>();
            CreateMap<Contact.Entities.Concrete.Contact, Contact.Entities.Dtos.Contact.ContactUpdateDto>();

            CreateMap<ContactInformationAddDto, ContactInformation>();
            CreateMap<ContactInformation, ContactInformationAddDto>();

            CreateMap<ContactInformationGetDto, ContactInformation>();
            CreateMap<ContactInformation, ContactInformationGetDto>();

            CreateMap<ContactInformationUpdateDto, ContactInformation>();
            CreateMap<ContactInformation, ContactInformationUpdateDto>();



        }
    }
}
