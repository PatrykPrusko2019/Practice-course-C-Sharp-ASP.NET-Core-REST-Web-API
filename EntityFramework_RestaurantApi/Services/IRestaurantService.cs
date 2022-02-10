using EntityFramework_RestaurantApi.Entities;
using EntityFramework_RestaurantApi.Models;
using System.Collections.Generic;

namespace EntityFramework_RestaurantApi.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateRestaurantDto updateRestaurant);
    }
}