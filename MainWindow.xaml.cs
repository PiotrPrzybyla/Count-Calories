using System;
using System.Collections;
using System.Windows;
using System.Linq;
using System.Collections.Generic;

namespace Count_Calories
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            IList<Meal> meals;
            IList<UserMeal> userMeals;
            IList<Ingredient> ingredients;
            IList<Product> products;

            using (var context = new CountCaloriesContext())
            {
                ingredients = context.Ingredients.ToList();
                meals = context.Meals.ToList();
                userMeals = context.UserMeals.ToList();
                products = context.Products.ToList();
            }

            foreach (var userMeal in userMeals)
            {
                





            }


            
            mealsList.ItemsSource = userMeals;

        }
    }
}
