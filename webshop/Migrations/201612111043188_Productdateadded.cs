namespace webshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productdateadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AddedToShop", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AddedToShop");
        }
    }
}
