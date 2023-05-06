using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Count_Calories
{
    /// <summary>
    /// Klasa s�u��ca do obs�ugi bazy danych.
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
    /// Klasa s�u��ca do obs�ugi bazy danych.
    /// </summary>
    public class CountCaloriesDbInitializer : DropCreateDatabaseAlways<CountCaloriesContext>
    {
        protected override void Seed(CountCaloriesContext context)
        {
        }
    }
}