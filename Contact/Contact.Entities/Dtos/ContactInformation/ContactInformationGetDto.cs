using Contact.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities.Dtos.ContactInformation
{
    public class ContactInformationGetDto : IDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
        public int ContactCount { get; set; }
        public int ContactPhoneCount { get; set; }
        public Guid ContactUUID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
