using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Models.Mapping;
using TravelEntity;

namespace TravelData
{
    class TravelContext : DbContext
    {
        static TravelContext()
        {
            Database.SetInitializer<TravelContext>(null);
        }

        public TravelContext()
            : base("Name=TravelContext")
        {
          // Database.SetInitializer<TravelContext>(new DropCreateDatabaseIfModelChanges<TravelContext>());
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Group_Formed> Group_Formed { get; set; }
        public DbSet<Group_Request> Group_Request { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<MoneyCalAdmin> MoneyCalAdmins { get; set; }
        public DbSet<MoneyCalGuide> MoneyCalGuides { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Tourist> Tourists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AdminMap());
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new Group_FormedMap());
            modelBuilder.Configurations.Add(new Group_RequestMap());
            modelBuilder.Configurations.Add(new GuideMap());
            modelBuilder.Configurations.Add(new MoneyCalAdminMap());
            modelBuilder.Configurations.Add(new MoneyCalGuideMap());
            modelBuilder.Configurations.Add(new RatingMap());
            modelBuilder.Configurations.Add(new TourMap());
            modelBuilder.Configurations.Add(new TouristMap());
        }
    }
}
