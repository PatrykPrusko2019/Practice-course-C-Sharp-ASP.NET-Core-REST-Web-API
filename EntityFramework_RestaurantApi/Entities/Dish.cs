using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Entities
{
    public class Dish
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public int RestaurantId { get; set; } //property typu int
        public virtual Restaurant Restaurant { get; set; }
    }
}
