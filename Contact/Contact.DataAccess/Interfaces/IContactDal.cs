using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess.Interfaces
{
    public interface IContactDal : IGenericDal<Contact.Entities.Concrete.Contact>
    {
    }
}
