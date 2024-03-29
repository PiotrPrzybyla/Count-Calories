﻿using System;
using System.Collections;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Controls;

namespace Count_Calories
{
    /// <summary>
    /// Klasa obsługująca główne okno aplikacji.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MealRepository ourMeals = new MealRepository(new CountCaloriesContext());

        /// <summary>
        /// Konstruktor inicjalizujący okno.
        /// Tworzenie panelu UI, który będzie później wyświetlany.
        /// Przeszukanie bazy danych i wyświetlenie znalezionych posiłków.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            List<Meal> meals;
            List<Ingredient> ingredients;
            List<Product> products;
            List<MealUI> mealsUI = new List<MealUI>();

            using (var context = new CountCaloriesContext())
            {
                ingredients = context.Ingredients.ToList();
                meals = context.Meals.Include(m => m.Ingredients).ToList();
                products = context.Products.ToList();
            }

            foreach (var userMeal in meals)
            {

                MealUI mealUI = new MealUI();
                mealUI.Name = userMeal.Name;
                mealUI.Calories = 0;
                mealUI.Fat = 0;
                mealUI.Carbs = 0;
                mealUI.Protein = 0;
                mealUI.ID = userMeal.Id;
              
                foreach (var ingredient in userMeal.Ingredients.ToList())
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

        /// <summary>
        /// Metoda otwiera okno AddMeal, równocześnie przekazując mu ID posiłku do edycji.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void EditMeal(object sender, RoutedEventArgs e)
        {
            AddMealWindow newWindow = new AddMealWindow((mealsList.SelectedItem as MealUI).ID);
            newWindow.Show();
            Close();
        }

        /// <summary>
        /// Metoda otwiera okno główne, równocześnie usuwając wybrany posiłek.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void DeleteMeal(object sender, RoutedEventArgs e)
        {
            ourMeals.DeleteMeal((mealsList.SelectedItem as MealUI).ID);
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            Close();
        }

        /// <summary>
        /// Metoda otwiera okno AddMeal, w celu dodania nowego posiłku.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            AddMealWindow newWindow = new AddMealWindow();
            newWindow.Show();
            Close();
        }
    }
}
