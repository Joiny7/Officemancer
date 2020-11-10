using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus.Models
{
    public class UserReservation
    {
        public int UserReservationID { get; set; }
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
