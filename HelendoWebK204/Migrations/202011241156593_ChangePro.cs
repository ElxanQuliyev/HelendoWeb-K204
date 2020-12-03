namespace HelendoWebK204.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageUrl", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageUrl", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
