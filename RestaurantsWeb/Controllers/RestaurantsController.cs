using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantsWeb.Entities;
using RestaurantsWeb.Models;

namespace RestaurantsWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository repository;
        private readonly IValidator<AddRestaurantRequest> validator;
        private readonly IValidator<UpdateRestaurantRequest> updateValidator;

        public RestaurantsController(IRestaurantRepository repository, 
            IValidator<AddRestaurantRequest> validator,
            IValidator<UpdateRestaurantRequest> updateValidator

            )
        {
            this.repository = repository;
            this.validator = validator;
            this.updateValidator = updateValidator;
        }

        public IActionResult GetAllRestaurants()
        {
            var restaurants = repository.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpPost]
        public IActionResult AddRestaurant([FromBody] AddRestaurantRequest restaurant)
        {
            validator.ValidateAndThrow(restaurant);
            var addRestaurant = repository.AddRestaurant(restaurant);
            return Ok(addRestaurant);
        }

        [HttpGet("{name}")]
        public IActionResult GetRestaurant([FromRoute] string name)
        {
            var getRestaurant = repository.GetRestaurant(name);
            if (getRestaurant == null)
            {
                throw new Exception("Restaurant not found");
            }
            return Ok(getRestaurant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant([FromBody] UpdateRestaurantRequest updateRestaurant, [FromRoute] long id)
        {
            updateValidator.ValidateAndThrow(updateRestaurant);
            var restaurant = repository.UpdateRestaurant(id, updateRestaurant);
            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant([FromRoute] long id)
        {
            var restaurant = repository.DeleteRestaurant(id);
            return Ok("restaurant deleted");
        }
    }
}