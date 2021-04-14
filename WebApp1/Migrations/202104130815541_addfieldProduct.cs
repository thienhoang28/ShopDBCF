namespace WebApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfieldProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Category_Name", c => c.String(nullable: false));
            AddColumn("dbo.Products", "ModelCar", c => c.String());
            AddColumn("dbo.Products", "Imglink1", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Imglink2", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Imglink3", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Imglink4", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Imglink5", c => c.String(maxLength: 250));
            DropColumn("dbo.Categories", "DisplayText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "DisplayText", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Imglink5");
            DropColumn("dbo.Products", "Imglink4");
            DropColumn("dbo.Products", "Imglink3");
            DropColumn("dbo.Products", "Imglink2");
            DropColumn("dbo.Products", "Imglink1");
            DropColumn("dbo.Products", "ModelCar");
            DropColumn("dbo.Categories", "Category_Name");
        }
    }
}
