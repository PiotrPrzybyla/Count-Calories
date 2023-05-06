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
    /// <summary>
    /// Klasa obsługująca okno do dodawania składników.
    /// </summary>
    public partial class AddIngredient : Window
    {
        public int MealId { get; set; }
        Ingredient ingredient;
        Product product;
        public ProductRepository ourProducts = new ProductRepository(new CountCaloriesContext());
        public IngredientRepository ourIngredients = new IngredientRepository(new CountCaloriesContext());

        /// <summary>
        /// Konstruktor służący do dodania składnika w sposób podstawowy.
        /// </summary>
        /// <param name="mealId">ID posiłku do którego dodajemy składnik.</param>
        public AddIngredient(int mealID)
        {
            MealId = mealID;
            InitializeComponent();
            product = new Product();
            ingredient = new Ingredient();
        }

        /// <summary>
        /// Konstruktor służący do dodania składnika gdy chcemy skorzystać z API.
        /// </summary>
        /// <param name="mealId">ID posiłku do którego dodajemy składnik.</param>
        /// <param name="readyProduct">Produkt pobrany z API.</param>
        public AddIngredient(int mealID, Product readyProduct)
        {
            MealId = mealID;
            product = readyProduct;
            InitializeComponent();
            NameTextBox.Text = product.Name;
            CaloriesTextBox.Text = product.Calories.ToString();
            CarbsTextBox.Text = product.Carbs.ToString();
            FatTextBox.Text = product.Fat.ToString();
            ProteinTextBox.Text = product.Protein.ToString();

            ingredient = new Ingredient();

        }

        /// <summary>
        /// Metoda na bieżąco zmieniająca nazwę składnika przy edycji odpowiadającego metodzie pola tekstowego.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string productName = NameTextBox.Text;
            product.Name = productName;
        }

        /// <summary>
        /// Metoda na bieżąco zmieniająca wagę składnika przy edycji odpowiadającego metodzie pola tekstowego.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void WeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productWeight;
            int.TryParse(WeightTextBox.Text, out productWeight);
            ingredient.IngredientWeight = productWeight;
        }

        /// <summary>
        /// Metoda na bieżąco zmieniająca liczbę kalorii składnika przy edycji odpowiadającego metodzie pola tekstowego.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void CaloriesBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productCalories;
            int.TryParse(CaloriesTextBox.Text, out productCalories);
            product.Calories = productCalories;
        }

        /// <summary>
        /// Metoda na bieżąco zmieniająca zawartość węgli składnika przy edycji odpowiadającego metodzie pola tekstowego.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void CarbsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productCarbs;
            int.TryParse(CarbsTextBox.Text, out productCarbs);
            product.Carbs = productCarbs;
        }

        /// <summary>
        /// Metoda na bieżąco zmieniająca zawartość tłuszczu składnika przy edycji odpowiadającego metodzie pola tekstowego.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void FatBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productFat;
            int.TryParse(FatTextBox.Text, out productFat);
            product.Fat = productFat;
        }


        /// <summary>
        /// Metoda na bieżąco zmieniająca zawartość białka składnika przy edycji odpowiadającego metodzie pola tekstowego.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void ProteinBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productProtein;
            int.TryParse(ProteinTextBox.Text, out productProtein);
            product.Protein = productProtein;
        }

        /// <summary>
        /// Metoda dodająca składnik do posiłku, otwierająca nowe okno AddMeal.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ourProducts.AddProduct(product);
            ingredient.ProductId = product.Id;
            ingredient.MealId = MealId;
            ourIngredients.AddIngredient(ingredient);
            AddMealWindow newWindow = new AddMealWindow(MealId);
            newWindow.Show();
            Close();
        }

        /// <summary>
        /// Metoda otwierająca okno umożliwiające dodanie składniku z API.
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Argument zdarzenia zawierające szczegółowe informacje na jego temat</param>
        private void connectToApi(object sender, RoutedEventArgs e)
        {
            AddFromApi newWindow = new AddFromApi(MealId);
            newWindow.Show();
            Close();

        }
    }

}
