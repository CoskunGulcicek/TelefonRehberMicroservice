﻿using Contact.Entities.Dtos.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Interfaces
{
    public interface IContactService : IGenericService<Contact.Entities.Concrete.Contact>
    {
        Task<List<ContactGetDto>> GetContactsListAsync();
        Task<ContactGetDto> GetContactByIdAsync(Guid uuid);
    }
}
