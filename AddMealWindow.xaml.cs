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
    /// Klasa obsługująca okno aplikacji służące do dodawania posiłku.
    /// </summary>
    public partial class AddMealWindow : Window
    {
        private int MealId { get; set; }
        public List<Meal> meals;
        public List<Product> products;
        public Meal meal;
        public MealRepository ourMeals = new MealRepository(new CountCaloriesContext());

        /// <summary>
        /// Konstruktor służący do inicjalizacji okna dla nowego posiłku.
        /// </summary>
        public AddMealWindow()
        {
            InitializeComponent();
            meal = new Meal();
            ourMeals.AddMeal(meal);
            MealId = meal.Id;
            CreateUI();

        }
        /// <summary>
        /// Konstruktor służący do inicjalizacji okna dla istniejącego posiłku.
        /// </summary>
        /// <param name="id">ID do edycji istniejącego posiłku</param>
        public AddMealWindow(int id)
        {
            MealId = id;
            InitializeComponent();
            CreateUI();
        }

        /// <summary>
        /// Tworzenie panelu UI, który będzie później wyświetlany.
        /// Przeszukanie bazy danych po MealId i przypisanie makro na podstawie zaczerpniętych informacji.
        /// </summary>
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

        /// <summary>
        /// Metoda na bieżąco zmieniająca nazwę składnika przy edycji odpowiadającego metodzie pola tekstowego.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string userInput = inputName.Text;
            meal.Name = userInput;
        }

        /// <summary>
        /// Metoda otwiera okno AddIngredient w celu dodania nowego składnika.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void AddIngredient(object sender, RoutedEventArgs e)
        {
            AddIngredient addIngredient = new AddIngredient(MealId);
            addIngredient.Show();
            Close();
        }

        /// <summary>
        /// Metoda uaktualnia posiłek w bazie, następnie otwiera okno główne uzupełnione o ten posiłek.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {            
            ourMeals.UpdateMeal(meal);
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            Close();
        }
    }
}
