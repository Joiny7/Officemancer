using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Models
{
    public class Office
    {
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public int CompanyID { get; set; }
        public int TotalCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string BannerMessage { get; set; }
        public List<Floor> Floors { get; set; }

        //public Floor CreateFloor(string name, int maxMancers, bool open)
        //{
        //    Floor newFloor = new Floor
        //    {
        //        name = name,
        //        maxMancers = maxMancers,
        //        currentMancers = 0,
        //        open = open
        //    };

        //    floors.Add(newFloor);
        //    return newFloor;
        //}

        //public int GetTotal
    }
}