using AutoMapper;
using EntityFramework_RestaurantApi.Entities;
using EntityFramework_RestaurantApi.Exceptions;
using EntityFramework_RestaurantApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Services
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper mapper;

        public DishService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public int Create(int restaurantID, CreateDishDto dto)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == restaurantID);
            if (restaurant is null)
                throw new NotFoundException("Restaurant not found");

            var dishEntity = mapper.Map<Dish>(dto);

            dishEntity.RestaurantId = restaurantID;

            _context.Dishes.Add(dishEntity);
            _context.SaveChanges();

            return dishEntity.Id;
        }

    }
}
