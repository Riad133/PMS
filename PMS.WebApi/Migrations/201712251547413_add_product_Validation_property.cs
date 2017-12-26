namespace PMS.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_product_Validation_property : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
