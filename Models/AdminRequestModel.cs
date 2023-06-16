using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueTodoApplication.Models
{
    public class AdminRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string AdminPhoto { get; set; }
    }

    public class UpdateAdminRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string AdminPhoto { get; set; }
    }
}
