﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Display(Name = "Office Email")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\/[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Department is Required")]
        public Dept? Department { get; set; }
    }
}
