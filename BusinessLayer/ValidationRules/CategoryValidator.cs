﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Name alanı boş bırakılamaz !");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Description alanı boş bırakılamaz !");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter giriniz !");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("En fazla 3 karakter giriniz !");
        }
    }
}
