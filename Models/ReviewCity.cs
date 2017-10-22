using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelOhioMVC.Models
{
    public class ReviewCity
    {
        [Key]
        public int ReviewCityID { get; set; }
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

        [ForeignKey("City")]
        [DisplayName("City or Metro Area")]
        public int CityID { get; set; }
        [DisplayName("City or Metro Area")]
        public City City { get; set; }
    }
}