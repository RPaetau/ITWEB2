namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dailyIntakes2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyIntakes", "UserId", c => c.Int());
            CreateIndex("dbo.DailyIntakes", "UserId");
            AddForeignKey("dbo.DailyIntakes", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyIntakes", "UserId", "dbo.Users");
            DropIndex("dbo.DailyIntakes", new[] { "UserId" });
            DropColumn("dbo.DailyIntakes", "UserId");
        }
    }
}
