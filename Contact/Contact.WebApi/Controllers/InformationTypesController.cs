﻿using AutoMapper;
using Contact.Business.Interfaces;
using Contact.Entities.Concrete;
using Contact.Entities.Dtos.InformationType;
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
    public class InformationTypesController : ControllerBase
    {
        private readonly IInformationTypeService _informationTypeService;
        private readonly IMapper _mapper;
        public InformationTypesController(IInformationTypeService informationTypeService, IMapper mapper)
        {
            _informationTypeService = informationTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allInformationTypes = await _informationTypeService.GetAllAsync();
            return Ok(allInformationTypes);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<InformationType>))]
        public async Task<IActionResult> GetById(int Id)
        {
            var informationType = await _informationTypeService.GetByIdAsync(Id);
            return Ok(informationType);
        }

        [ValidModel]
        public async Task<IActionResult> Add(InformationTypeAddDto contactInformationAddDto)
        {
            await _informationTypeService.AddAsync(_mapper.Map<InformationType>(contactInformationAddDto));
            return Created("", contactInformationAddDto);
        }

        [ValidModel]
        public async Task<IActionResult> Update(InformationTypeUpdateDto contactInformationUpdateDto)
        {
            var currentInformationType = await _informationTypeService.GetByIdAsync(contactInformationUpdateDto.Id);
            if (currentInformationType == null)
            {
                return BadRequest();
            }
            await _informationTypeService.UpdateAsync(_mapper.Map<InformationType>(contactInformationUpdateDto));
            return Created("", contactInformationUpdateDto);
        }

        [ServiceFilter(typeof(ValidId<InformationType>))]
        public async Task<IActionResult> Delete(int Id)
        {
            await _informationTypeService.RemoveAsync(new InformationType() { Id = Id });
            return NoContent();
        }

    }
}
