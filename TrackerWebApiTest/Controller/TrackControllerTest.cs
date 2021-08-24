using EmployeeTracker.Contracts;
using EmployeeTracker.Controllers;
using EmployeeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TrackerWebApiTest.Controller
{
    public class TrackControllerTest
    {
        private readonly Mock<ITrackService>  _mockService;
        private readonly TrackController _controller;

        private List<TrackModel> tracks;
        public TrackControllerTest()
        {
            _mockService = new Mock<ITrackService>();
            _controller = new TrackController(_mockService.Object);

            tracks = new List<TrackModel>() { new TrackModel { FullName="fehmi k", EntranceTime = DateTime.Now, LeaveTime = DateTime.Now.AddMinutes(60) , TrackDay = DateTime.Now.ToString()},
                 new TrackModel { FullName="ali k", EntranceTime = DateTime.Now, LeaveTime = DateTime.Now.AddMinutes(200) , TrackDay = DateTime.Now.ToString() } 
            };
        }

        [Fact]
        public async void getTracks_ActionExecutes_ReturnsResultWithTracks()
        {
            _mockService.Setup(x => x.GetTracks()).ReturnsAsync(tracks);

            var result = await _controller.getTracks();

            var returnTracks = Assert.IsAssignableFrom<IEnumerable<TrackModel>>(result);

            Assert.Equal<int>(2, returnTracks.ToList().Count);
        }

    }
}
