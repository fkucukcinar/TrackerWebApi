using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class TrackModel
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string FullName { get; set; }
        public int IsEntrance { get; set; }
        public int IsLeave { get; set; }
        public DateTime EntranceTime { get; set; }

        public DateTime? LeaveTime { get; set; }
        public string TrackDay { get; set; }

    }
}
