using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
    }
}