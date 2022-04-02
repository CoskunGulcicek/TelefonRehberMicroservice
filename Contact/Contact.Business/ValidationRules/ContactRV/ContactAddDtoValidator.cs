using Contact.Entities.Dtos.Contact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.ValidationRules.ContactRV
{
    public class ContactAddDtoValidator : AbstractValidator<ContactAddDto>
    {
        public ContactAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("soyİsim boş geçilemez");
            RuleFor(x => x.Company).NotEmpty().WithMessage("şirket boş geçilemez");
        }
    }
}
