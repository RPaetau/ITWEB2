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

            var users = _userRepo.Get(x => x.UserId == User.Identity.GetUserId(),null,"DailyIntake").First().MyDailyIntakes;
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<DailyIntake>));
            ser.WriteObject(stream, users);
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
            var user = _userRepo.Get(x => x.UserId == User.Identity.GetUserId()).First();
            
            user.MyDailyIntakes.ToList().Add(value);

            _userRepo.Update(user);

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
