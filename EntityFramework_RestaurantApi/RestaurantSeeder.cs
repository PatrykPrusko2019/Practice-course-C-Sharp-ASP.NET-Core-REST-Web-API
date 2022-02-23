using EntityFramework_RestaurantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles); // adds roles to the roles table
                    _dbContext.SaveChanges();
                }


                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges(); //database changes -> this data adds to the restaurants table
                }

            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }

        // returns restaurants that will always exist in the restaurant table
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                   Name = "KFC",
                   Category = "Fast Food",
                   Description = 
                   " KFC ked kdk kdkkdk dkkd k",
                   ContactEmail = "contact@com",
                   ContactNumber = "655 4444 4444",
                   HasDelivery = true,
                   Dishes = new List<Dish>()
                   {
                       new Dish()
                       {
                           Name = "Nasghville hot chicken",
                           Price = 10.30M,
                       },

                       new Dish()
                       {
                           Name = "nuggets",
                           Price = 5.30M,
                       },
                   },
                   Address = new Address()
                   {
                       City = "Krakow",
                       Street = "Dluga 5",
                       PostalCode = "30-001"
                   }
                },

                new Restaurant()
                {
                   Name = "KFC",
                   Category = "Fast Food",
                   Description =
                   " KFC ked kdk kdkkdk dkkd k",
                   ContactEmail = "contact@com",
                   ContactNumber = "655 4444 4444",
                   HasDelivery = true,
                   Dishes = new List<Dish>()
                   {
                       new Dish()
                       {
                           Name = "Nasghville hot chicken",
                           Price = 10.30M,
                       },

                       new Dish()
                       {
                           Name = "nuggets",
                           Price = 5.30M,
                       },
                   },
                   Address = new Address()
                   {
                       City = "Krakow",
                       Street = "Dluga 5",
                       PostalCode = "30-001"
                   }
                },

            };
            return restaurants;
        }
    }
}
