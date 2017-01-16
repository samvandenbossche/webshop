using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webshop.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("WebshopContext", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new WebshopInitializer());
        }

        public static ApplicationDbContext Create()

        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }

    internal class WebshopInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
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
            var result = UserManager.Create(user, password);

            //Add User to Role
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, role);
            }


            /*Create some categories*/
            var catYacht = new Category();
            catYacht.Name = "Yacht";
            // catYacht.ID = 1;
            context.Categories.Add(catYacht);


            var catAccesories = new Category();
            catAccesories.Name = "Accessories";
            // catAccesories.ID = 2;
            context.Categories.Add(catAccesories);


            var catGhh = new Category();
            catGhh.Name = "Gloves, Hoods & Hats";
            // catGhh.ID = 3;
            context.Categories.Add(catGhh);


            var catSportsboat = new Category();
            catSportsboat.Name = "Sportsboat";
            // catSportsboat.ID = 4;
            context.Categories.Add(catSportsboat);


            /*Create some items. could have this much better with an array and a loop.*/
            var product = new Product();
            product.Name = "COASTAL RACER JACKET BLUE";
            product.PictureUrl = "https://cdn.wetsuitoutlet.co.uk/images/2017-Gill-Coastal-Racer-Jacket-Blue-Graphite-Cr11J---correct.jpg";
            product.Description = "The Performance cut of the coastal racer jacket makes it ideal for fast paced regatta racing without commpromising any of the features you'd expect to see on a coastal garment. Made for 3 dot laminated fabric, creating a waterproof, windproof and breathable sheel that is incredibly comfortable to wear.";
            product.Category = catYacht;
            product.AddedToShop = DateTime.Now;
            product.Price = 120;

            context.Products.Add(product);


            product = new Product();
            product.Name = "AEGIR OCEAN DRY TOP";
            product.PictureUrl = "https://cdn.wetsuitoutlet.co.uk/images/32006-1.jpg";
            product.Description = "An essential waterproof, breathable dry top with an adjustable waterproof rubber neck and cuffs for maximum protection from the cold water. The top is designed for professional open-ocean racers and adventurous seafarers who want unrestricted movement during the toughest ocean races. The 3-ply Helly Tech® professional fabric is waterproof, breathable and windproof with fully sealed seams. The dry top features a fleece-lined collar and hand warmer pockets, in addition to double cuffs and a hi-vis hood for great visibility at sea.";
            product.Category = catYacht;
            product.Price = 599;
            product.AddedToShop = DateTime.Now;
            context.Products.Add(product);

            product = new Product();
            product.Name = "REGATTA RACE TIMER WATCH RED";
            product.PictureUrl = "https://cdn.wetsuitoutlet.co.uk/images/w014-red.jpg";
            product.Description = "With the largest and clearest display currently available, the Gill Regatta Race timer gives you no excuse for being late to the mark. Our exclusive design features a dot matrix display for greater definition and has a combined wrist / mast / bulkhead fixing with no spare mounts required.";
            product.Category = catAccesories;
            product.Price = 76.50m;
            product.AddedToShop = DateTime.Now;
            context.Products.Add(product);

            product = new Product();
            product.Name = "MARINE TOOL TITANIUM MT007 RED";
            product.PictureUrl = "https://cdn.wetsuitoutlet.co.uk/images/mt007-red.jpg";
            product.Description = "Functional folding yachtsman tool for on-board maintenance and emergency use. Features a G10 composite handle for wet and dry grip and all tools are made using marine grade 420 Stainless Steel with a Titanium coating for greater corrosion resistance. Supplied with a protective pouch with belt loop.";
            product.Category = catAccesories;
            product.Price = 22.50m;
            product.AddedToShop = DateTime.Now;
            context.Products.Add(product);

            product = new Product();
            product.Name = "I4 STORM HOOD IN BLACK";
            product.PictureUrl = "https://cdn.wetsuitoutlet.co.uk/images/ht23-black.jpg";
            product.Description = "A technical hybrid balaclava combining breathable, stretch thermal fabric with windproof softshell.";
            product.Category = catGhh;
            product.Price = 17m;
            product.AddedToShop = DateTime.Now;
            context.Products.Add(product);

            product = new Product();
            product.Name = "WINDWARD 1.5MM NEOPRENE SAILING GLOVE";
            product.PictureUrl = "https://cdn.wetsuitoutlet.co.uk/images/windward-sailing-glove-GL1247-front.jpg";
            product.Description = "The Gul Windward sailing glove has been designed using 1.5mm double lined dura flex neoprene, including heat retention polyproplene hollow fiber liner, keeping your hands warm in the most exstreme conditions. The DURATEX palm and knuckles increase durability and wear. Featuring POWERGRIP high power grip palm.";
            product.Category = catGhh;
            product.Price = 24;
            product.AddedToShop = DateTime.Now;
            context.Products.Add(product);

            product = new Product();
            product.Name = "PERFORMANCE SHORT FINGER GLOVES";
            product.PictureUrl = "https://cdn.wetsuitoutlet.co.uk/images/AS0832-black.jpg";
            product.Description = "The higher-specification Performance Gloves feature a high grip palm in durable Clarino® PU fabric and heavily reinforced articulated fingers to protect against rope burn. Constructed with pre-curved fingers for increased flexibility and dexterity. The elasticated back of hand ensures flexibility whilst the easy pull on wrist tab and Velcro® secured wrist tab provide quick, secure donning and removal. A hard wearing, durable glove designed to withstand frequent use by an active racing sailor";
            product.Category = catGhh;
            product.Price = 24;
            product.AddedToShop = DateTime.Now;
            context.Products.Add(product);

            product = new Product();
            product.Name = "DYNAMIC SMOCK ";
            product.PictureUrl = "https://cdn.wetsuitoutlet.co.uk/images/SX0020-yell-ss-3.jpg";
            product.Description = "Modern Sailboat racing has evolved into a high adrenaline, highly active performance sport. Technology at the top level does not end at yacht design: it has driven the need for complimentary equipment to help the boat go faster. Equipment such as sails, ropes, deck hardware and now clothing has emerged which is technologically advanced , ultra-lightweight and innovative. Musto has recognised this need and developed the dynamic System to meet the demands of the fast-paced professional sailing circuit.";
            product.Category = catSportsboat;
            product.Price = 99.99m;
            product.AddedToShop = DateTime.Now;
            context.Products.Add(product);

            base.Seed(context);
        }
    }
}