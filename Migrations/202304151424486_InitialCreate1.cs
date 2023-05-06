namespace Count_Calories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "Name", c => c.String());
            DropColumn("dbo.Meals", "MealName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "MealName", c => c.String());
            DropColumn("dbo.Meals", "Name");
        }
    }
}
