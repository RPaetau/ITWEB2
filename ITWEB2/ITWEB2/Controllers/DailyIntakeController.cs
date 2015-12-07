using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web.Http;
using DAL;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNet.Identity;

namespace ITWEB2.Controllers
{
    public class DailyIntakeController : ApiController
    {
        private IGenericRepository<DailyIntake> _dailyIntakeRepo;
        private IGenericRepository<User> _userRepo;


        public DailyIntakeController()
        {
            _dailyIntakeRepo = new GenericRepository<DailyIntake>(new Context());
            _userRepo = new GenericRepository<User>(new Context());
        }

        // GET: api/DailyIntake
        public string Get()
        {
            var _userId = User.Identity.GetUserId();
            var dailyIntakes = _dailyIntakeRepo.Get(x => x.User.UserId == _userId);
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<DailyIntake>));
            ser.WriteObject(stream, dailyIntakes);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            return sr.ReadToEnd();

        }

        // GET: api/DailyIntake/5
        public string Get(int id)
        {
            var users = _dailyIntakeRepo.Get(x => x.Id == id).FirstOrDefault();
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DailyIntake));
            ser.WriteObject(stream, users);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            return sr.ReadToEnd();
        }

        // POST: api/DailyIntake
        public void Post([FromBody]DailyIntake value)
        {
            var _userId = User.Identity.GetUserId();

            var user = _userRepo.Get(x => x.UserId == _userId).First();

            value.User = user;
            value.Date = DateTime.Now;
            value.UserId = user.Id;

            _dailyIntakeRepo.Insert(value);

        }

        // PUT: api/DailyIntake/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DailyIntake/5
        public void Delete(int id)
        {
            _dailyIntakeRepo.Delete(id);
        }
    }
}
