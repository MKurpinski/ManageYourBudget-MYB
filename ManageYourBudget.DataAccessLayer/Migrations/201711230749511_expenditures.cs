namespace ManageYourBudget.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expenditures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenditureCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenditures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenditureCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenditures", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Expenditures", "CategoryId", "dbo.ExpenditureCategories");
            DropIndex("dbo.Expenditures", new[] { "UserId" });
            DropIndex("dbo.Expenditures", new[] { "CategoryId" });
            DropTable("dbo.Expenditures");
            DropTable("dbo.ExpenditureCategories");
        }
    }
}
