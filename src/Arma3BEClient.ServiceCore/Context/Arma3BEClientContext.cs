using System.Data.Entity;
using Arma3BEClient.ServiceCore.Model;

namespace Arma3BEClient.ServiceCore.Context
{
    public class Arma3BeClientServiceContext : DbContext
    {
        public DbSet<ChatLog> ChatLog { get; set; }
        public DbSet<Note> Comments { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<ServerInfo> ServerInfo { get; set; }

        public DbSet<AllowedUsers> AllowedUsers { get; set; }

        public DbSet<Settings> Settings { get; set; }

        public DbSet<Ban> Bans { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<PlayerHistory> PlayerHistory { get; set; }

        public Arma3BeClientServiceContext()
            : base("name=DefaultConnection")
        {

        }

        static Arma3BeClientServiceContext()
        {
            Database.SetInitializer(new DbInitializer());
            using (var db = new Arma3BeClientServiceContext())
                db.Database.Initialize(false);
        }
    }


    class DbInitializer : CreateDatabaseIfNotExists<Arma3BeClientServiceContext>
    {
        public DbInitializer()
        {

        }
    }
}