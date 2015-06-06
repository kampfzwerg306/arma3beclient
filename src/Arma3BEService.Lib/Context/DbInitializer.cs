using System.Data.Entity;

namespace Arma3BEService.Lib.Context
{
    class DbInitializer : CreateDatabaseIfNotExists<Arma3BeServiceContext>
    {
        public DbInitializer()
        {
            
        }
    } 
}