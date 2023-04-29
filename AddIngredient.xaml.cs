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
    /// Logika interakcji dla klasy AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        public int MealId { get; set; }
        Ingredient ingredient;
        Product product;
        public ProductRepository ourProducts = new ProductRepository(new CountCaloriesContext());
        public IngredientRepository ourIngredients = new IngredientRepository(new CountCaloriesContext());

        public AddIngredient(int mealID)
        {
            MealId = mealID;
            InitializeComponent();
            product = new Product();
            ingredient = new Ingredient();

        }
        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string productName = NameTextBox.Text;
            product.Name = productName;
        }

        private void WeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productWeight = int.Parse(WeightTextBox.Text);
            ingredient.IngredientWeight = productWeight;
        }
        private void CaloriesBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productCalories = int.Parse(CaloriesTextBox.Text);
            product.Calories = productCalories;
        }

        private void CarbsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productCarbs = int.Parse(CarbsTextBox.Text);
            product.Carbs = productCarbs;
        }
        private void FatBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productFat = int.Parse(FatTextBox.Text);
            product.Fat = productFat;
        }

        private void ProteinBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int productProtein = int.Parse(ProteinTextBox.Text);
            product.Protein = productProtein;
        }

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
    }

}
