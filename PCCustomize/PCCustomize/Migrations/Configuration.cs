namespace PCCustomize.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PCCustomize.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PCCustomize.Models.CustomizeDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PCCustomize.Models.CustomizeDB";
        }

        protected override void Seed(PCCustomize.Models.CustomizeDB context)
        {
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

            //context.Cates.AddOrUpdate(
            //    new Category
            //    {
            //        Name = "Mother Board",
            //        IsDel = 0
            //    },
            //    new Category 
            //    { 
            //        Name = "CPU",
            //        IsDel = 0
            //    },
            //    new Category 
            //    { 
            //        Name = "RAM",
            //        IsDel = 0
            //    },
            //    new Category 
            //    { 
            //        Name = "Graphic Card",
            //        IsDel = 0
            //    },
            //    new Category 
            //    { 
            //        Name = "Disk",
            //        IsDel = 0
            //    },
            //    new Category 
            //    { 
            //        Name = "Monitor",
            //        IsDel = 0
            //    },
            //    new Category 
            //    { 
            //        Name = "DVD/CD Drive",
            //        IsDel = 0
            //    },
            //    new Category 
            //    { 
            //        Name = "Mouse",
            //        IsDel = 0
            //    },
            //    new Category 
            //    { 
            //        Name = "Keyboard",
            //        IsDel = 0
            //    }
            //);
        }
    }
}
