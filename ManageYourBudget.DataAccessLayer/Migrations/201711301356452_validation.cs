namespace ManageYourBudget.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ExpenditureCategories", new[] { "UserId" });
            AlterColumn("dbo.ExpenditureCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ExpenditureCategories", "ChartColor", c => c.String(nullable: false));
            AlterColumn("dbo.ExpenditureCategories", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Expenditures", "Title", c => c.String(nullable: false));
            CreateIndex("dbo.ExpenditureCategories", "UserId");
            AddForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ExpenditureCategories", new[] { "UserId" });
            AlterColumn("dbo.Expenditures", "Title", c => c.String());
            AlterColumn("dbo.ExpenditureCategories", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ExpenditureCategories", "ChartColor", c => c.String());
            AlterColumn("dbo.ExpenditureCategories", "Name", c => c.String());
            CreateIndex("dbo.ExpenditureCategories", "UserId");
            AddForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
