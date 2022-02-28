
using EntityFramework_RestaurantApi.Entities;
using EntityFramework_RestaurantApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Services
{
    // responsible for creating new accounts and new users
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(RestaurantDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId
            };

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password); // get password hash

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
