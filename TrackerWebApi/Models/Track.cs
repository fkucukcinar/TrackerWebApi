using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class Track
    {
        [Key]
        public long TrackId { get; set; }
        public long UserId { get; set; }
        public DateTime? TrackDay { get; set; }
        public DateTime EntranceTime { get; set; }
        public DateTime? LeaveTime { get; set; }
        
    }
}
