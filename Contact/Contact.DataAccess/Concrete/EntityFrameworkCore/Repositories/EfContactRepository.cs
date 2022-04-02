using Contact.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfContactRepository : EfGenericRepository<Contact.Entities.Concrete.Contact>, IContactDal
    {
    }
}
