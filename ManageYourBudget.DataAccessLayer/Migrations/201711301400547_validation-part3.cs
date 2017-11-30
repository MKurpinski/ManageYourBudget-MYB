namespace ManageYourBudget.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationpart3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExpenditureCategories", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Expenditures", "Title", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenditures", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.ExpenditureCategories", "Name", c => c.String(nullable: false));
        }
    }
}
