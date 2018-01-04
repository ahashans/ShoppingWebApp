namespace ShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteImageModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageId);
            
        }
    }
}
