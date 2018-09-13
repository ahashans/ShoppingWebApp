namespace ShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedProductModelWith1MRelationToSubcategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(),
                        Description = c.String(nullable: false, maxLength: 450),
                        StockCount = c.Int(nullable: false),
                        ImagePath1 = c.String(),
                        ImagePath2 = c.String(),
                        SubcategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.SubcategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubcategoryId", "dbo.Subcategories");
            DropIndex("dbo.Products", new[] { "SubcategoryId" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropTable("dbo.Products");
        }
    }
}
