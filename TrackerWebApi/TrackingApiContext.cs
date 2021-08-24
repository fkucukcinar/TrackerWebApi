using EmployeeTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker
{
    public class TrackingApiContext : DbContext
    {
        public TrackingApiContext(DbContextOptions<TrackingApiContext> options) : base(options) { }
      
        public DbSet<User> User { get; set; }
        public DbSet<Track> Track { get; set; }
    }
}
