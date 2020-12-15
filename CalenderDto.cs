using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus.Dtos
{
    public class CalenderDto
    {
        public string Month { get; set; }
        public List<DayDto> Days { get; set; }
    }

    public class DayDto
    {
        public int OfficeID { get; set; }
        public DateTime Date { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
    }

    public class UserDataDto
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }

    public class UserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyID { get; set; }
        public bool Admin { get; set; }
    }
    public class ReservationDto
    {
        public int FloorID { get; set; }
        public DateTime Date { get; set; }
        public List<int> UserIds { get; set; }
    }
}