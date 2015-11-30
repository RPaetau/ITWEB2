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
using Newtonsoft.Json;

namespace ITWEB2.Controllers
{
    public class FoodStuffsController : ApiController
    {
        private IGenericRepository<FoodStuffs> _foodstuffsRepo;

        public FoodStuffsController(IGenericRepository<FoodStuffs> foodstuffsRepo)
        {
            this._foodstuffsRepo = foodstuffsRepo;
        }

        public FoodStuffsController()
        {
            _foodstuffsRepo = new GenericRepository<FoodStuffs>(new DAL.Context());
        }


        // GET: api/FoodStuffs
        public string Get()
        {
            var users = _foodstuffsRepo.Get(x => x.User == null);
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<FoodStuffs>));
            ser.WriteObject(stream, users);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            return sr.ReadToEnd();
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
