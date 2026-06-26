using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SQLitePCL;

namespace pvsCollector.Data
{
    public class pvsCollectorContextFactory : IDesignTimeDbContextFactory<pvsCollectorContext>
    {
        /*
        public pvsCollectorContext CreateDbContext(string[] args)
        {
            // EF tools never go through Program.cs, so the provider must be initialized here too
            raw.SetProvider(new SQLite3Provider_e_sqlite3());

            var options = new DbContextOptionsBuilder<pvsCollectorContext>()
                .UseSqlite("Data Source=./pvsCollector.db")
                .Options;

            return new pvsCollectorContext(options);
        }
        */
        public pvsCollectorContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<pvsCollectorContext>()
                .UseSqlServer("Server=.\\SQLExpress;Database=pvsCollectorNET;Trusted_Connection=Yes;TrustServerCertificate=Yes")
                .Options;
            return new pvsCollectorContext(options);
        }
    }
}