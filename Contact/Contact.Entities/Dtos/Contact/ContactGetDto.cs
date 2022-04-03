using Contact.Entities.Dtos.ContactInformation;
using Contact.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities.Dtos.Contact
{
    public class ContactGetDto : IDto
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Company { get; set; }
        public List<ContactInformationGetDto> ContactInformations { get; set; }

    }
}
