namespace Arma3BEClient.ServiceCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2015_05_10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Num = c.Int(nullable: false),
                        IP = c.String(),
                        Port = c.Int(nullable: false),
                        ServerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServerInfoes", t => t.ServerId, cascadeDelete: true)
                .Index(t => t.ServerId);
            
            CreateTable(
                "dbo.ServerInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Host = c.String(nullable: false),
                        Port = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Guid(),
                        Num = c.Int(nullable: false),
                        ServerId = c.Guid(nullable: false),
                        GuidIp = c.String(),
                        Minutes = c.Int(nullable: false),
                        MinutesLeft = c.Int(nullable: false),
                        Reason = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .ForeignKey("dbo.ServerInfoes", t => t.ServerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.ServerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GUID = c.String(),
                        Name = c.String(),
                        Comment = c.String(),
                        LastIp = c.String(),
                        LastSeen = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PlayerId = c.Guid(nullable: false),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.PlayerHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Guid(nullable: false),
                        Name = c.String(),
                        IP = c.String(),
                        Date = c.DateTime(nullable: false),
                        ServerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.ServerInfoes", t => t.ServerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.ServerId);
            
            CreateTable(
                "dbo.ChatLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ServerId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServerInfoes", t => t.ServerId, cascadeDelete: true)
                .Index(t => t.ServerId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChatLogs", "ServerId", "dbo.ServerInfoes");
            DropForeignKey("dbo.Bans", "ServerId", "dbo.ServerInfoes");
            DropForeignKey("dbo.PlayerHistories", "ServerId", "dbo.ServerInfoes");
            DropForeignKey("dbo.PlayerHistories", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Notes", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Bans", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Admins", "ServerId", "dbo.ServerInfoes");
            DropIndex("dbo.ChatLogs", new[] { "ServerId" });
            DropIndex("dbo.PlayerHistories", new[] { "ServerId" });
            DropIndex("dbo.PlayerHistories", new[] { "PlayerId" });
            DropIndex("dbo.Notes", new[] { "PlayerId" });
            DropIndex("dbo.Bans", new[] { "ServerId" });
            DropIndex("dbo.Bans", new[] { "PlayerId" });
            DropIndex("dbo.Admins", new[] { "ServerId" });
            DropTable("dbo.Settings");
            DropTable("dbo.ChatLogs");
            DropTable("dbo.PlayerHistories");
            DropTable("dbo.Notes");
            DropTable("dbo.Players");
            DropTable("dbo.Bans");
            DropTable("dbo.ServerInfoes");
            DropTable("dbo.Admins");
        }
    }
}
