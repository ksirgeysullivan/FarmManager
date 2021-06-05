namespace FarmFinances.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentCategory = c.String(),
                        ChildCategory = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_ID = c.Int(),
                        Vendor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Vendors", t => t.Vendor_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Vendor_ID);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Vendor_ID", "dbo.Vendors");
            DropForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "Vendor_ID" });
            DropIndex("dbo.Expenses", new[] { "Category_ID" });
            DropTable("dbo.Vendors");
            DropTable("dbo.Expenses");
            DropTable("dbo.Categories");
        }
    }
}
