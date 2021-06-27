﻿namespace FarmFinances.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendors", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "Name", c => c.String());
        }
    }
}
