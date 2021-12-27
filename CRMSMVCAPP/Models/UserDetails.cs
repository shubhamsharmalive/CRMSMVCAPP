using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSMVCAPP.Models
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
        public int PackageId { get; set; }
    }
}