using System.Data.Entity;
using Arma3BEService.Lib.ModelCompact;

namespace Arma3BEService.Lib.Context
{
    public class Arma3BeServiceContext:DbContext
    {
        public DbSet<ChatLog> ChatLog { get; set; }
        public DbSet<Note> Comments { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<ServerInfo> ServerInfo { get; set; }

        public DbSet<Settings> Settings { get; set; }
        
        public DbSet<Ban> Bans { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<PlayerHistory> PlayerHistory { get; set; }



        public Arma3BeServiceContext()
            : base("name=Arma3BEClientEntities")
        {
          
        }

        static Arma3BeServiceContext()
        {
            Database.SetInitializer(new DbInitializer());
            using (var db = new Arma3BeServiceContext())
                db.Database.Initialize(false);
        }
    }


    class DbInitializer : CreateDatabaseIfNotExists<Arma3BeServiceContext>
    {
        public DbInitializer()
        {
            
        }
    } 
}