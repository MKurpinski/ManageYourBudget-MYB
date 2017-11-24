namespace ManageYourBudget.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenditureCategories", "ChartColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenditureCategories", "ChartColor");
        }
    }
}
