﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class LoginResponse
    {
        public string Username { get; set; } = string.Empty;


        public string Role { get; set; } = string.Empty;

        public int? Id { get; set; }

        public string Token { get; set; } = string.Empty;
    }
}
