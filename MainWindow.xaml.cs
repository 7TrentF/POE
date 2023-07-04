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
            // Create an instance of the AddRecipeWindow
            AddRecipeWindow arw = new AddRecipeWindow();

            // Show the AddRecipeWindow
            arw.Show();

            // Close the current window
            Close();
        }

        private void ListButton_Click_1(object sender, RoutedEventArgs e)
        { // Create an instance of the RecipeList window
            RecipeList rl = new RecipeList();

            // Show the RecipeList window
            rl.Show();

            // Close the current window
            Close();
        }

        private void DisplayButton_Click_1(object sender, RoutedEventArgs e)
        {
            // Create an instance of the DisplayRecipe window
            DisplayRecipe dr = new DisplayRecipe();

            // Show the DisplayRecipe window
            dr.Show();

            // Close the current window
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the current window, effectively exiting the application
            Close();
        }
    }
}
