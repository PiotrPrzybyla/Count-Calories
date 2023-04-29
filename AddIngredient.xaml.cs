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
        public AddIngredient()
        {
            InitializeComponent();
        }


        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }

}
