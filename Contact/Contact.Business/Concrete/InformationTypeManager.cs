using Contact.Business.Interfaces;
using Contact.DataAccess.Interfaces;
using Contact.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Concrete
{
    public class InformationTypeManager : GenericManager<InformationType>, IInformationTypeService
    {
        private readonly IGenericDal<InformationType> _genericDal;
        private readonly IInformationTypeDal _informationTypeDal;
        public InformationTypeManager(IGenericDal<InformationType> genericDal, IInformationTypeDal informationTypeDal):base(genericDal)
        {
            _genericDal = genericDal;
            _informationTypeDal = informationTypeDal;
        }
    }
}
