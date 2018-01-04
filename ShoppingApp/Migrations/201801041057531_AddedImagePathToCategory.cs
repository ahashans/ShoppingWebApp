namespace ShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePathToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImagePath", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.Categories", "ImagePath");
        }
    }
}
