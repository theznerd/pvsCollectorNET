using Microsoft.EntityFrameworkCore;
using pvsCollector.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollector.Data
{
    public class pvsCollectorContext : DbContext
    {
        public DbSet<Inverter> Inverters { get; set; }
        public DbSet<Meter> Meters { get; set; }

        public pvsCollectorContext(DbContextOptions<pvsCollectorContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(pvsCollectorContext).Assembly);
        }
    }
}
