namespace Count_Calories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MealId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    IngredientWeight = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.MealId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Meals",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MealName = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserMeals",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MealId = c.Int(nullable: false),
                    Date = c.DateTime(nullable: false),
                    MealType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .Index(t => t.MealId);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Calories = c.Int(nullable: false),
                    Carbs = c.Int(nullable: false),
                    Fat = c.Int(nullable: false),
                    Protein = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Ingredients", "MealId", "dbo.Meals");
            DropForeignKey("dbo.UserMeals", "MealId", "dbo.Meals");
            DropIndex("dbo.UserMeals", new[] { "MealId" });
            DropIndex("dbo.Ingredients", new[] { "ProductId" });
            DropIndex("dbo.Ingredients", new[] { "MealId" });
            DropTable("dbo.Products");
            DropTable("dbo.UserMeals");
            DropTable("dbo.Meals");
            DropTable("dbo.Ingredients");
        }
    }
}
