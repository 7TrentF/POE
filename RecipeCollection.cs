using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace POE_Application_WPF
{
      public class RecipeCollection
    {
        AddRecipeWindow arw = new AddRecipeWindow();
        private static RecipeCollection instance;

        private List<Recipe> recipes; // Private field to store the list of recipes

        public static RecipeCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecipeCollection();
                }
                return instance;
            }
        }

        private RecipeCollection()// Constructor to initialize the recipe collection
        {
            recipes = new List<Recipe>(); // Creates an empty list of recipes

            /*Author: Doyle, B. (2016) 
              title of the book: C♯ Programming: From problem analysis to program design.Boston, MA: Cengage Learning. pg 477
              accessed:  2 june 2023
            */
        }

        public async Task EnterRecipeAsync(string recipeName, int numIngredients, int numSteps)
        {
            Recipe recipe = new Recipe(recipeName); // Create a new Recipe object with the entered name
            Delegate d = new Delegate();
            MessageBox.Show("Enter the Details for the recipe", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            for (int i = 0; i < numIngredients; i++)
            {

                MessageBox.Show($"Enter the name of ingredient {i + 1}:", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                // Wait for the user to input data for the ingredient name asynchronously
                await WaitForTextBoxInput(arw.Ingredient_Name_TextBox);

                // Retrieve values from the textboxes in AddRecipeWindow
                string ingredientName = arw.Ingredient_Name_TextBox.Text;

                // Check if the ingredient name is populated
                if (string.IsNullOrWhiteSpace(ingredientName))
                {
                    MessageBox.Show("Please enter a valid ingredient name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show($"Enter the quantity of ingredient {i + 1}:", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                // Wait for the user to input data for the quantity asynchronously
                await WaitForTextBoxInput(arw.Quantity_TextBox);

                int quantity;
                if (!int.TryParse(arw.Quantity_TextBox.Text, out quantity))
                {
                    MessageBox.Show("Invalid input! Please enter a valid quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (quantity % 1 != 0)
                {
                    MessageBox.Show("Invalid input! Please enter a valid quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Retrieve values for other properties
                string unit = arw.Unit_Of_measurment_TextBox.Text;

                // Wait for the user to input data for calories asynchronously
                await WaitForTextBoxInput(arw.Calories_TextBox);

                int calories;
                if (!int.TryParse(arw.Calories_TextBox.Text, out calories))
                {
                    MessageBox.Show("Invalid input! Please enter a valid number of calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (calories % 1 != 0)
                {
                    MessageBox.Show("Invalid input! Please enter a valid number of calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int foodGroupNumber;
                if (!int.TryParse(arw.Food_Group_TextBox.Text, out foodGroupNumber))
                {
                    MessageBox.Show("Invalid input! Please enter a valid food group number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string foodGroup = recipe.GetFoodGroupName(foodGroupNumber);
                recipe.AddIngredient(ingredientName, quantity, unit, calories, foodGroup);
                recipe.OriginalQuantities.Add(quantity);

                // Clear the ingredient textboxes in the AddRecipeWindow after each iteration
                arw.ClearIngredientTextBoxes();
            }

            for (int i = 0; i < numSteps; i++)
            {
                string step = Interaction.InputBox($"\nEnter step {i + 1}:");
                recipe.AddStep(step);
            }

            int totalCalories = recipe.GetTotalCalories();

            if (totalCalories >= 300) // Check if the total calories exceed 300
            {
                d.NotifyUserExceededCalories(recipe.RecipeName, totalCalories);
            }

            MessageBox.Show("\nRecipe added successfully!");

            recipe.PrintRecipe();    // Calls PrintRecipe method from Recipe class and prints the current recipe.
            recipes.Add(recipe);     // Method that adds the current recipe to the list of recipes.


            // recipe.ResetQuantities();// Method that resets the quantities of all ingredients in the recipe to their original values.
            // recipe.ClearRecipe();    // Method that clears the  current recipe. 



            StringBuilder recipeNames = new StringBuilder("Recipe added:\n");
            foreach (Recipe r in recipes)
            {
                recipeNames.AppendLine(r.RecipeName);
            }
            MessageBox.Show(recipeNames.ToString(), "Added Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private Task WaitForTextBoxInput(TextBox textBox)
        {
            var tcs = new TaskCompletionSource<bool>();

            // Create a text changed event handler
            void textChangedEventHandler(object sender, TextChangedEventArgs e)
            {
                textBox.TextChanged -= textChangedEventHandler; // Unsubscribe the event handler
                tcs.SetResult(true); // Set the task completion source to signal completion
            }

            textBox.TextChanged += textChangedEventHandler; // Subscribe the event handler

            return tcs.Task;
        }

        public void DisplayRecipeList() // Displays a list of all recipes that the user added.
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes found.", "No Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            recipes.Sort((r1, r2) => r1.RecipeName.CompareTo(r2.RecipeName));// Sorts the recipes list in alphabetical order by comparing the recipe names using the CompareTo method.

            StringBuilder recipeList = new StringBuilder();
            foreach (Recipe recipe in recipes)
            {
                recipeList.AppendLine(recipe.RecipeName);
            }

            MessageBox.Show(recipeList.ToString(), "Recipe List", MessageBoxButton.OK, MessageBoxImage.Information);
            /*Author: Doyle, B. (2016) 
              title of the book: C♯ Programming: From problem analysis to program design.Boston, MA: Cengage Learning. pg 415-417
              accessed:  02 june 2023

              C#: Sort the elements in the arraylist (2021) GeeksforGeeks. 
              Available at: https://www.geeksforgeeks.org/c-sharp-sort-the-elements-in-the-arraylist/ 
             (Accessed: 02 June 2023). 
              */
        }


        public void DisplayRecipe(string RecipeName)// Display a specific recipe to the user
        {
            Recipe recipe = recipes.Find(r => r.RecipeName.ToLower() == RecipeName.ToLower());

            /*
             * C#: Array.find() method (2022) GeeksforGeeks.
             * Available at: https://www.geeksforgeeks.org/c-sharp-array-find-method/ 
             * (Accessed: 03 June 2023). 
             */
            if (recipe == null)
            {
                MessageBox.Show("Recipe not found.", "Recipe Not Found", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder recipeDetails = new StringBuilder();
            recipeDetails.AppendLine($"Recipe Name: {recipe.RecipeName}");
            recipeDetails.AppendLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                recipeDetails.AppendLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }
            recipeDetails.AppendLine("Steps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                recipeDetails.AppendLine($"{i + 1}. {recipe.Steps[i]}");
            }

            MessageBox.Show(recipeDetails.ToString(), "Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
