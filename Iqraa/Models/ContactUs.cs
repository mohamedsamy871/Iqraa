using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Iqraa.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Message { get; set; }
        public string Reply { get; set; }
    }
}