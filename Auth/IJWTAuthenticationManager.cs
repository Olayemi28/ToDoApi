using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.DTOs;

namespace UniqueTodoApplication.Auth
{
    public interface IJWTAuthenticationManager
    {
        public string GenerateToken(UserDto user);
    }
}
