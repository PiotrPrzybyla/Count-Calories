using System;
using System.Collections;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Controls;

namespace Count_Calories
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MealRepository ourMeals = new MealRepository(new CountCaloriesContext());
        public UserMealRepository ourUserMeals = new UserMealRepository(new CountCaloriesContext());


        public MainWindow()
        {
            InitializeComponent();
            List<Meal> meals;
            List<UserMeal> userMeals;
            List<Ingredient> ingredients;
            List<Product> products;
            List<MealUI> mealsUI = new List<MealUI>();

            using (var context = new CountCaloriesContext())
            {
                ingredients = context.Ingredients.ToList();
                meals = context.Meals.Include(m => m.Ingredients).ToList();
                userMeals = context.UserMeals.ToList();
                products = context.Products.ToList();
            }

            foreach (var userMeal in userMeals)
            {

                MealUI mealUI = new MealUI();
                mealUI.Name = userMeal.Meal.Name;
                mealUI.Calories = 0;
                mealUI.Fat = 0;
                mealUI.Carbs = 0;
                mealUI.Protein = 0;
                mealUI.ID = userMeal.MealId;
              
                foreach (var ingredient in userMeal.Meal.Ingredients.ToList())
                {
                    int weight = ingredient.IngredientWeight;
                    Product product = products.Find(x => x.Id == ingredient.ProductId);
                    mealUI.Calories += product.Calories * weight / 100;
                    mealUI.Fat += product.Fat * weight / 100;
                    mealUI.Carbs += product.Carbs * weight / 100;
                    mealUI.Protein += product.Protein * weight / 100;
                }
                mealsUI.Add(mealUI);
            }
            mealsList.ItemsSource = mealsUI;
        }

        private void EditMeal(object sender, RoutedEventArgs e)
        {

            AddMealWindow newWindow = new AddMealWindow((mealsList.SelectedItem as MealUI).ID);
            newWindow.Show();

        }

        private void DeleteMeal(object sender, RoutedEventArgs e)
        {
            ourUserMeals.DeleteUserMeal((mealsList.SelectedItem as MealUI).ID);
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        private void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            AddMealWindow newWindow = new AddMealWindow();
            newWindow.Show();
            Close();
        }
    }
}
