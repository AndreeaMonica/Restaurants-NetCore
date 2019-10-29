using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Models
{
    public class UpdateRestaurantRequestValidator : AbstractValidator<UpdateRestaurantRequest>
    {
        public UpdateRestaurantRequestValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.City).NotEmpty().Length(5,100);
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adress must not be null. Please insert an adress");
        }
    }
}
