namespace HelendoWebK204.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductChangeNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Notes");
        }
    }
}
