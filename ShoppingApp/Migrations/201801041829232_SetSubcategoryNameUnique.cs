namespace ShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetSubcategoryNameUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subcategories", "Name", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.Subcategories", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subcategories", new[] { "Name" });
            AlterColumn("dbo.Subcategories", "Name", c => c.String(nullable: false));
        }
    }
}
