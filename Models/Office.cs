using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus.Models
{
    public class Office
    {
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public int CompanyID { get; set; }
        public int TotalCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string BannerMessage { get; set; }
        [NotMapped]
        public List<Floor> Floors { get; set; }
    }
}