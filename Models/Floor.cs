using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Models
{
    public class Floor
    {
        public int FloorID { get; set; }
        public string FloorName { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public bool Bookable { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}