using EmployeeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Contracts
{
    public interface ITrackService
    {
        Task<BaseResponse> SaveTrack([FromBody] TrackModel track);
        Task<List<TrackModel>> GetTracks();
        bool checkUserAdmin(string userName);
    }
}
