using Microsoft.AspNetCore.Mvc;
using RestaurantsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantsController(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        // GET api/values
        [HttpGet("{name}")]
        public IActionResult Get([FromRoute] string name)
        {
            var restaurant = restaurantRepository.GetRestaurant(name);
            if (restaurant == null)
            {
                return NoContent();
            }
            return Ok(restaurant); 
        }
    }
}
