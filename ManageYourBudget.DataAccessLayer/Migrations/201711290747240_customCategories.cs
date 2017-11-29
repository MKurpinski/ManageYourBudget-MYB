namespace ManageYourBudget.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenditureCategories", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ExpenditureCategories", "UserId");
            AddForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenditureCategories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ExpenditureCategories", new[] { "UserId" });
            DropColumn("dbo.ExpenditureCategories", "UserId");
        }
    }
}
