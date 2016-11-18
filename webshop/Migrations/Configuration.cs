namespace webshop.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using webshop.Models;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<webshop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEF(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            string role = "ShopAdmin";
            string password = "Password@123";

            string userName = "vdbossche.sam@gmail.com";

            //Create Role  and User   
            //Create Role if it does not exist
            if (!RoleManager.RoleExists(role))
            {
                var roleresult = RoleManager.Create(new IdentityRole(role));
            }
            var user = new ApplicationUser();
            user.UserName = userName;
            user.Email = userName;
            var result = UserManager.Create(user,password);

            //Add User to Role
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, role);
            }
        }
    }
}
