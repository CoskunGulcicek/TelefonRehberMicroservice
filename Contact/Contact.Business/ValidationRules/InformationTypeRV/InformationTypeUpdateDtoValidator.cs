using Contact.Entities.Dtos.InformationType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.ValidationRules.InformationTypeRV
{
    public class InformationTypeUpdateDtoValidator : AbstractValidator<InformationTypeUpdateDto>
    {
        public InformationTypeUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().InclusiveBetween(0, int.MaxValue).WithMessage("id boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("name alanı geçilemez");
        }
    }
}
