using EntityFramework_RestaurantApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }
}
