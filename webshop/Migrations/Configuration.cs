namespace webshop.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using webshop.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<webshop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
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
            
            var passwordHash = new PasswordHasher();
            string defautlPassword = passwordHash.HashPassword("Password@123");
            context.Users.AddOrUpdate(p => p.UserName, 
                new ApplicationUser {
                    UserName = "Sam",
                    Email = "vdossche.sam@gmail.com",
                    PasswordHash = defautlPassword
                });
        }
    }
}
