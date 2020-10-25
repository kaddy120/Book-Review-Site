﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Models
{
    public class LoginViewModel
    {
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool RememberMe { get; set; }
    }
}
