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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POE_Application_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddRecipeWindow arw = new AddRecipeWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow arw = new AddRecipeWindow();
            arw.Show();
            Close();
        }

        private void ListButton_Click_1(object sender, RoutedEventArgs e)
        {
            RecipeList rl = new RecipeList();
            rl.Show();
            Close();
        }

        private void DisplayButton_Click_1(object sender, RoutedEventArgs e)
        {
            DisplayRecipe dr = new DisplayRecipe();
            dr.Show();
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
