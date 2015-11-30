namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyIntakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SamletProtein = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodStuffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Navn = c.String(),
                        Protein100Gr = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodStuffs", "UserId", "dbo.Users");
            DropIndex("dbo.FoodStuffs", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.FoodStuffs");
            DropTable("dbo.DailyIntakes");
        }
    }
}
