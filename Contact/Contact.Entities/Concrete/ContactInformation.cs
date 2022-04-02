using Contact.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities.Concrete
{
    public class ContactInformation : ITable
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }

        public Guid ContactUUID { get; set; }
        public Contact Contact { get; set; }
    }
}
