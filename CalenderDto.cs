﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Dtos
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

    public class UserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyID { get; set; }
        public bool Admin { get; set; }
    }
}