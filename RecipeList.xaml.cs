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
            // Create a new instance of the MainWindow
            MainWindow mw = new MainWindow();

            // Show the MainWindow
            mw.Show();

            // Close the current window (DisplayRecipe window)
            Close();
        }

       

        private void RefreshRecipeListView()
        {
            // Clear the ListView before populating it with new items
            RecipeListView.Items.Clear();

            // Initialize a count variable to track the recipe number
            int count = 1;

            // Iterate through each recipe in the RecipeCollection
            foreach (var recipe in RecipeCollection.Instance.GetRecipes())
            {
                // Extract the recipe name and total calories for the current recipe
                string recipeText = recipe.RecipeName;
                int calories = recipe.GetTotalCalories();

                // Create a new anonymous object representing the recipe item to be added to the ListView
                // The object contains properties for the recipe number, recipe name, and total calories
                RecipeListView.Items.Add(new { Count = count, RecipeName = recipeText, Calories = calories });

                // Increment the count for the next recipe
                count++;
            }
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = RecipeNameTextBox.Text;

            // Search for the recipe by name
            Recipe foundRecipe = RecipeCollection.Instance.GetRecipes().FirstOrDefault(r => r.RecipeName.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));

            if (foundRecipe != null)
            {
                // Clear the ListView
                RecipeListView.Items.Clear();

                // Add the found recipe to the ListView
                RecipeListView.Items.Add(foundRecipe);

                // Set the selected recipe as the current item in the ListView
                RecipeListView.SelectedItem = foundRecipe;
            }
            else
            {
                MessageBox.Show("Recipe not found.", "Recipe Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RecipeNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // When the RecipeNameTextBox receives focus (user clicks or tabs into it),
            // clear the text in the TextBox by setting it to an empty string.
            RecipeNameTextBox.Text = string.Empty;
        }

        private void RecipeListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RecipeListView.SelectedItem != null)
            {
                var selectedRecipe = (dynamic)RecipeListView.SelectedItem;
                string recipeName = selectedRecipe.RecipeName;

                if (selectedRecipe.CalorieInformation != null)
                {
                    // Call the CalorieInformation method in the Recipe class
                    selectedRecipe.CalorieInformation();
                    
                }
                else
                {
                    MessageBox.Show($"No calorie information available for recipe: {recipeName}", "Error");
                }

                // Refresh the ListView to reflect any changes
                RefreshRecipeListView();
            }
        }

        private void GridViewColumnHeader_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Check if the clicked element is the "Total Calories" header
            if (sender is GridViewColumnHeader columnHeader && columnHeader.Content.ToString() == "Total Calories")
            {
                // Retrieve the data item (recipe) associated with the clicked header
                if (columnHeader.Column.DisplayMemberBinding is Binding binding && binding.Path.Path == "Calories")
                {
                    if (binding.Source is Recipe recipe)
                    {
                        // Call the CalorieInformation() method of the recipe
                        recipe.CalorieInformation();
                    }
                }
            }
        }

        private void RecipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
