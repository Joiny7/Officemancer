using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyID { get; set; }
        public bool Admin { get; set; }
    }
}