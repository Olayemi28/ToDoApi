using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueTodoApplication.Models
{
    public class LoginRequestModel
    {
        public string UserNameOrEmail { get; set; }

        public string Password { get; set; }
    }
}
