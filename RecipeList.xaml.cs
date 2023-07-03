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
    /// Interaction logic for RecipeList.xaml
    /// </summary>
    public partial class RecipeList : Window
    {

        public RecipeList()
        {
            InitializeComponent();

        }

        private void List_Button_Click(object sender, RoutedEventArgs e)
        {
            RecipeCollection.Instance.DisplayRecipeList();

            RecipeListView.Items.Clear(); // Clear the ListView

            int count = 1; // Initialize a count variable

            foreach (var recipe in RecipeCollection.Instance.GetRecipes())
            {
                string recipeText = recipe.RecipeName;
                int calories = recipe.GetTotalCalories(); // Get the total number of calories for the recipe

                RecipeListView.Items.Add(new { Count = count, RecipeName = recipeText, Calories = calories }); // Add count, recipe name, and calories to the anonymous object and add it to the ListView

                count++; // Increment the count
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void RecipeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RecipeListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RecipeListView.SelectedItem != null)
            {
                var selectedRecipe = (dynamic)RecipeListView.SelectedItem;
                string recipeName = selectedRecipe.RecipeName;

                // Display an input box asking the user to enter 1 to clear or 2 to reset the recipe
                string input = Microsoft.VisualBasic.Interaction.InputBox($"Enter" + "\n 1. to clear the recipe or" + $"\n 2. to reset the recipe: {recipeName}", "Input");

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            // Clear the recipe based on the user's choice
                            selectedRecipe.ClearRecipe();
                            break;
                        case 2:
                            // Reset the recipe based on the user's choice
                            selectedRecipe.ResetQuantities();

                            break;
                        default:
                            MessageBox.Show("Invalid choice. Please enter 1 to clear or 2 to reset the recipe.", "Error");
                            break;
                    }

                    // Refresh the ListView to reflect the changes
                    RefreshRecipeListView();
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid choice.", "Error");
                }
            }
        }

        private void RefreshRecipeListView()
        {
            RecipeListView.Items.Clear();
            int count = 1;

            foreach (var recipe in RecipeCollection.Instance.GetRecipes())
            {
                string recipeText = recipe.RecipeName;
                int calories = recipe.GetTotalCalories();

                RecipeListView.Items.Add(new { Count = count, RecipeName = recipeText, Calories = calories });
                count++;
            }
        }

    }
}
