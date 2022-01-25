using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Entities
{
    /// <summary>
    /// this class corresponds to the table in the database that will be created from this class
    /// </summary>
    public class Restaurant
    {
        public int Id { get; set; } // primary key // Entity Framework master key will be able to recognize this field and base it on creating a primary key in the data table
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }

        public int AddressId { get; set; } // foreign key to a table with the address // entity framework will create a reference to a separate table

        public virtual Address Address { get; set; } // direct reference to the address contained in the restaurant

        public virtual List<Dish> Dishes { get; set; } // list of dishes that will be included in the given restaurant


    }
}
