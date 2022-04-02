using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Interfaces
{
    public interface IContactService : IGenericService<Contact.Entities.Concrete.Contact>
    {
    }
}
