using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiApp.Models.Core
{
    public class CoreContext : DbContext
    {
        public CoreContext()
           : base("CoreConnection")
        { }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Skills> Skills { get; set; }

        public DbSet<Award> Awards { get; set; }

        public DbSet<Season> Seasons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>().HasRequired(a => a.Event)
                .WithMany(e => e.Awards)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Award>()
                .HasMany(a => a.QualifiesFor)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}