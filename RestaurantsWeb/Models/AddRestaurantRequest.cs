using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Models
{
    public class AddRestaurantRequest
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
    }
}
