namespace HelendoWebK204.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProTotalAmount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalAmount", c => c.Int(nullable: false));
        }
    }
}
