using Contact.Entities.Dtos.ContactInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Web.Models.Contact
{
    public class ContactGetDto
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Company { get; set; }
        public List<ContactInformationGetDto> ContactInformations { get; set; }

    }
}
