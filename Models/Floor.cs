using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Models
{
    public class Floor
    {
        public int floorID { get; set; }
        public string name { get; set; }
        public int maxMancers { get; set; }
        public int currentMancers { get; set; }
        public bool open { get; set; }
        public List<Reservation> reservations { get; set; }
    }
}