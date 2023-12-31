﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Domain.Dto.UserDto
{
    public class UserLoginDto
    {
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
