using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DucksOnThePond.Core
{
    public class Person
    {
        public int ID { get; set; }

        [Required(ErrorMessage =  "Name field is required.")]
        public string Name { get; set; }

        [RegularExpression(".+\\@\\..+", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [RegularExpression(@"\d+")]
        public string PhoneNumber { get; set; } 
    }
}