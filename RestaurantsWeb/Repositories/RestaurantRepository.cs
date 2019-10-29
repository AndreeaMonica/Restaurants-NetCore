using AutoMapper;
using RestaurantsWeb.Entities;
using RestaurantsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsWeb.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantContext context;
        private readonly IMapper mapper;

        public RestaurantRepository(RestaurantContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public long AddRestaurant(AddRestaurantRequest addRestaurant)
        {
            var restaurant = mapper.Map<Restaurants>(addRestaurant);
            context.Add(restaurant);
            context.SaveChanges();
            return restaurant.Id;
        }

        public bool DeleteRestaurant(long id)
        {
            var restaurant = context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant == null)
            {
                throw new Exception("No restaurant found");
            }
            context.Remove(restaurant);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<GetAllRestaurantsResponse> GetAllRestaurants()
        {
            var restaurants = context
                .Restaurants
                .ToList();
            var getRestaurants = mapper.Map<IEnumerable<GetAllRestaurantsResponse>>(restaurants);
            return getRestaurants;
        }

        public GetRestaurantResponse GetRestaurant(string name)
        {
            var restaurant = context.Restaurants.FirstOrDefault(x => x.Name == name);
            var restaurantResponse = mapper.Map<GetRestaurantResponse>(restaurant);
            return restaurantResponse;
        }

        public long UpdateRestaurant(long id, UpdateRestaurantRequest updateRestaurant)
        {
            var restaurant = context.Restaurants.FirstOrDefault(x => x.Id == id);
            restaurant.Adress = updateRestaurant.Adress;
            restaurant.City = updateRestaurant.City;
            context.Update(restaurant);
            context.SaveChanges();
            return restaurant.Id;
        }


    }
}
