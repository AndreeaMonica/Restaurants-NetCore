using RestaurantsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Entities
{
    public interface IRestaurantRepository
    {
        long AddRestaurant(AddRestaurantRequest addRestaurant);
        GetRestaurantResponse GetRestaurant(string name);
        long UpdateRestaurant(long id,UpdateRestaurantRequest updateRestaurant);
        bool DeleteRestaurant(long id);
        IEnumerable<GetAllRestaurantsResponse> GetAllRestaurants();

    }
}
