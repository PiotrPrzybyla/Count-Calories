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
using static System.Net.WebRequestMethods;

namespace Count_Calories
{
    /// <summary>
    /// Logika interakcji dla klasy AddFromApi.xaml
    /// </summary>
    public partial class AddFromApi : Window
    {
        string name;
        ShootAPI api;
        ApiProduct productData;
        Product readyProduct;
        int mealId;

        public AddFromApi(int mealId)
        {
            this.mealId = mealId;
            InitializeComponent();
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string productName = NameTextBox.Text;
            name = productName;
        }

        private async void tryToFind(object sender, RoutedEventArgs e)
        {
            api = new ShootAPI();
            string apiUrl = "https://api.api-ninjas.com/v1/nutrition?query=" + name;
            productData=await api.GetDataFromApiAsync(apiUrl, "GGPyaHg/nELgs2atZNBetQ==2ITAXrvUezs3LTWu");
            readyProduct = new Product();
            readyProduct.Name = productData.name;
            readyProduct.Protein = (int)productData.protein_g;
            readyProduct.Fat = (int)productData.fat_total_g;
            readyProduct.Carbs = (int)productData.carbohydrates_total_g;
            readyProduct.Calories = (int)productData.calories;
            AddIngredient newWindow = new AddIngredient(mealId, readyProduct);
            newWindow.Show();
            Close();
        }
    }
}
