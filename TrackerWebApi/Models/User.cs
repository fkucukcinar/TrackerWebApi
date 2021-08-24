using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
       
        public string FullName { get; set; }
        
        public string UserName { get; set; }
     
        public string Password { get; set; }
        public int IsAdmin { get; set; }
        
    }
}
