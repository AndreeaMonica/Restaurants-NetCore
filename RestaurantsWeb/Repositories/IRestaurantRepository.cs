using RestaurantsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Repositories
{
    public interface IRestaurantRepository
    {
        RestaurantDTO GetRestaurant(string name);
    }
}
