using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentDetailValidator:AbstractValidator<RentDetail>
    {

        public RentDetailValidator()
        {
            RuleFor(rd => rd.CustomerId).NotEmpty();
            RuleFor(rd => rd.CarId).NotEmpty();
            RuleFor(rd => rd.RentDate).NotEmpty();
            RuleFor(rd => rd.RentDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(rd => rd.ReturnDate).Empty();
            RuleFor(rd => rd.ReturnDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(rd => rd.RentDate).Must(BeAValidDate);



        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
