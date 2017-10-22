using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelOhioMVC.Models
{
    public class ReviewAttraction
    {
        [Key]
        public int ReviewAttractionID { get; set; }
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

        [ForeignKey("Attraction")]
        public int AttractionID { get; set; }
        public Attraction Attraction { get; set; }
    }
}