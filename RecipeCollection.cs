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
        private static RecipeCollection instance; // Singleton instance of the RecipeCollection class
        private List<Recipe> recipes; // Private field to store the list of recipes

        public static RecipeCollection Instance
        {
            get
            {
                if (instance == null) // Check if the instance is null
                {
                    instance = new RecipeCollection(); // Create a new instance if it doesn't exist
                }
                return instance; // Return the instance
            }
        }

        private RecipeCollection()
        {
            recipes = new List<Recipe>(); // Creates an empty list of recipes
        }

        public List<Recipe> GetRecipes()
        {
            return recipes; // Return the list of recipes
        }

        public void EnterRecipeAsync(string recipeName, int numIngredients, int numSteps)
        {
            Recipe recipe = new Recipe(recipeName); // Create a new Recipe object with the entered name
            Delegate d = new Delegate(); // Create a new instance of the Delegate class (assuming this is a custom class)

            MessageBox.Show("Enter the Details for the recipe", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            for (int i = 0; i < numIngredients; i++)
            {
                // Prompt the user to enter the name of the ingredient
                string ingredientName = Interaction.InputBox($"Enter the name of ingredient {i + 1}:");

                double quantity;
                while (true)
                {
                    try
                    {
                        // Prompt the user to enter the quantity of the ingredient and convert it to double
                        quantity = Convert.ToDouble(Interaction.InputBox($"Enter the quantity of ingredient {i + 1}:"));
                        break; // Exit the loop if conversion succeeds
                    }
                    catch (FormatException)
                    {
                        // Display error message and prompt the user to re-enter the value
                        MessageBox.Show("Invalid input! Please enter a valid quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                // Prompt the user to enter the unit of measurement for the ingredient
                string unit = Interaction.InputBox($"Enter the unit of measurement for ingredient {i + 1}:");

                int calories;
                while (true)
                {
                    try
                    {
                        // Prompt the user to enter the number of calories for the ingredient and convert it to int
                        calories = Convert.ToInt32(Interaction.InputBox($"Enter the number of calories for ingredient {i + 1}:"));
                        break; // Exit the loop if conversion succeeds
                    }
                    catch (FormatException)
                    {
                        // Display error message and prompt the user to re-enter the value
                        MessageBox.Show("Invalid input! Please enter a valid number of calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                int foodGroupNumber;
                while (true)
                {
                    try
                    {
                        // Prompt the user to enter the food group number that the ingredient belongs to
                        // and convert it to int
                        foodGroupNumber = Convert.ToInt32(Interaction.InputBox($"Enter the food group number that the ingredient belongs to {i + 1}:" +
                                                                               "Options:\n" +
                                                                               "1. Fruits\n" +
                                                                               "2. Vegetables\n" +
                                                                               "3. Grains\n" +
                                                                               "4. Protein\n" +
                                                                               "5. Dairy\n" +
                                                                               "6. Fats and Oils"));
                        string foodGroup = recipe.GetFoodGroupName(foodGroupNumber);
                        recipe.AddIngredient(ingredientName, quantity, unit, calories, foodGroup);
                        recipe.OriginalQuantities.Add(quantity);

                        break; // Exit the loop if conversion and mapping succeed
                    }
                    catch (FormatException)
                    {
                        // Display error message and prompt the user to re-enter the value
                        MessageBox.Show("Invalid input! Please enter a valid food group number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            for (int i = 0; i < numSteps; i++)
            {
                // Prompt the user to enter each step of the recipe
                string step = Interaction.InputBox($"\nEnter step {i + 1}:");
                recipe.AddStep(step);
            }

            int totalCalories = recipe.GetTotalCalories();
            if (totalCalories >= 300) // Check if the total calories exceed 300
            {
                d.NotifyUserExceededCalories(recipe.RecipeName, totalCalories);
            }

            MessageBox.Show("\nRecipe added successfully!");

            // Create a new instance of the AddRecipeWindow class
            AddRecipeWindow arw = new AddRecipeWindow();

            recipe.PrintRecipe(); // Calls the PrintRecipe method from the Recipe class and prints the current recipe.

            //recipe.ScaleRecipe(factor);
            // arw.ScaleRecipePrompt();

            recipes.Add(recipe); // Add the current recipe to the list of recipes

            StringBuilder recipeNames = new StringBuilder("Recipe added:\n");
            foreach (Recipe r in recipes)
            {
                recipeNames.AppendLine(r.RecipeName);
            }

            // Display a message box with the names of all the added recipes
            MessageBox.Show(recipeNames.ToString(), "Added Recipes", MessageBoxButton.OK, MessageBoxImage.Information);

            MessageBoxResult result = MessageBox.Show("Do you want to enter another recipe?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Prompt the user to enter the recipe details on the Create Recipe panel and click Enter
                MessageBox.Show("Please enter the recipe details on the Create Recipe panel and click Enter.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
