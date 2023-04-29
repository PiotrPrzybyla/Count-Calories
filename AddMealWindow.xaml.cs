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
    public partial class AddMealWindow : Window
    {
        private int MealId { get; set; }
        private int UserMealId { get; set; }
        public List<Meal> meals;
        public List<Product> products;
        public Meal meal;
        public UserMeal usermeal;
        public UserMealRepository ourUserMeals = new UserMealRepository(new CountCaloriesContext());
        public MealRepository ourMeals = new MealRepository(new CountCaloriesContext());

        public AddMealWindow()
        {
            InitializeComponent();
            meal = new Meal();
            ourMeals.AddMeal(meal);
            MealId = meal.Id;
            CreateUI();

        }
        public AddMealWindow(int mealID, int userMealID)
        {
            MealId=mealID;
            UserMealId = userMealID;
            InitializeComponent();
            CreateUI();

        }

        public AddMealWindow(int id)
        {
            MealId = id;
            InitializeComponent();
            CreateUI();
        }
        private void CreateUI()
        {
            List<MealUI> mealsUI = new List<MealUI>();
            using (var context = new CountCaloriesContext())
            {
                meals = context.Meals.Include(m => m.Ingredients).ToList();
                products = context.Products.ToList();
            }

            meal = meals.Find(m => m.Id == MealId);

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
            AddIngredient addIngredient = new AddIngredient(MealId);
            addIngredient.Show();
            Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    usermeal = ourUserMeals.GetUserMealById(UserMealId);
            //    usermeal.MealId = MealId;
            //    usermeal.Date = DateTime.Now;
            //    ourUserMeals.UpdateUserMeal(usermeal);
            //}
            //catch 
            //{

            //}
            //if (isExisting)
            //{
            //    ourUserMeals.UpdateUserMeal(usermeal);
            //}
            //else
            //{
            //    usermeal = new UserMeal();
            //    usermeal.MealId = MealId;
            //    usermeal.Date = DateTime.Now;
            //    ourUserMeals.AddUserMeal(usermeal);
            //}
            //ourMeals.UpdateMeal(meal);
            //MainWindow newWindow = new MainWindow();
            //newWindow.Show();
            //Close();
        }
    }
}
