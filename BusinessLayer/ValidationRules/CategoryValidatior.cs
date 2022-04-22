using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidatior : AbstractValidator<Category>
    {
        public CategoryValidatior()
        {


            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori alanı boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklama boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori ismi en az 3 karakterden fazla olmalıdır ");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Kategori ismi en fazla 30 karakter olmalıdır ");
        }


    }
}
