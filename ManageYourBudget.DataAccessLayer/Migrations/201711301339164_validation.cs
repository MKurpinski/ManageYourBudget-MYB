namespace ManageYourBudget.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ExpenditureCategories", new[] { "UserId" });
            DropIndex("dbo.Expenditures", new[] { "UserId" });
            AlterColumn("dbo.ExpenditureCategories", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ExpenditureCategories", "ChartColor", c => c.String(nullable: false));
            AlterColumn("dbo.ExpenditureCategories", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Expenditures", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Expenditures", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ExpenditureCategories", "UserId");
            CreateIndex("dbo.Expenditures", "UserId");
            AddForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Expenditures", new[] { "UserId" });
            DropIndex("dbo.ExpenditureCategories", new[] { "UserId" });
            AlterColumn("dbo.Expenditures", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Expenditures", "Title", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.ExpenditureCategories", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ExpenditureCategories", "ChartColor", c => c.String());
            AlterColumn("dbo.ExpenditureCategories", "Name", c => c.String());
            CreateIndex("dbo.Expenditures", "UserId");
            CreateIndex("dbo.ExpenditureCategories", "UserId");
            AddForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
