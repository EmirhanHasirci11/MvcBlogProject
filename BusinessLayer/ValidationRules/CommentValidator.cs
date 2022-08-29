using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            //commentText
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Yorum içeriği boş geçilemez");
            RuleFor(x => x.CommentText).MinimumLength(2).WithMessage("Yorum içeriği en az 2 karakter olabilir");
            RuleFor(x => x.CommentText).MinimumLength(250).WithMessage("Yorum içeriği en fazla 250 karakter olabilir");
            //commentMail
            RuleFor(x => x.CommentMail).NotEmpty().WithMessage("Yorum maili boş geçilemez");
            RuleFor(x => x.CommentMail).MinimumLength(2).WithMessage("Yorum içeriği en az 2 karakter olabilir");
            RuleFor(x => x.CommentMail).MinimumLength(250).WithMessage("Yorum içeriği en fazla 250 karakter olabilir");

        }
    }
}
