using Contact.DataAccess.Interfaces;
using Contact.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfInformationTypeRepository : EfGenericRepository<InformationType>, IInformationTypeDal
    {
    }
}
