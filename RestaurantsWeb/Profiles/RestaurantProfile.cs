using AutoMapper;
using RestaurantsWeb.Entities;
using RestaurantsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Profiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            this.CreateMap<Restaurants, GetRestaurantResponse>()
                .ReverseMap();
            this.CreateMap<Restaurants, AddRestaurantRequest>()
                .ReverseMap();
            this.CreateMap<Restaurants, GetAllRestaurantsResponse>()
                .ReverseMap();

        }
    }
}
