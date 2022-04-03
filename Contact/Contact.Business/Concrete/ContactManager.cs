using Contact.Business.Interfaces;
using Contact.DataAccess.Interfaces;
using Contact.Entities.Dtos.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Concrete
{
    public class ContactManager : GenericManager<Contact.Entities.Concrete.Contact>, IContactService
    {
        private readonly IGenericDal<Contact.Entities.Concrete.Contact> _genericDal;
        private readonly IContactDal _contactDal;

        public ContactManager(IGenericDal<Contact.Entities.Concrete.Contact> genericDal, IContactDal contactDal):base(genericDal)
        {
            _contactDal = contactDal;
            _genericDal = genericDal;
        }

        public async Task<ContactGetDto> GetContactByIdAsync(Guid uuid)
        {
            return await _contactDal.GetContactByIdAsync(uuid);
        }

        public async Task<List<ContactGetDto>> GetContactsListAsync()
        {
            return await _contactDal.GetContactsListAsync();
        }
    }
}
