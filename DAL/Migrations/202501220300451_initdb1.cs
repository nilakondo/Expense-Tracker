namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Budgets", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Budgets", "Amount");
        }
    }
}
