using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SubscribeMailValidator:AbstractValidator<SubscribeMail>
    {
        public SubscribeMailValidator()
        {
            //Mail
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail kısmı boş geçilemez");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mail kısmı en fazla 50 karakter olabilir");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Mail kısmı en az 5 karakter olabilir");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail giriniz");

            
        }
    }
}
