using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus.Models
{
    public class Floor
    {
        public int FloorID { get; set; }
        public string FloorName { get; set; }
        public int OfficeID { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public bool Bookable { get; set; }
        [NotMapped]
        public List<Reservation> Reservations { get; set; }
    }
}