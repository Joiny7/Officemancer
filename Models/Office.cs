using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Models
{
    public class Office
    {
        public string name { get; set; }
        public int totalMaxMancers { get; set; }
        public int totalCurrentMancers { get; set; }
        public List<Floor> floors { get; set; }

        public Floor CreateFloor(string name, int maxMancers, bool open)
        {
            Floor newFloor = new Floor
            {
                name = name,
                maxMancers = maxMancers,
                currentMancers = 0,
                open = open
            };

            floors.Add(newFloor);
            return newFloor;
        }

        //public int GetTotal
    }
}