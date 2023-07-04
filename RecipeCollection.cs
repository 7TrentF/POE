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
        
        private static RecipeCollection instance; // Singleton instance of the RecipeCollection class
        private List<Recipe> recipes; // Private field to store the list of recipes
        private string filterIngredientName; // Field to store the ingredient name filter
        private string filterFoodGroup; // Field to store the food group filter
        private int? filterMaxCalories; // Field to store the maximum calories filter
     
        // Instance ensures that only one instance of the RecipeCollection class exists throughout the application.
        //all classes and windows are able to access this instance and share the same data
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

        public void EnterRecipe(string recipeName, int numIngredients, int numSteps)
        {
            Recipe recipe = new Recipe(recipeName); // Create a new Recipe object with the entered name
            Delegate d = new Delegate(); // Create a new instance of the Delegate class (assuming this is a custom class)
            int totalCalories = 0;

            MessageBox.Show("Enter the Details for the recipe", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            for (int i = 0; i < numIngredients; i++)
            {
                // Prompt the user to enter the name of the ingredient

                string ingredientName;
                while (true)
                {
                    // Prompt the user to enter the ingredient name
                    ingredientName = Interaction.InputBox($"Enter the name of ingredient {i + 1}:");

                    // Check if the ingredient name is empty
                    if (string.IsNullOrWhiteSpace(ingredientName))
                    {
                        // Display error message and prompt the user to re-enter the value
                        MessageBox.Show("Ingredient name cannot be empty. Please enter a valid ingredient name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        // Exit the loop if a valid ingredient name is entered
                        break;
                    }
                }

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
                        CalorieInformation();

                        // Check if the total calories, including the current ingredient, exceed 300
                        if (totalCalories + calories > 300)
                        {
                            // Call the NotifyUserExceededCalories method from the Delegate class
                            d.NotifyUserExceededCalories(ingredientName);
                        }

                        break; // Exit the loop if conversion succeeds
                    }
                    catch (FormatException)
                    {
                        // Display error message and prompt the user to re-enter the value
                        MessageBox.Show("Invalid input! Please enter a valid number of calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                // Add the calories to the total
                totalCalories += calories;

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

            if (totalCalories >= 300) // Check if the total calories exceed 300
            {
                d.NotifyUserExceededCaloriesRecipe(recipe.RecipeName, totalCalories);
            }


            MessageBox.Show("\nRecipe added successfully!");
            recipe.PrintRecipe(); // Calls the PrintRecipe method from the Recipe class and prints the current recipe.
            recipe.ScaleRecipe();  // Calls the ScaleRecipe method from the Recipe class and scales the recipe.
            recipe.ResetQuantities();// Method that resets the quantities of all ingredients in the recipe to their original values.
            recipe.ClearRecipe();    // Method that clears the  current recipe. 
            recipes.Add(recipe); // Add the current recipe to the list of recipes

            StringBuilder recipeNames = new StringBuilder("Recipe added:\n");
            foreach (Recipe r in recipes)
            {
                recipeNames.AppendLine(r.RecipeName);
            }

            // Display a message box with the names of all the added recipes
            MessageBox.Show(recipeNames.ToString(), "Added Recipes", MessageBoxButton.OK, MessageBoxImage.Information);

            MessageBoxResult enterRecipe = MessageBox.Show("Do you want to enter another recipe?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (enterRecipe == MessageBoxResult.Yes)
            {
                // Prompt the user to enter the recipe details on the Create Recipe panel and click Enter
                MessageBox.Show("Please enter the recipe details on the Create Recipe panel and click Enter.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void CalorieInformation()
        {
            MessageBox.Show("As a guide:\nThe average man needs 2,500kcal a day,\n" +
                         "Whereas the average woman needs 2,000kcal a day.\n" +
                         "This could be different based on your:\n" +
                         "- Age\n- Weight\n- Height\n- How much exercise you do.",
                         "Calorie Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void DeleteRecipe(Recipe recipe)
        {
            // Remove the recipe from your collection based on your implementation
            // For example, if you have a List<Recipe>, you can use the Remove method:
            recipes.Remove(recipe);
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
            recipeDetails.AppendLine($"Recipe Name: {recipe.RecipeName}"); // Append the recipe name to the string
            recipeDetails.AppendLine("Ingredients:"); // Append a section header for ingredients
            foreach (var ingredient in recipe.Ingredients)
            {
                recipeDetails.AppendLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}"); // Append each ingredient with its name, quantity, and unit
            }
            recipeDetails.AppendLine("Steps:"); // Append a section header for steps
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                recipeDetails.AppendLine($"{i + 1}. {recipe.Steps[i]}"); // Append each step with its number
            }
            MessageBox.Show(recipeDetails.ToString(), "Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information); // Display the recipe details in a message box
        }

        private List<Recipe> filteredRecipes; // Private field to store the filtered recipes

        public List<Recipe> GetFilteredRecipes()
        {
            if (filteredRecipes == null)
            {
                // If no filters applied, return all recipes
                return recipes;
            }
            else
            {
                // Return the filtered recipes
                return filteredRecipes;
            }
        }


        // Method to reset the filters
        public void ResetFilters()
        {
            filteredRecipes = null; // Reset the filtered recipes
        }

        // Method to filter the recipes based on the filter criteria
        public List<Recipe> FilterRecipes()
        {
            List<Recipe> filteredRecipes = new List<Recipe>();

            foreach (Recipe recipe in recipes)
            {
                bool meetsFilterCriteria = true;

                // Apply ingredient name filter
                if (!string.IsNullOrEmpty(filterIngredientName))
                {
                    if (!recipe.Ingredients.Any(ingredient => ingredient.Name.ToLowerInvariant().Contains(filterIngredientName.ToLowerInvariant())))
                    {
                        meetsFilterCriteria = false;
                    }
                }

                // Apply food group filter
                if (!string.IsNullOrEmpty(filterFoodGroup))
                {
                    if (!recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.Equals(filterFoodGroup, StringComparison.OrdinalIgnoreCase)))
                    {
                        meetsFilterCriteria = false;
                    }
                }

                // Apply maximum calories filter
                if (filterMaxCalories.HasValue)
                {
                    if (recipe.GetTotalCalories() > filterMaxCalories.Value)
                    {
                        meetsFilterCriteria = false;
                    }
                }

                if (meetsFilterCriteria)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        public void FilterRecipesByIngredientName(string ingredientName)
        {
            // Create a new list to store the filtered recipes
            filteredRecipes = new List<Recipe>();

            // Iterate over each recipe in the collection
            foreach (Recipe recipe in recipes)
            {
                // Check if the recipe contains the specified ingredient name
                if (recipe.Ingredients.Any(ingredient => ingredient.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase)))
                {
                    filteredRecipes.Add(recipe); // Add the recipe to the filtered list
                }
            }
        }

        public void FilterRecipesByFoodGroup(string foodGroup)
        {
            // Create a new list to store the filtered recipes
            filteredRecipes = new List<Recipe>();

            // Iterate over each recipe in the collection
            foreach (Recipe recipe in recipes)
            {
                // Check if the recipe contains any ingredient belonging to the specified food group
                if (recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase)))
                {
                    filteredRecipes.Add(recipe); // Add the recipe to the filtered list
                }
            }
        }

        public void FilterRecipesByMaxCalories(int maxCalories)
        {
            // Create a new list to store the filtered recipes
            filteredRecipes = new List<Recipe>();

            // Iterate over each recipe in the collection
            foreach (Recipe recipe in recipes)
            {
                // Check if the total calories of the recipe is less than or equal to the specified maximum calories
                if (recipe.GetTotalCalories() <= maxCalories)
                {
                    filteredRecipes.Add(recipe); // Add the recipe to the filtered list
                }
            }
        }

        // Method to set the ingredient name filter
        public void SetIngredientNameFilter(string ingredientName)
        {
            filterIngredientName = ingredientName;
        }

        // Method to set the food group filter
        public void SetFoodGroupFilter(string foodGroup)
        {
            filterFoodGroup = foodGroup;
        }

        // Method to set the maximum calories filter
        public void SetMaxCaloriesFilter(int? maxCalories)
        {
            filterMaxCalories = maxCalories;
        }


    }
}
