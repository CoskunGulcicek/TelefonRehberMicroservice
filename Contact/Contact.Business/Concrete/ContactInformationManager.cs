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
    public class ContactInformationManager : GenericManager<ContactInformation>,IContactInformationService
    {
        private readonly IGenericDal<ContactInformation> _genericDal;
        private readonly IContactInformationDal _contactInformationDal;
        public ContactInformationManager(IGenericDal<ContactInformation> genericDal, IContactInformationDal contactInformationDal):base(genericDal)
        {
            _genericDal = genericDal;
            _contactInformationDal = contactInformationDal;
        }
    }
}
