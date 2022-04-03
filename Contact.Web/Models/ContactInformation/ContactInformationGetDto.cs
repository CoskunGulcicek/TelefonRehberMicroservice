using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Web.Models.ContactInformation
{
    public class ContactInformationGetDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
        public Guid ContactUUID { get; set; }
    }
}
