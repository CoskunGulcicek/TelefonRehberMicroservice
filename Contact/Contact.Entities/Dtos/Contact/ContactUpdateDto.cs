using Contact.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities.Dtos.Contact
{
    public class ContactUpdateDto : IDto
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Company { get; set; }

    }
}
