using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_Week_4.Data.Entities
{
    public class Kid
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Parent1 { get; set; }

        public string Parent2 { get; set; }

        public DateTime Birthday { get; set; }

        public int UserId { get; set; }
    }
}