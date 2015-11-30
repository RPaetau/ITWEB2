namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodStuffs", "UserId", "dbo.Users");
            DropIndex("dbo.FoodStuffs", new[] { "UserId" });
            AlterColumn("dbo.FoodStuffs", "UserId", c => c.Int());
            CreateIndex("dbo.FoodStuffs", "UserId");
            AddForeignKey("dbo.FoodStuffs", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodStuffs", "UserId", "dbo.Users");
            DropIndex("dbo.FoodStuffs", new[] { "UserId" });
            AlterColumn("dbo.FoodStuffs", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.FoodStuffs", "UserId");
            AddForeignKey("dbo.FoodStuffs", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
