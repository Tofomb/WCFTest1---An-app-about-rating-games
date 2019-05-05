namespace WCFTest1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WCFTest1.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<WCFTest1.WCFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WCFTest1.WCFDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.GR.AddOrUpdate(new GameRating { Title = "Zelda 2", Rating = 3 });
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
