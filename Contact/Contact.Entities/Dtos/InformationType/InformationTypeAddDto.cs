﻿using Contact.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities.Dtos.InformationType
{
    public class InformationTypeAddDto : IDto
    {
        public string Name { get; set; }
    }
}