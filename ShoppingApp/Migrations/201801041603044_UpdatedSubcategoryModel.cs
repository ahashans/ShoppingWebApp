namespace ShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSubcategoryModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subcategories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subcategories", "Name", c => c.String());
        }
    }
}
