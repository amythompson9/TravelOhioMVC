using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOhioMVC.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Describe your experience in one word.")]
        public string Title { get; set; }
        [DisplayName("Would you recommend this to your friends?")]
        public bool Rating { get; set; }
        [DisplayName("Date of experience")]
        public DateTime Attended { get; set; }
        [DisplayName("Tell us about your experience.")]
        public string ReviewText { get; set; }
    }
}