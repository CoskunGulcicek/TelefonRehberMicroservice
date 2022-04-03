using AutoMapper;
using Contact.DataAccess.Interfaces;
using Contact.Entities.Dtos.Contact;
using Contact.Entities.Dtos.ContactInformation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfContactRepository : EfGenericRepository<Contact.Entities.Concrete.Contact>, IContactDal
    {
        private readonly IMapper _mapper;
        public EfContactRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ContactGetDto> GetContactByIdAsync(Guid uuid)
        {
            using var context = new ContactContext();
            var returnData =  await (Task<ContactGetDto>)context.Contacts.Where(x => x.UUID == uuid).Include(x => x.ContactInformations).Select(x => new ContactGetDto()
            {
                UUID = x.UUID,
                Name = x.Name,
                SurName = x.SurName,
                Company = x.Company,
                ContactInformations = _mapper.Map<List<ContactInformationGetDto>>(x.ContactInformations.Where(ci=>ci.ContactUUID== x.UUID).ToList())
            }).FirstOrDefaultAsync();
            return returnData;
        }

        public async Task<List<ContactGetDto>> GetContactsListAsync()
        {
            using var context = new ContactContext();

            var returnData = await (Task<List<ContactGetDto>>)context.Contacts.Include(x => x.ContactInformations).Select(x => new ContactGetDto()
            {
                UUID = x.UUID,
                Name = x.Name,
                SurName = x.SurName,
                Company = x.Company,
                ContactInformations = _mapper.Map<List<ContactInformationGetDto>>(x.ContactInformations.Where(ci => ci.ContactUUID == x.UUID).ToList())
            }).ToListAsync();
            return returnData;

        }
    }
}
