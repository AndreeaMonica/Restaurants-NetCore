using System;
using System.Collections.Generic;

namespace RestaurantsWeb.Entities
{
    public partial class Cuisines
    {
        public Cuisines()
        {
            RestaurantsXCuisines = new HashSet<RestaurantsXCuisines>();
        }

        public long Id { get; set; }
        public string Type { get; set; }
        public long Price { get; set; }

        public virtual ICollection<RestaurantsXCuisines> RestaurantsXCuisines { get; set; }
    }
}
