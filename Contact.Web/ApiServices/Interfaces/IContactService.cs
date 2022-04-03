using Contact.Web.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Web.ApiServices.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactGetDto>> GetAllAsync();
        Task<ContactGetDto> GetByIdAsync(Guid uuid);
    }
}
