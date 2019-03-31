using PingPong.Domain.Entities;
using PingPong.Infra.Data.EntityConfig;
using PingPong.Infra.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Infra.Data.Context
{
    public class PingPongContext : DbContext
    {
        public PingPongContext()
            : base("PingPongConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PingPongContext, Configuration>());

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
