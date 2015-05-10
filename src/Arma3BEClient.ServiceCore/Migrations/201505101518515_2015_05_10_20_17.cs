namespace Arma3BEClient.ServiceCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2015_05_10_20_17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllowedUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ServerId = c.Guid(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServerInfoes", t => t.ServerId, cascadeDelete: true)
                .Index(t => t.ServerId);
            
            AddColumn("dbo.ServerInfoes", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllowedUsers", "ServerId", "dbo.ServerInfoes");
            DropIndex("dbo.AllowedUsers", new[] { "ServerId" });
            DropColumn("dbo.ServerInfoes", "UserId");
            DropTable("dbo.AllowedUsers");
        }
    }
}
