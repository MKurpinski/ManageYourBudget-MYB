namespace ManageYourBudget.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ExpenditureCategories", new[] { "UserId" });
            DropIndex("dbo.Expenditures", new[] { "UserId" });
            AlterColumn("dbo.ExpenditureCategories", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Expenditures", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ExpenditureCategories", "UserId");
            CreateIndex("dbo.Expenditures", "UserId");
            AddForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Expenditures", new[] { "UserId" });
            DropIndex("dbo.ExpenditureCategories", new[] { "UserId" });
            AlterColumn("dbo.Expenditures", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ExpenditureCategories", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Expenditures", "UserId");
            CreateIndex("dbo.ExpenditureCategories", "UserId");
            AddForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
