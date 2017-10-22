using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOhioMVC.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        [DisplayName("City or Metro Area")]
        public string CityMetro { get; set; }
        public virtual ICollection<ReviewCity> ReviewCities { get; set; }
    }
}