using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int FloorID { get; set; }
        public int OfficeID { get; set; }
        public int BookerID { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public List<User> Mancers { get; set; }
    }
}
