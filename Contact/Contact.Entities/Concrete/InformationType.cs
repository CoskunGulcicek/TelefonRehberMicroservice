using Contact.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities.Concrete
{
    public class InformationType : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ContactInformation> ContactInformations { get; set; }
    }
}
