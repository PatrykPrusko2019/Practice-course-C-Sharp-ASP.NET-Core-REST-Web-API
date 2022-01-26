using EntityFramework_RestaurantApi.Models;
using System.Collections.Generic;

namespace EntityFramework_RestaurantApi.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
        bool Delete(int id);
    }
}