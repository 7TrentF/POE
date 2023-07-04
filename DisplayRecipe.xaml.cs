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
        private string filterIngredientName;
        private string filterFoodGroup;
        private int filterMaxCalories;
        public DisplayRecipe()
        {
            InitializeComponent();

            // Set the item source of the RecipeItemsControl to the recipes in the RecipeCollection
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetRecipes();
        }
        public void DisplayRecipeList()
        {
            List<Recipe> filteredRecipes = RecipeCollection.Instance.FilterRecipes();


            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("No recipes found.", "No Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder recipeList = new StringBuilder();
            foreach (Recipe recipe in filteredRecipes)
            {
                recipeList.AppendLine(recipe.RecipeName);
            }

            MessageBox.Show(recipeList.ToString(), "Recipe List", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Create the filter menu
            var filterMenu = new ContextMenu();

            // Add the filter options to the menu
            var ingredientNameMenuItem = new MenuItem() { Header = "Filter by Ingredient Name", Tag = "IngredientName" };
            ingredientNameMenuItem.Click += FilterMenuItem_Click;
            filterMenu.Items.Add(ingredientNameMenuItem);

            var foodGroupMenuItem = new MenuItem() { Header = "Filter by Food Group", Tag = "FoodGroup" };
            foodGroupMenuItem.Click += FilterMenuItem_Click;
            filterMenu.Items.Add(foodGroupMenuItem);

            var maxCaloriesMenuItem = new MenuItem() { Header = "Filter by Max Calories", Tag = "MaxCalories" };
            maxCaloriesMenuItem.Click += FilterMenuItem_Click;
            filterMenu.Items.Add(maxCaloriesMenuItem);

            // Show the filter menu
            var button = (Button)sender;
            filterMenu.PlacementTarget = button;
            filterMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            filterMenu.IsOpen = true;
        }

        private void FilterMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var tag = menuItem.Tag.ToString();

            switch (tag)
            {
                case "IngredientName":
                    // Prompt the user to enter the ingredient name
                    var ingredientName = Microsoft.VisualBasic.Interaction.InputBox("Enter the Ingredient Name:", "Filter by Ingredient Name");
                    // Apply the ingredient name filter
                    ApplyIngredientNameFilter(ingredientName);
                    break;
                case "FoodGroup":
                    // Prompt the user to select the food group
                    var selectedFoodGroup = Microsoft.VisualBasic.Interaction.InputBox("Select the Food Group:", "Filter by Food Group");
                    // Apply the food group filter
                    ApplyFoodGroupFilter(selectedFoodGroup);
                    break;
                case "MaxCalories":
                    // Prompt the user to enter the maximum calories
                    var maxCaloriesString = Microsoft.VisualBasic.Interaction.InputBox("Enter the Maximum Calories:", "Filter by Max Calories");
                    int maxCalories;
                    if (int.TryParse(maxCaloriesString, out maxCalories))
                    {
                        // Apply the max calories filter
                        ApplyMaxCaloriesFilter(maxCalories);
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number.", "Error");
                    }
                    break;
            }
        }


        private void ApplyIngredientNameFilter(string ingredientName)
        {
            // Set the filter ingredient name
            filterIngredientName = ingredientName;

            // Call the filter method of the RecipeCollection to update the list of recipes
            RecipeCollection.Instance.FilterRecipesByIngredientName(filterIngredientName);

            // Update the item source of the RecipeItemsControl to reflect the updated recipe list
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetFilteredRecipes();
        }

        private void ApplyFoodGroupFilter(string foodGroup)
        {
            // Set the filter food group
            filterFoodGroup = foodGroup;

            // Call the filter method of the RecipeCollection to update the list of recipes
            RecipeCollection.Instance.FilterRecipesByFoodGroup(filterFoodGroup);

            // Update the item source of the RecipeItemsControl to reflect the updated recipe list
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetFilteredRecipes();
        }

        private void ApplyMaxCaloriesFilter(int maxCalories)
        {
            // Set the filter max calories
            filterMaxCalories = maxCalories;

            // Call the filter method of the RecipeCollection to update the list of recipes
            RecipeCollection.Instance.FilterRecipesByMaxCalories(filterMaxCalories);

            // Update the item source of the RecipeItemsControl to reflect the updated recipe list
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetFilteredRecipes();
        }



        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
           

            // Call the reset method of the RecipeCollection to clear the filters
            RecipeCollection.Instance.ResetFilters();

            // Update the item source of the RecipeItemsControl to display all recipes
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetRecipes();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Call the DisplayRecipeList method of the RecipeCollection to update the list of recipes
            RecipeCollection.Instance.DisplayRecipeList();

            // Update the item source of the RecipeItemsControl to reflect the updated recipe list
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetRecipes();
        }

        private void Main_menu_button_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the MainWindow
            MainWindow mw = new MainWindow();

            // Show the MainWindow
            mw.Show();

            // Close the current DisplayRecipe window
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the delete button that triggered the event
            Button deleteButton = (Button)sender;

            // Get the corresponding Recipe object from the Tag property of the delete button
            Recipe selectedRecipe = (Recipe)deleteButton.Tag;

            // Call a method to delete the recipe from your collection (assumed to be implemented in RecipeCollection)
            RecipeCollection.Instance.DeleteRecipe(selectedRecipe);

            // Update the UI by refreshing the item source of the RecipeItemsControl
            RecipeItemsControl.ItemsSource = RecipeCollection.Instance.GetRecipes();

        }

        private void IngredientNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MaxCaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
