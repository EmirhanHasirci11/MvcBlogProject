using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorUpdateValidator:AbstractValidator<Author>
    {
        public AuthorUpdateValidator()
        {
            //AuthorName
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("İsim kısmı boş geçilemez");
            RuleFor(x => x.AuthorName).MinimumLength(2).WithMessage("İsim kısmı minimum 2 karakter içermelidir");
            RuleFor(x => x.AuthorName).MaximumLength(20).WithMessage("İsim kısmı maximum 20 karakter olmalıdır");
            //AuthorSurname
            RuleFor(x => x.AuthorSurname).NotEmpty().WithMessage("Soyisim kısmı boş geçilemez");
            RuleFor(x => x.AuthorSurname).MinimumLength(2).WithMessage("Soyisim kısmı minimum 2 karakter içermelidir");
            RuleFor(x => x.AuthorSurname).MaximumLength(20).WithMessage("Soyisim kısmı maximum 20 karakter olmalıdır");
            //AuthorTitle
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Unvan kısmı boş geçilemez");
            RuleFor(x => x.AuthorTitle).MinimumLength(10).WithMessage("Unvan kısmı en az 10 karakter içermelidir");
            RuleFor(x => x.AuthorTitle).MaximumLength(25).WithMessage("Unvan kısmı en fazla 25 karakter içerebilir");
            //AuthorMail            
            RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.AuthorMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
            RuleFor(x => x.AuthorMail).MinimumLength(10).WithMessage("Mail en az 10 karakter olabilir ");
            RuleFor(x => x.AuthorMail).MaximumLength(30).WithMessage("Mail en fazla 30 karakter olabilir ");
            //AuthorPassword
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez");
            RuleFor(x => x.AuthorPassword).MinimumLength(10).WithMessage("Şifre en az 10 karakterden oluşmalıdır");
            RuleFor(x => x.AuthorPassword).MaximumLength(20).WithMessage("Şifre en fazla 20 karakterden oluşabilir");
            //AuthorImage
            RuleFor(x => x.AuthorImage).MaximumLength(100).WithMessage("Resim yolu maximum 100 karakter olmalıdır");
            //AuthorAbout
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");
            RuleFor(x => x.AuthorAbout).MinimumLength(5).WithMessage("Hakkında kısmı en az 5 karakterden oluşmalıdır");
            RuleFor(x => x.AuthorAbout).MaximumLength(500).WithMessage("Hakkında kısmı en fazla 500 karakter olabilir");
            //AuthorShortAbout
            RuleFor(x => x.AuthorAboutShort).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");
            RuleFor(x => x.AuthorAboutShort).MinimumLength(5).WithMessage("Hakkında kısmı en az 5 karakterden oluşmalıdır");
            RuleFor(x => x.AuthorAboutShort).MaximumLength(100).WithMessage("Hakkında kısmı en fazla 100 karakter olabilir");
        }
    }
}
