using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        private readonly IEnumerable<Admin> _admins;

        public AdminValidator(IEnumerable<Admin> admins)
        {
            _admins = admins;
            //UserName
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Admin kullanıcı adı boş geçilemez");
            RuleFor(x => x.UserName).Must(IsNameUnique).WithMessage("Kullanıcı adı kullanılıyor lütfen başka bir kullanıcı adı giriniz");
            RuleFor(x => x.UserName).Length(5,20).WithMessage("Kullanıcı adı 5-20 karakterleri arasında olmalıdır");
            //Password
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.Password).Length(10,20).WithMessage("Şifre 10-20 Karakterleri arasında olmalıdır");
            //Role
            RuleFor(x => x.Role).NotEmpty().WithMessage("Rol boş geçilemez");
            RuleFor(x => x.Role).Length(1,20).WithMessage("Rol 1-20 Karakterleri arasında olmalıdır");
        }

        public bool IsNameUnique(Admin admin, string newValue)
        {
            return _admins.All(x =>
              x.Equals(admin.UserName) || x.UserName != newValue);
        }
    }
}
