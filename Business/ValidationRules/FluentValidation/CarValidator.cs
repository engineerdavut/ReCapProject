using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).Length(4,40);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.CarDescription).NotEmpty();
            RuleFor(c => c.CarDescription).Length(4, 100);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).InclusiveBetween(10, 10000);

        }
    }
}
