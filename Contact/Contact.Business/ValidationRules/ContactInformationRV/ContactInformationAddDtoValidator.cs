using Contact.Entities.Dtos.ContactInformation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.ValidationRules.ContactInformationRV
{
    public class ContactInformationAddDtoValidator : AbstractValidator<ContactInformationAddDto>
    {
        public ContactInformationAddDtoValidator()
        {
            RuleFor(x => x.InformationTypeId).NotEmpty().InclusiveBetween(0, int.MaxValue); ;
            RuleFor(x => x.ContactUUID).NotEmpty().WithMessage("Kullanıcı idsi boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("content alanı boş geçilemez");
        }
    }
}
