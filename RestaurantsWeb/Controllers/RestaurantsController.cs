using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantsWeb.Entities;
using RestaurantsWeb.Models;
using RestaurantsWeb.Repositories;

namespace RestaurantsWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IValidator<AddRestaurantRequest> addRestaurantRequestValidator;
        private readonly IValidator<UpdateRestaurantRequest> addUpdateRequestValidator;

        public RestaurantsController(IRestaurantRepository restaurantRepository, 
            IValidator<AddRestaurantRequest> addRestaurantRequestValidator,
            IValidator<UpdateRestaurantRequest> addUpdateRequestValidator
            )
        {
            this.restaurantRepository = restaurantRepository;
            this.addRestaurantRequestValidator = addRestaurantRequestValidator;
            this.addUpdateRequestValidator = addUpdateRequestValidator;
        }

        public IActionResult GetAllRestaurants()
        {
            var restaurants = restaurantRepository.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpPost]
        public IActionResult AddRestaurant([FromBody] AddRestaurantRequest restaurant)
        {
            addRestaurantRequestValidator.ValidateAndThrow(restaurant);
            var addRestaurant = restaurantRepository.AddRestaurant(restaurant);
            return Ok(addRestaurant);
        }

        [HttpGet("{name}")]
        public IActionResult GetRestaurant([FromRoute] string name)
        {
            var restaurant = restaurantRepository.GetRestaurant(name);
            if (restaurant == null)
            {
                return NoContent();
            }
            return Ok(restaurant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant([FromRoute] long id, [FromBody] UpdateRestaurantRequest updateRestaurant)
        {
            addUpdateRequestValidator.ValidateAndThrow(updateRestaurant);
            var restaurant = restaurantRepository.UpdateRestaurant(id, updateRestaurant);
            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant([FromRoute] long id)
        {
            var restaurant = restaurantRepository.DeleteRestaurant(id);
            return Ok("restaurant deleted");
        }
    }
}