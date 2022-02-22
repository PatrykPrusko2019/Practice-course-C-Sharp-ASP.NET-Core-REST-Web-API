using AutoMapper;
using EntityFramework_RestaurantApi.Entities;
using EntityFramework_RestaurantApi.Exceptions;
using EntityFramework_RestaurantApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Services
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(int restaurantID, CreateDishDto dto)
        {
            var restaurant = GetRestaurantById(restaurantID);

            var dishEntity = _mapper.Map<Dish>(dto);

            dishEntity.RestaurantId = restaurantID;

            _context.Dishes.Add(dishEntity);
            _context.SaveChanges();

            return dishEntity.Id;
        }

        public DishDto GetById(int restaurantId, int dishId)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var dish = _context.Dishes.FirstOrDefault(d => d.Id == dishId);
            if (dish is null || dish.RestaurantId != restaurantId) throw new NotFoundException("Dish not found");

            var dishDto = _mapper.Map<DishDto>(dish);
            return dishDto;
        }

        public List<DishDto> GetAll(int restaurantId)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var dishDtos = _mapper.Map<List<DishDto>>(restaurant.Dishes);
                
            return dishDtos;
        }

        public int RemoveAll(int restaurantId)
        {
            var restaurant = GetRestaurantById(restaurantId);

            int countDishes = restaurant.Dishes.Count;

            _context.RemoveRange(restaurant.Dishes);
            _context.SaveChanges();
            return countDishes;
        }

        private Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = _context.Restaurants
                             .Include(r => r.Dishes)
                             .FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant is null) throw new NotFoundException("Restaurant not found");
            return restaurant;
        }

        public int Remove(int dishId)
        {
            var deleteDish = _context.Dishes.FirstOrDefault(d => d.Id == dishId);
            if (deleteDish is null) throw new NotFoundException("Dish not found");

            var restaurantId = deleteDish.RestaurantId; 
            _context.Remove(deleteDish);
            _context.SaveChanges();
            return restaurantId;
        }
    }
}
