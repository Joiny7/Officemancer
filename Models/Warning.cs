using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus.Models
{
    public class Warning
    {
        public int WarningID { get; set; }
        public int CompanyID { get; set; }
        public int? OfficeID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}
