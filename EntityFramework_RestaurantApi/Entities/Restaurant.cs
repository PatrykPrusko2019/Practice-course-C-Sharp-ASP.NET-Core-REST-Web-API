using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Entities
{ 
    /// <summary>
    /// ta klasa odpowiada tabeli bazie danych , ktora powstanie na podstawie tej klasy 
    /// </summary>
    public class Restaurant
    {
        public int Id { get; set; } // klucz glowny //entity framework bedzie w stanie rozpoznac to pole i na jego podstawie utworzyc primary key w tabeli danych
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; } // ma dostawe
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }

        public int AddressId { get; set; }//klucz obcy do tabeli z adresem //entity framework utworzy referencje do osobnej tabeli

        public virtual Address Address { get; set; } // odniesc bezposrednio do adresu ktore zawiera dana restauracja

        public virtual List<Dish> Dishes { get; set; } //lista dan ktora bedzie zawierac dana restauracja


    }
}
