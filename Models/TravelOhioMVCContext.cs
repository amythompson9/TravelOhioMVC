using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TravelOhioMVC.Models
{
    public class TravelOhioMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TravelOhioMVCContext() : base("name=TravelOhioMVCContext")
        {
        }

        public System.Data.Entity.DbSet<TravelOhioMVC.Models.Attraction> Attractions { get; set; }

        public System.Data.Entity.DbSet<TravelOhioMVC.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<TravelOhioMVC.Models.Festival> Festivals { get; set; }

        public System.Data.Entity.DbSet<TravelOhioMVC.Models.Review> Reviews { get; set; }

        public System.Data.Entity.DbSet<TravelOhioMVC.Models.ReviewAttraction> ReviewAttractions { get; set; }

        public System.Data.Entity.DbSet<TravelOhioMVC.Models.ReviewCity> ReviewCities { get; set; }

        public System.Data.Entity.DbSet<TravelOhioMVC.Models.ReviewFestival> ReviewFestivals { get; set; }
    }
}
