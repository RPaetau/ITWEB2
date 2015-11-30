using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class Context:DbContext
    {
        public Context() : base("DefaultConnection")
        {}  

        public DbSet<User> Users { get; set; }
        public DbSet<FoodStuffs> FoodStuffs { get; set; }
        public DbSet<DailyIntake> DailyIntakes { get; set; }

    }
}