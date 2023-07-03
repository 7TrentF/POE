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

namespace POE_Application_WPF
{
    /// <summary>
    /// Interaction logic for DisplayRecipe.xaml
    /// </summary>
    public partial class DisplayRecipe : Window
    {
        public DisplayRecipe()
        {
            InitializeComponent();
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetRecipes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RecipeCollection.Instance.DisplayRecipeList();
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetRecipes();
        }

        private void Main_menu_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = (Button)sender;
            Recipe selectedRecipe = (Recipe)deleteButton.Tag;

            // Call a method to delete the recipe from your collection
            RecipeCollection.Instance.DeleteRecipe(selectedRecipe);

            // Update the UI by refreshing the item source
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetRecipes();
        }

    }
}
