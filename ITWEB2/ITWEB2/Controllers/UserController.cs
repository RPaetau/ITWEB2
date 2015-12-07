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
    public class UserController : ApiController
    {
        private IGenericRepository<User> _userRepo;
        private IGenericRepository<FoodStuffs> _foodRepo;
        private IGenericRepository<DailyIntake> _intakeRepo; 

        public UserController(IGenericRepository<User> userRepo, IGenericRepository<FoodStuffs> foodRepo, IGenericRepository<DailyIntake> intakeRepo)
        {
            _userRepo = userRepo;
            _foodRepo = foodRepo;
            _intakeRepo = intakeRepo;
        }

        public UserController()
        {
            _foodRepo = new GenericRepository<FoodStuffs>(new Context());
            _intakeRepo = new GenericRepository<DailyIntake>(new Context());
            _userRepo = new GenericRepository<User>(new Context());
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
        public string GetMyUser(int Id)
        {

            var id = User.Identity.GetUserId();
            var users = _userRepo.Get(x=>x.UserId == id,null).First();
            users.MyDailyIntakes = _intakeRepo.Get(x => x.UserId == users.Id);
            users.MyFoodStuffs = _foodRepo.Get(x => x.UserId == users.Id);
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
            ser.WriteObject(stream, users);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            return sr.ReadToEnd();
        }

        // POST: api/User
        public void Post(string id)
        {
            _userRepo.Insert(new User() {UserId = id});
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
