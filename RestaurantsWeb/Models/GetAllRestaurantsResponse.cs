using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Models
{
    public class GetAllRestaurantsResponse
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
    }
}
