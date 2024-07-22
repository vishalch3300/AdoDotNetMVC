using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdoDotNetMVC.Models
{
    public class Employee
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public string gender { get; set; }

        [Display(Name = "Age")]
        [Required]
        public int age { get; set; }

        [Display(Name = "Salary")]
        [Required]
        public int salary { get; set; }

        [Display(Name = "City")]
        [Required]
        public string city { get; set; }
    }
}