using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_Week_5.Models.View
{
    public class KidViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name of Kid")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name of Kid")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Kids' Age")]
        public int Age { get; set; }

        [Display(Name = "Name of Parent 1")]
        public string Parent1 { get; set; }

        [Display(Name = "Name of Parent 2")]
        public string Parent2 { get; set; }

        [Required]
        [Display(Name = "Kids' Birthday")]
        public DateTime Birthday { get; set; }

        public int UserId { get; set; }
    }
}