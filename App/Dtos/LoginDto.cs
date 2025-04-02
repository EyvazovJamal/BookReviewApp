using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Dtos
{
    public class LoginDto
    {
        public string? ReturnUrl { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}