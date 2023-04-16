using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Count_Calories
{
    /// <summary>
    /// Logika interakcji dla klasy AddMeal.xaml
    /// </summary>
    public partial class AddMealWindow : Window
    {
        public int MealId { get; set; }
        
        public string InputName { get; set; }
        public List<Meal> meals;
        public List<Product> products;
        public Meal meal;
        public MealRepository ourMeals = new MealRepository(new CountCaloriesContext());

        public AddMealWindow(int id)
        {
        
         MealId = id;
            InitializeComponent();
           
            List<MealUI> mealsUI = new List<MealUI>();
            using (var context = new CountCaloriesContext())
            {
                meals = context.Meals.Include(m => m.Ingredients).ToList();
                products = context.Products.ToList();
            }

           meal = meals.Find(m => m.Id == id);

            foreach (var ingredient in meal.Ingredients)
            {

                MealUI mealUI = new MealUI();
                Product product = products.Find(x => x.Id == ingredient.ProductId);
                int weight = ingredient.IngredientWeight;
                mealUI.Name = product.Name;
                mealUI.Calories += product.Calories * weight / 100;
                mealUI.Fat += product.Fat * weight / 100;
                mealUI.Carbs += product.Carbs * weight / 100;
                mealUI.Protein += product.Protein * weight / 100;
                mealsUI.Add(mealUI);
                
            }
            
            ingredientsList.ItemsSource = mealsUI;
            inputName.Text = meal.Name;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string userInput = inputName.Text;

            meal.Name = userInput;
           

        }

        private void AddIngredient(object sender, RoutedEventArgs e)
        {
            ourMeals.UpdateMeal(meal);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ourMeals.UpdateMeal(meal);
        }
    }
}
