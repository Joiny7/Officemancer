using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Models
{
    public class Reservation
    {
        public DateTime date { get; set; }
        public int floorID { get; set; }
        public User mancer { get; set; }
    }
}
