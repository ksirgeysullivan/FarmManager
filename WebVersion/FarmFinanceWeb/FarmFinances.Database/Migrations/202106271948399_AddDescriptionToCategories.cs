namespace FarmFinances.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Description");
        }
    }
}
