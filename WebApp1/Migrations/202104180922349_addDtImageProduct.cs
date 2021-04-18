namespace WebApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDtImageProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DtImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DtImage");
        }
    }
}
