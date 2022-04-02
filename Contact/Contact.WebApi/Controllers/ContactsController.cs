using AutoMapper;
using Contact.Business.Interfaces;
using Contact.Entities.Concrete;
using Contact.Entities.Dtos.Contact;
using Contact.WebApi.CustomFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ContactGetDto> allContacts = await _contactService.GetContactsListAsync();
            return Ok(allContacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var contact = await _contactService.GetContactByIdAsync(Id);
            return Ok(_mapper.Map<ContactGetDto>(contact));
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(ContactAddDto contactAddDto)
        {
            var entity = await _contactService.AddAsync(_mapper.Map<Contact.Entities.Concrete.Contact>(contactAddDto));
            return Created("", entity);
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(ContactUpdateDto contactUpdateDto)
        {
            var currentContact = await _contactService.GetByUUIdAsync(contactUpdateDto.UUID);
            if (currentContact == null)
            {
                return BadRequest();
            }
            await _contactService.UpdateAsync(_mapper.Map<Contact.Entities.Concrete.Contact>(contactUpdateDto));
            return Created("", contactUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _contactService.RemoveAsync(new Contact.Entities.Concrete.Contact() { UUID = Id });
            return NoContent();
        }
    }
}
