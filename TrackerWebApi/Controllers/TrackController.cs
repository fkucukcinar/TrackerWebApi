using EmployeeTracker.Contracts;
using EmployeeTracker.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TrackController : Controller
    {
        private readonly ITrackService _service;
        
        public TrackController(ITrackService service)
        {
            this._service = service;
        }

        [HttpPost("saveTrack")]
        public async Task<BaseResponse> saveTrack([FromBody] TrackModel track)
        {
            var result  = await _service.SaveTrack(track);
            return result;
        }
        [HttpGet("saveTrack")]
        public IActionResult SaveTrack()
        {
            return View();
        }
        [HttpGet("GetTracks")]
        public async Task<List<TrackModel>> getTracks()
        {
            var trackList = await _service.GetTracks();
            return trackList;
        }
       
        [HttpGet("Login")]
        public bool Login( string userName)
        {
            var isUserAdmin =  _service.checkUserAdmin(userName);
            return isUserAdmin;
        }
        [HttpGet("notAuthorized")]
        public IActionResult NotAuthorized()
        {
            return View();
        }
    }
}
