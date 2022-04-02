
using Contact.Entities.Dtos.InformationType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.ValidationRules.InformationTypeRV
{
    public class InformationTypeAddDtoValidator : AbstractValidator<InformationTypeAddDto>
    {
        public InformationTypeAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş geçilemez");
        }
    }
}
