using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Count_Calories
{
    public class CountCaloriesContext : DbContext
    {
        // Your context has been configured to use a 'CountCaloriesContext' connection string from your application's
        // configuration file (App.config or Web.config). By default, this connection string targets the
        // 'Count_Calories.CountCaloriesContext' database on your LocalDb instance.
        //
        // If you wish to target a different database and/or database provider, modify the 'CountCaloriesContext'
        // connection string in the application configuration file.
        public CountCaloriesContext()
            : base("name=CountCaloriesContext")
        {
        }

        public DbSet<Meal> Meals { get; set; }


        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Product> Products { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class CountCaloriesDbInitializer : DropCreateDatabaseAlways<CountCaloriesContext>
    {
        protected override void Seed(CountCaloriesContext context)
        {
        }
    }
}