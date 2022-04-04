using Contact.DataAccess.Interfaces;
using Contact.Entities.Concrete;
using Contact.Entities.Dtos.ContactInformation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfContactInformationRepository : EfGenericRepository<ContactInformation>, IContactInformationDal
    {
        public async Task<List<ContactInformationGetDto>> GetContactsByLocationAsync(string location)
        {
            using var context = new ContactContext();
            var result = await (Task<List<ContactInformationGetDto>>)
                context
                .ContactInformations
                .Where(x => x.Location == location)
                .Select(x => new ContactInformationGetDto()
                {
                    Location = x.Location,
                    Name = x.Contact.ContactInformations.Where(x => x.Location == location).Select(x=>x.Contact.Name).FirstOrDefault(),
                    SurName = x.Contact.ContactInformations.Where(x => x.Location == location).Select(x => x.Contact.SurName).FirstOrDefault(),
                }).ToListAsync();

            return result;
        }
    }
}
