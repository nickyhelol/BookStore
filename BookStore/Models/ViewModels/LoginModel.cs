using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]      //Hide the password input from screen
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";

    }
}
