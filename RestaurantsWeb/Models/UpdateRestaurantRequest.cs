using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Models
{
    public class UpdateRestaurantRequest
    {
        public string Adress { get; set; }
        public string City { get; set; }
    }
}
