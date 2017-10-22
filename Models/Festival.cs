using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOhioMVC.Models
{
    public class Festival
    {
        [Key]
        public int FestivalID { get; set; }
        [DisplayName("Local Festivals")]
        public string LocalFestival { get; set; }
        public virtual ICollection<ReviewFestival> ReviewFestivals { get; set; }
    }
}