using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOhioMVC.Models
{
    public class Attraction
    {
        [Key]
        public int AttractionID { get; set; }
        [DisplayName("Local Attraction")]
        public string LocalAttraction { get; set; }
        public virtual ICollection<ReviewAttraction> ReviewAttractions { get; set; }
    }
}