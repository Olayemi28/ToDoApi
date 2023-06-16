using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Enum;

namespace UniqueTodoApplication.Models
{
    public class CustomerRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string CustomerPhoto { get; set; }

        public MaritalStatus MaritalStatus { get; set; }
    }

    public class UpdateCustomerRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CustomerPhoto { get; set; }

        public MaritalStatus MaritalStatus { get; set; }
    }
}
