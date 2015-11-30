using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Weight { get; set; }
        public IEnumerable<FoodStuffs> MyFoodStuffs { get; set; }

    }
}