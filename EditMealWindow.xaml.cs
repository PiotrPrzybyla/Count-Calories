using System;
using System.Collections.Generic;
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
    public partial class EditMealWindow : Window
    {
        private int MealId { get; set; }
        public List<Meal> meals;
        public IEnumerable<Ingredient> ingredients;
        public List<UserMeal> userMeals;
        public List<Product> products;
        public List<Ingredient> newIngredients = new List<Ingredient>();

        public Meal meal;
        public Meal newMeal;
        public UserMeal usermeal;
        public UserMealRepository ourUserMeals = new UserMealRepository(new CountCaloriesContext());
        public MealRepository ourMeals = new MealRepository(new CountCaloriesContext());
        public IngredientRepository ourIngredients = new IngredientRepository(new CountCaloriesContext());

        public EditMealWindow(int id)
        {
            InitializeComponent();
            CreateUI(id);
        }
        private void CreateUI(int id)
        {
            List<MealUI> mealsUI = new List<MealUI>();

            using (var context = new CountCaloriesContext())
            {
                userMeals = context.UserMeals.ToList();
                meals = context.Meals.ToList();
                ingredients= context.Ingredients.ToList().Where(x => x.MealId == meal.Id);
                products = context.Products.ToList();
            }

            usermeal = userMeals.Find(m => m.Id == id);
            meal = meals.Find(m => m.Id == usermeal.MealId);

            foreach (var ingredient in ingredients)
            {
                MealUI mealUI = new MealUI();
                Product product = products.Find(x => x.Id == ingredient.ProductId);
                int weight = ingredient.IngredientWeight;
                mealUI.Name = product.Name;
                mealUI.Calories = product.Calories * weight / 100;
                mealUI.Fat = product.Fat * weight / 100;
                mealUI.Carbs = product.Carbs * weight / 100;
                mealUI.Protein = product.Protein * weight / 100;
                mealsUI.Add(mealUI);
            }


            newMeal = new Meal();
            ourMeals.AddMeal(newMeal);
            newMeal.Name=meal.Name;
            MealId = newMeal.Id;



            List<Ingredient> brandNewIngredients = new List<Ingredient>(ingredients);

            foreach (var ingredient in brandNewIngredients)
            {
                ingredient.MealId = newMeal.Id;
                newIngredients.Add(ingredient);
                ourIngredients.AddIngredient(ingredient);
            }

            newMeal.Ingredients=newIngredients;

            ourMeals.UpdateMeal(newMeal);
            usermeal.MealId = MealId;
            ourUserMeals.UpdateUserMeal(usermeal);
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
            AddIngredient addIngredient = new AddIngredient(MealId);
            addIngredient.Show();
            Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            usermeal = new UserMeal();
            usermeal.MealId = MealId;
            usermeal.Date = DateTime.Now;
            ourUserMeals.AddUserMeal(usermeal);

            ourMeals.UpdateMeal(meal);
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            Close();
        }
    }
}
