﻿using System;
using System.Collections.Generic;

namespace RestaurantsWeb.Entities
{
    public partial class Restaurants
    {
        public Restaurants()
        {
            RestaurantsXCuisines = new HashSet<RestaurantsXCuisines>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<RestaurantsXCuisines> RestaurantsXCuisines { get; set; }
    }
}
