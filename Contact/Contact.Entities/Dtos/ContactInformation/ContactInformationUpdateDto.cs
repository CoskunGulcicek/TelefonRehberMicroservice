
using Contact.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities.Dtos.ContactInformation
{
    public class ContactInformationUpdateDto : IDto
    {
        public int Id { get; set; }
        public int InformationTypeId { get; set; }
        public string Content { get; set; }

        public Guid ContactUUID { get; set; }
    }
}
