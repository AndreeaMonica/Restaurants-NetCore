using System;
using System.Collections.Generic;

namespace RestaurantsWeb.Entities
{
    public partial class RestaurantsXCuisines
    {
        public string Id { get; set; }
        public long RestaurantId { get; set; }
        public long CuisineId { get; set; }

        public virtual Cuisines Cuisine { get; set; }
        public virtual Restaurants Restaurant { get; set; }
    }
}
