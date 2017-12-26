namespace PMS.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_required_in_product_model : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductCode", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(maxLength: 256));
            AlterColumn("dbo.Products", "ProductCode", c => c.String());
        }
    }
}
