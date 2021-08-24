using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public class BaseService
    {
        public IServiceProvider ServiceProvider { get; set; }
        public TrackingApiContext context { get; set; }

        public BaseService(IServiceProvider serviceProvider)
        {
            context = serviceProvider.GetRequiredService<TrackingApiContext>();
            ServiceProvider = serviceProvider;
        }
    }
}
