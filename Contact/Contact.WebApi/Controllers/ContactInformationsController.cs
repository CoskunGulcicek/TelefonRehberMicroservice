using AutoMapper;
using Contact.Business.Interfaces;
using Contact.Entities.Concrete;
using Contact.Entities.Dtos.ContactInformation;
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
    public class ContactInformationsController : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;
        private readonly IMapper _mapper;
        public ContactInformationsController(IContactInformationService contactInformationService, IMapper mapper)
        {
            _contactInformationService = contactInformationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allContactInformations = await _contactInformationService.GetAllAsync();
            return Ok(_mapper.Map<List<ContactInformationGetDto>>(allContactInformations));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ContactInformationGetDto contactInformation = new();// await _contactInformationService.GetByIdAsync(Id);
            return Ok(_mapper.Map<ContactInformationGetDto>(contactInformation));
        }


        [Route("location")]
        public async Task<IActionResult> GetByLocation(string location)
        {
            List<ContactInformationGetDto> contactInformation = await _contactInformationService.GetContactsByLocationAsync(location);
            return Ok(contactInformation);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(ContactInformationAddDto contactInformationAddDto)
        {
            var entity = await _contactInformationService.AddAsync(_mapper.Map<ContactInformation>(contactInformationAddDto));
            return Created("", entity);
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(ContactInformationUpdateDto contactInformationUpdateDto)
        {
            var currentContactInformation = await _contactInformationService.GetByIdAsync(contactInformationUpdateDto.Id);
            if (currentContactInformation==null)
            {
                return BadRequest();
            }
            await _contactInformationService.UpdateAsync(_mapper.Map<ContactInformation>(contactInformationUpdateDto));
            return Created("",contactInformationUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _contactInformationService.RemoveAsync(new ContactInformation() { Id = Id });
            return NoContent();
        }
    }
}
