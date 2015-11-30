using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web.Http;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNet.Identity;

namespace ITWEB2.Controllers
{
    public class UserController : ApiController
    {
        private IGenericRepository<User> _userRepo;

        public UserController(IGenericRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }


        // GET: api/User
        public string Get()
        {
            var users = _userRepo.Get(null, null, "FoodStuffs, DailyIntake");
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<User>));
            ser.WriteObject(stream,users);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);


            return sr.ReadToEnd();
        }

        // GET: api/User/5
        public string GetMyUser()
        {

            var id = User.Identity.GetUserId();
            var users = _userRepo.Get(x=>x.UserId == id, null, "FoodStuffs, DailyIntake");
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<User>));
            ser.WriteObject(stream, users);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            return sr.ReadToEnd();
        }

        // POST: api/User
        public void Post()
        {
            _userRepo.Insert(new User() {UserId = User.Identity.GetUserId()});
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
