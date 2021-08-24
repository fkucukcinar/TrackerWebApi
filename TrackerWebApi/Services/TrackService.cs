using EmployeeTracker.Contracts;
using EmployeeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace EmployeeTracker.Services
{
    public class TrackService : BaseService, ITrackService
    {
        private IConfiguration _config;
        private readonly TrackingApiContext _context;

        public TrackService(IConfiguration config, IServiceProvider serviceProvider, TrackingApiContext context) : base(serviceProvider)
        {
            this._config = config;
            this._context = context;
        }

        public async Task<BaseResponse> SaveTrack([FromBody] TrackModel track)
        {
            var response = new BaseResponse();
            try
            {
                using (var trsct = _context.Database.BeginTransaction())
                {
                    //checkUser(track.UserId, )
                    var trackDb = new Track();
                    var user = await _context.User.Where(u => u.UserName == track.UserName).FirstOrDefaultAsync();
                    if (user == null)
                    {
                        response.SetError("User not found");
                        return response;
                    }
                    else
                    {
                        trackDb = await _context.Track.Where(t => t.UserId == user.UserId && (DateTime)t.TrackDay == DateTime.Now.Date).FirstOrDefaultAsync();
                        if (trackDb == null)
                        {
                            trackDb = new Track();
                            trackDb.TrackDay = DateTime.Now.Date;
                            _context.Add(trackDb);
                        }
                    
                        if (track.IsEntrance == 1)
                            trackDb.EntranceTime = DateTime.Now;
                        if (track.IsLeave == 1)
                            trackDb.LeaveTime = DateTime.Now;
                        
                        trackDb.UserId = user.UserId;   

                        await _context.SaveChangesAsync();
                        trsct.Commit();
                        return response;
                    }
                    
                }
            }
            catch (Exception e)
            {
                response.SetError("Unexpected Error.");
                return response;
            }

        }
    
        public async Task<List<TrackModel>> GetTracks()
        {
            var trackList = new List<TrackModel>();
            try
            {
                using (var trsct = _context.Database.BeginTransaction())
                {
                    //var trackDb = new Track();
                    //var isUserAdmin = checkUserAdmin(userName);
                    //if (!isUserAdmin)
                    //{
                    //    return trackList;
                    //}
                    //else
                    {
                        

                        //var tracks = await _context.Track.ToListAsync();
                        //foreach(var item in tracks)
                        //{
                        //    var user = await _context.User.Where(u => u.UserId == item.UserId).FirstOrDefaultAsync();
                        //    var track = new TrackModel();
                        //    track.FullName = user.FullName;
                        //    track.TrackDay = item.TrackDay.ToString();
                        //    track.EntranceTime = item.EntranceTime;
                        //    track.LeaveTime = item.LeaveTime;
                        //    trackList.Add(track);
                        //}
                        trackList = await (from tt in _context.Track
                                           join u in _context.User on tt.UserId equals u.UserId
                                           select new TrackModel
                                           {
                                               UserName = u.UserName,
                                               FullName = u.FullName,
                                               EntranceTime = tt.EntranceTime,
                                               LeaveTime = tt.LeaveTime,
                                               TrackDay = tt.TrackDay.ToString()
                                           }).ToListAsync();
                        return trackList;
                    }

                }
            }
            catch (Exception e)
            {
                return trackList;
            }

        }
        public bool checkUserAdmin(string userName)
        {
            var result = false;
            var trackList = new List<Track>();
            try
            {
                var trackDb = new Track();
                var user =  _context.User.Where(u => u.UserName == userName && u.IsAdmin == 1).FirstOrDefault();
                result = user == null ? false : true;
            }
            catch (Exception e)
            {
                return result;
            }
            return result;
        }
    }
}
