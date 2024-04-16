using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator() 
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Writer Name is required !");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Writer Surname is required !");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Writer Mail is required !");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Writer About is required !");
        }
    }
}
