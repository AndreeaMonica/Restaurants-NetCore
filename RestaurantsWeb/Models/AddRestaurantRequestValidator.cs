using FluentValidation;
using RestaurantsWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Models
{
    public class AddRestaurantRequestValidator : AbstractValidator<AddRestaurantRequest>
    {
        public AddRestaurantRequestValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Adress).NotEmpty().Length(5, 100);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Country).NotEmpty().Length(5, 100); ;
        }
    }
}
