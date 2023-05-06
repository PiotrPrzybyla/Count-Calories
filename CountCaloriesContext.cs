using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Count_Calories
{
    /// <summary>
    /// Klasa s³u¿¹ca do obs³ugi bazy danych.
    /// </summary>
    public class CountCaloriesContext : DbContext
    {
        public CountCaloriesContext()
            : base("name=CountCaloriesContext")
        {
        }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Product> Products { get; set; }

    }

    /// <summary>
    /// Klasa s³u¿¹ca do obs³ugi bazy danych.
    /// </summary>
    public class CountCaloriesDbInitializer : DropCreateDatabaseAlways<CountCaloriesContext>
    {
        protected override void Seed(CountCaloriesContext context)
        {
        }
    }
}