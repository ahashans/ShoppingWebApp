namespace ShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedSubcategoryModelAndLinkedItToCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImagePath = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubcategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropTable("dbo.Subcategories");
        }
    }
}
