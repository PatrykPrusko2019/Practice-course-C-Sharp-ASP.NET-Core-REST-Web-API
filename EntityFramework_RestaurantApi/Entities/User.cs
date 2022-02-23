using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; } // may be a value -> null
        public string Nationality { get; set; }
        public string PasswordHash { get; set; }

        public int RoleId { get; set; } // foreign key in the table with roles
        public virtual Role Role { get; set; }
    }
}
