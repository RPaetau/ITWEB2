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
using Newtonsoft.Json;

namespace ITWEB2.Controllers
{
    public class FoodStuffsController : ApiController
    {
        private IGenericRepository<FoodStuffs> _foodstuffsRepo;
        private IGenericRepository<User> _userRepo; 

        public FoodStuffsController(IGenericRepository<FoodStuffs> foodstuffsRepo, IGenericRepository<User> userRepo)
        {
            this._foodstuffsRepo = foodstuffsRepo;
            _userRepo = userRepo;
        }

        public FoodStuffsController()
        {
            _userRepo = new GenericRepository<User>(new Context());
            _foodstuffsRepo = new GenericRepository<FoodStuffs>(new DAL.Context());
        }


        // GET: api/FoodStuffs
        public string Get()
        {
            if (User.Identity.GetUserId() != null)
            {
                var _UserId = User.Identity.GetUserId();
                var users = _foodstuffsRepo.Get(x => x.User == null || x.User.UserId == _UserId);
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<FoodStuffs>));
                ser.WriteObject(stream, users);
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);

                return sr.ReadToEnd();
            }
            else
            {
                var users = _foodstuffsRepo.Get(x => x.User == null);
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<FoodStuffs>));
                ser.WriteObject(stream, users);
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);

                return sr.ReadToEnd();
            }




        }

        // GET: api/FoodStuffs/5
        public string Get(int id)
        {
            var users = _foodstuffsRepo.Get(x => x.Id == id);
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<FoodStuffs>));
            ser.WriteObject(stream, users);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            return sr.ReadToEnd();
        }

        // POST: api/FoodStuffs
        public void Post(FoodStuffs data)
        {
            if (User.Identity.GetUserId() != null)
            {
                var _userId = User.Identity.GetUserId();
                data.User = _userRepo.Get(x => x.UserId == _userId).First();
                data.UserId = data.User.Id;
            }
            _foodstuffsRepo.Insert(data);
        }

        // PUT: api/FoodStuffs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FoodStuffs/5
        public void Delete(int id)
        {
            _foodstuffsRepo.Delete(id);
        }
    }
}
