using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CoachValidator : AbstractValidator<Coach>
    {
        public CoachValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x=>x.Age).NotEmpty().WithMessage("Yaş alanı boş geçilemez");
            RuleFor(x => x.PhotoUrl).NotEmpty().WithMessage("Görsel seçiniz");
            RuleFor(x => x.Nationality).NotEmpty().WithMessage("Millet alanı boş geçilemez");
            RuleFor(x => x.Team).NotEmpty().WithMessage("Takım alanı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(45).WithMessage("İsim uzunluğu en fazla 45 karakter olabilir.");
        }
    }
}
