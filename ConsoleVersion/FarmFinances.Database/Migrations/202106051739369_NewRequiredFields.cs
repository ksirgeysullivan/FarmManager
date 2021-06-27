namespace FarmFinances.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewRequiredFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "Vendor_ID", "dbo.Vendors");
            DropIndex("dbo.Expenses", new[] { "Category_ID" });
            DropIndex("dbo.Expenses", new[] { "Vendor_ID" });
            AlterColumn("dbo.Categories", "ParentCategory", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "ChildCategory", c => c.String(nullable: false));
            AlterColumn("dbo.Expenses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Expenses", "Category_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "Vendor_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Expenses", "Category_ID");
            CreateIndex("dbo.Expenses", "Vendor_ID");
            AddForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "Vendor_ID", "dbo.Vendors", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Vendor_ID", "dbo.Vendors");
            DropForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "Vendor_ID" });
            DropIndex("dbo.Expenses", new[] { "Category_ID" });
            AlterColumn("dbo.Expenses", "Vendor_ID", c => c.Int());
            AlterColumn("dbo.Expenses", "Category_ID", c => c.Int());
            AlterColumn("dbo.Expenses", "Name", c => c.String());
            AlterColumn("dbo.Categories", "ChildCategory", c => c.String());
            AlterColumn("dbo.Categories", "ParentCategory", c => c.String());
            CreateIndex("dbo.Expenses", "Vendor_ID");
            CreateIndex("dbo.Expenses", "Category_ID");
            AddForeignKey("dbo.Expenses", "Vendor_ID", "dbo.Vendors", "ID");
            AddForeignKey("dbo.Expenses", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
