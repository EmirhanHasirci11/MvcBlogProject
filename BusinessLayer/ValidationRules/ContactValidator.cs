using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            //name
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim kısmı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("İsim kısmı en az 1 karakter olabilir");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim kısmı en fazla 50 karakter olabilir");
            //surname
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyisim kısmı boş geçilemez");
            RuleFor(x => x.SurName).MinimumLength(1).WithMessage("Soyisim kısmı en az 1 karakter olabilir");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage("Soyisim kısmı en fazla 50 karakter olabilir");
            //mail
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail kısmı boş geçilemez");
            RuleFor(x => x.Mail).MinimumLength(1).WithMessage("Mail kısmı en az 1 karakter olabilir");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mail kısmı en fazla 50 karakter olabilir");
            //subject
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(1).WithMessage("Konu kısmı en az 1 karakter olabilir");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu kısmı en fazla 50 karakter olabilir");
            //message
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj kısmı boş geçilemez");
            RuleFor(x => x.Message).MinimumLength(1).WithMessage("Konu kısmı en az 1 karakter olabilir");
            RuleFor(x => x.Message).MaximumLength(250).WithMessage("Konu kısmı en fazla 250 karakter olabilir");
        }
    }
}
