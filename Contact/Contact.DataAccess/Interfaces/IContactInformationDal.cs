using Contact.Entities.Concrete;
using Contact.Entities.Dtos.ContactInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess.Interfaces
{
    public interface IContactInformationDal : IGenericDal<ContactInformation>
    {
        Task<List<ContactInformationGetDto>> GetContactsByLocationAsync(string location);

    }
}
