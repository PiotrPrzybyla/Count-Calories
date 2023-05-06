namespace Count_Calories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMeals", "MealId", "dbo.Meals");
            DropIndex("dbo.UserMeals", new[] { "MealId" });
            DropTable("dbo.UserMeals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserMeals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MealId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        MealType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserMeals", "MealId");
            AddForeignKey("dbo.UserMeals", "MealId", "dbo.Meals", "Id", cascadeDelete: true);
        }
    }
}
