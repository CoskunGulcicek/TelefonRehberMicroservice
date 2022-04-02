using Contact.Entities.Dtos.ContactInformation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.ValidationRules.ContactInformationRV
{
    public class ContactInformationUpdateDtoValidator : AbstractValidator<ContactInformationUpdateDto>
    {
        public ContactInformationUpdateDtoValidator()
        {
            RuleFor(x => x.ContactUUID).NotEmpty().WithMessage("Kullanıcı idsi boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("telefon numarası boş geçilemez");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Konum boş geçilemez");
        }
    }
}
