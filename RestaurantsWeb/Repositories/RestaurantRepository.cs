using RestaurantsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {

        private readonly List<RestaurantDTO> context;

        public RestaurantRepository()
        {
            context = new List<RestaurantDTO>(); // Response
            context.Add(new RestaurantDTO { Name = "Mara Mura", Location = "Aviatorilor" });
            context.Add(new RestaurantDTO { Name = "Ethel", Location = "Arcul de Triumf" });
            context.Add(new RestaurantDTO { Name = "French Revolution", Location = "Victoriei" });
            context.Add(new RestaurantDTO { Name = "Maison des Crepes", Location = "Aviatorilor" });
        }

        public RestaurantDTO GetRestaurant(string name)
        {
            var restaurant = context.FirstOrDefault(x => x.Name == name);
            return restaurant;
        }
    }
}
