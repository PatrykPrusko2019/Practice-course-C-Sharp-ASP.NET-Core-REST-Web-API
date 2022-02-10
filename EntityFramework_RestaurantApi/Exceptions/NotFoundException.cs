using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) // calls the constructor from the base class
        {
                
        }
    }
}
