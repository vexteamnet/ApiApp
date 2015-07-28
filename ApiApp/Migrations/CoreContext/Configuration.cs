namespace ApiApp.Migrations.CoreContext
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiApp.Models.CoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CoreContext";
        }

        protected override void Seed(ApiApp.Models.CoreContext context)
        {
            context.Teams.AddOrUpdate(
                new Team { Number = "7701", City = "Zionsville", Country = "United States", IsRegistered = false, Level = Level.HighSchool, Name = "Steel Eagle I", Organization = "Zionsville Robotics", Program = Program.VRC, Region = "Indiana" },
                new Team { Number = "7701M", City = "Zionsville", Country = "United States", IsRegistered = false, Level = Level.HighSchool, Name = "Steel Eagle M", Organization = "Zionsville Robotics", Program = Program.VRC, Region = "Indiana" },
                new Team { Number = "7702", City = "Zionsville", Country = "United States", IsRegistered = false, Level = Level.HighSchool, Name = "Steel Eagle II", Organization = "Zionsville Robotics", Program = Program.VRC, Region = "Indiana" },
                new Team { Number = "7701S", City = "Zionsville", Country = "United States", IsRegistered = false, Level = Level.HighSchool, Name = "Steel Eagle S", Organization = "Zionsville Robotics", Program = Program.VRC, Region = "Indiana" },
                new Team { Number = "7701X", City = "Zionsville", Country = "United States", IsRegistered = false, Level = Level.HighSchool, Name = "Steel Eagle X", Organization = "Zionsville Robotics", Program = Program.VRC, Region = "Indiana" },
                new Team { Number = "323Z", City = "Indianapolis", Country = "United States", IsRegistered = false, Level = Level.HighSchool, Name = "Aftershock", Organization = "Zionsville Robotics", Program = Program.VRC, Region = "Indiana" },
                new Team { Number = "323X", City = "Indianapolis", Country = "United States", IsRegistered = false, Level = Level.HighSchool, Name = "Bots", Organization = "Zionsville Robotics", Program = Program.VRC, Region = "Indiana" }
                );

            context.Events.AddOrUpdate(
                new Event { Sku = "RE-VRC-15-1000", Agenda = "10:00 am - do stuff\n11:00 pm - do less stuff", Contact = new Contact { Email = "enoble@zcs.k12.in.us", Name = "Eric Noble" }, Finish = new DateTime(2015, 2, 14), Levels = Level.HighSchool, Name = "Zionsville Event", Season = "VRC 2015", Program = Program.VRC, Start = new DateTime(2015, 2, 14), Venue = new Venue { Name = "Zionsville Community High School", Address = "1000 Mulberry Street", Country = "United States", Region = "Indiana", City = "Zionsville" } }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
