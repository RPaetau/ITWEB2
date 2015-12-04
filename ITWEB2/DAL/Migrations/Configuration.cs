using DAL.Entities;

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DAL.Context";
        }

        protected override void Seed(DAL.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //¨¨
                
            context.FoodStuffs.AddOrUpdate(x=>x.Navn,
                new FoodStuffs() { Navn = "Bøf", Protein100Gr = 20},
                new FoodStuffs() { Navn = "Tun", Protein100Gr = 27 },
                new FoodStuffs() { Navn = "Kylling", Protein100Gr = 26 },
                new FoodStuffs() { Navn = "Soya Bønner", Protein100Gr = 36 },
                new FoodStuffs() { Navn = "Peanuts", Protein100Gr = 25 },
                new FoodStuffs() { Navn = "Broccoli", Protein100Gr = 5 },
                new FoodStuffs() { Navn = "Champignion", Protein100Gr = 3 },
                new FoodStuffs() { Navn = "Skyr", Protein100Gr = 11 },
                new FoodStuffs() { Navn = "Rejer", Protein100Gr = 24 },
                new FoodStuffs() { Navn = "Hvide bønner", Protein100Gr = 21 },
                new FoodStuffs() { Navn = "Hørfrø", Protein100Gr = 25 },
                new FoodStuffs() { Navn = "Pistacienødder", Protein100Gr = 21 },
                new FoodStuffs() { Navn = "Grønne bønner", Protein100Gr = 2 },
                new FoodStuffs() { Navn = "Rosiner", Protein100Gr = 4 },
                new FoodStuffs() { Navn = "Mandel", Protein100Gr = 21 },
                new FoodStuffs() { Navn = "Majskolbe", Protein100Gr = 4 }
                );

                
        }
    }
}
