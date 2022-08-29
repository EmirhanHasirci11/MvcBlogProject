using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutContent1).MaximumLength(500).WithMessage("Açıklama kısmı maximum 500 karakter olabilir");
            RuleFor(x => x.AboutContent1).MinimumLength(10).WithMessage("Açıklama kısmı minimum 10 karakter olabilir");
            RuleFor(x => x.AboutContent1).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");
            RuleFor(x => x.AboutContent2).MaximumLength(500).WithMessage("Açıklama kısmı maximum 500 karakter olabilir");
            RuleFor(x => x.AboutContent2).MinimumLength(10).WithMessage("Açıklama kısmı minimum 10 karakter olabilir");
            RuleFor(x => x.AboutContent2).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");
            RuleFor(x => x.AboutImage1).MaximumLength(100).WithMessage("Resim yolu maximum 100 karakter olabilir ");
            RuleFor(x => x.AboutImage2).MaximumLength(100).WithMessage("Resim yolu maximum 100 karakter olabilir");
        }
    }
}
