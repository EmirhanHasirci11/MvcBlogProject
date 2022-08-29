using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            //Title
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.BlogTitle).Length(2,50).WithMessage("Blog başlığı boş geçilemez");
            //Content
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz");
            RuleFor(x => x.BlogContent).MinimumLength(1).WithMessage("Blog içeriği 1-500 karakterleri arasında olmalıdır");
            RuleFor(x => x.BlogContent).MaximumLength(500).WithMessage("Blog içeriği 1-500 karakterleri arasında olmalıdır");
            //Image
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog resmi boş geçilemez. En iyi görünüm için yatay bir resim göstermeye özen gösterin");
            RuleFor(x => x.BlogImage).MaximumLength(250).WithMessage("Resim yolu en fazla 250 karakter olabilir. En iyi görünüm için yatay bir resim göstermeye özen gösterin");
        }
    }
}
