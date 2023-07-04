using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace POE_Application_WPF
{
    public class Recipe
    {

        public string RecipeName { get; set; }              // Name of the recipe
        public List<Ingredient> Ingredients { get; set; }   // List of ingredients in the recipe
        public List<string> Steps { get; set; }             // List of steps to prepare the recipe
        public List<double> OriginalQuantities { get; set; } //public double array to store the original quantities of each ingredient 

        public Recipe(string name) // Constructor for the Recipe class, Initializes a new instance of the Recipe class with the specified name
        {
            RecipeName = name;                       // Set the RecipeName property to the provided name 
            Ingredients = new List<Ingredient>();    // Create a new empty list to store the ingredients of the recipe
            Steps = new List<string>();              // Create a new empty list to store the steps of the recipe
            OriginalQuantities = new List<double>(); // Create a new empty list to store the recipes OriginalQueantities 

            for (int i = 0; i < Ingredients.Count; i++) // Loop through the OriginalQuantities list and assign default values
            {
                OriginalQuantities[i] = 0.0;
            }
            /*
              Author: Doyle, B. (2016) 
              title of the book: C♯ Programming: From problem analysis to program design. Boston, MA: Cengage Learning. pg 475-484
              accessed:  31 may 2023
            */
        }

        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)// Method that adds a new ingredient to the Ingredients array at the specified index
        {
            Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup }); // adds a new Ingredient object to the Ingredients list and assigns values to the corresponding variables
        }

        public void AddStep(string step)// Method that adds a new step to the Steps array at the specified index
        {
            Steps.Add(step); // Assigns the specified description string to the specified index in the Steps array
        }


        public void ScaleRecipe()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to scale the recipe?", "Scale Recipe", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Check if the user clicked "Yes" in the message box
            if (result == MessageBoxResult.Yes)
            {
                bool validInput = false;
                double factor = 0;

                // Keep prompting for input until a valid scaling factor is entered
                while (!validInput)
                {
                    string input = Interaction.InputBox("Enter the scaling factor:\n0.5 (Half)\n2 (Double)\n3 (Triple):", "Scaling Factor");

                    try
                    {
                        factor = Convert.ToDouble(input);

                        // Check if the entered factor is one of the valid values (0.5, 2, 3)
                        if (factor == 0.5 || factor == 2 || factor == 3)
                        {
                            validInput = true; // Mark the input as valid to exit the loop
                        }
                        else
                        {
                            MessageBox.Show("Invalid input. Please enter 0.5, 2, or 3.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Invalid input. The number is too large or too small.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                if (factor == 0.5) // If the factor is 0.5, multiply by 0.5 
                {
                    for (int i = 0; i < Ingredients.Count; i++)
                    {
                        Ingredient ingredient = Ingredients[i];
                        ingredient.Quantity *= 0.5;
                    }
                }
                else if (factor == 2) // If the scaling factor is 2 (double)
                {
                    for (int i = 0; i < Ingredients.Count; i++)
                    {
                        Ingredient ingredient = Ingredients[i];
                        ingredient.Quantity *= 2;
                    }
                }
                else if (factor == 3) // If the scaling factor is 3 (triple)
                {
                    for (int i = 0; i < Ingredients.Count; i++)
                    {
                        Ingredient ingredient = Ingredients[i];
                        ingredient.Quantity *= 3;
                    }
                }
                 PrintRecipe(); // Prints the scaled recipe to the console.
            }
        }

        public void PrintRecipe()
        {
            // Create a StringBuilder to construct the recipe text
            StringBuilder recipeText = new StringBuilder();

            // Add separator and recipe name to the recipe text
            recipeText.AppendLine("---------------------------------------");
            recipeText.AppendLine($"Recipe Name: {RecipeName}");
            recipeText.AppendLine("---------------------------------------");

            // Add section heading for ingredients
            recipeText.AppendLine("\nIngredients:");

            // Iterate over the ingredients and add their details to the recipe text
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredient ingredient = Ingredients[i];
                recipeText.AppendLine($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            // Add section heading for recipe information
            recipeText.AppendLine("\nRecipe Information:");

            // Iterate over the ingredients again and add their individual information to the recipe text
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredient ingredient = Ingredients[i];
                recipeText.AppendLine($"Ingredient: {ingredient.Name}");
                recipeText.AppendLine($"Calories:   {ingredient.Calories}");
                recipeText.AppendLine($"Food Group: {ingredient.FoodGroup}");
                recipeText.AppendLine();
            }

            // Add section heading for steps
            recipeText.AppendLine("Steps:");

            // Add the steps of the recipe to the recipe text
            for (int i = 0; i < Steps.Count; i++)
            {
                string step = Steps[i];
                recipeText.AppendLine($"{i + 1}. {step}");
            }

            // Add final separator to the recipe text
            recipeText.AppendLine("---------------------------------------");

            // Display the recipe text in a message box with the title "Recipe Details"
            MessageBox.Show(recipeText.ToString(), "Recipe Details");
        }


        public void ResetQuantities()
        {
            // Asks the user if they want to reset the recipe to its original quantities and reads their response.
            MessageBoxResult result = MessageBox.Show("Do you want to reset the quantities to the original values? (y/n)", "Reset quantities", MessageBoxButton.YesNo, MessageBoxImage.Question);
            

            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    Ingredient ingredient = Ingredients[i];
                    Ingredients[i].Quantity = OriginalQuantities[i];
                }
                MessageBox.Show("The recipe quantities have been reset to their original values:", "Quantities Reset", MessageBoxButton.OK, MessageBoxImage.Information);
                PrintRecipe();
            }
            else if (result == MessageBoxResult.No)
            {
                // Handle the case when the user's response is "n"
                MessageBox.Show("The recipe quantities will not be reset.", "Quantities Not Reset", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            else
            {
                // Handle the case when the user's response is neither "y" nor "n"
                MessageBox.Show("Invalid response. The recipe quantities will not be reset.", "Invalid Response", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }
        }

        public void ClearRecipe() // Clear the recipe by resetting its properties and clearing the lists
        {
            MessageBoxResult result = MessageBox.Show("Do you want to  clear the recipe? (y/n)", "Clear recipe", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                string answer = Interaction.InputBox("Do you want to  clear the recipe? (y/n)").ToLower();// Asks the user if they want to reset the recipe to its original quantities and reads their response.

                RecipeName = string.Empty;// Reset the recipe name to an empty string
                Ingredients.Clear(); // Clear the Ingredients list, removing all elements
                Steps.Clear(); // Clear the Steps list, removing all elements
                OriginalQuantities.Clear(); // Clear the OriginalQuantities list, removing all element

                MessageBox.Show("The recipe has been cleared");
                PrintRecipe();
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("The recipe will not be cleared.", "Recipe Not cleared", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Handle the case when the user's response is neither "y" nor "n"
                MessageBox.Show("Invalid response. The recipe will not be cleared.", "Invalid Response", MessageBoxButton.OK, MessageBoxImage.Warning);
                PrintRecipe();
            }
        }

        public void DisplayRecipe()
        {
            // Create a StringBuilder to construct the recipe information string
            StringBuilder recipeInfo = new StringBuilder();

            // Add separator and recipe name to the recipe information
            recipeInfo.AppendLine("---------------------------------------");
            recipeInfo.AppendLine($"Recipe Name: {RecipeName}");
            recipeInfo.AppendLine("---------------------------------------");
            recipeInfo.AppendLine("Recipe Information:\n");

            // Iterate over the ingredients and add their details to the recipe information
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredient ingredient = Ingredients[i];
                recipeInfo.AppendLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
                recipeInfo.AppendLine($"Calories: {ingredient.Calories}");
                recipeInfo.AppendLine($"Food Group: {ingredient.FoodGroup}\n");
            }

            // Add the total calories of the recipe to the recipe information
            recipeInfo.AppendLine($"Total Calories: {GetTotalCalories()}\n");

            // Add separator and additional information to the recipe information
            recipeInfo.AppendLine("---------------------------------------");
            recipeInfo.AppendLine("As a guide: The average man needs 2,500kcal a day,");
            recipeInfo.AppendLine("Whereas the average woman needs 2,000kcal a day.");
            recipeInfo.AppendLine("This could be different based on your:");
            recipeInfo.AppendLine("- Age\n- Weight\n- Height\n- How much exercise you do.");
            recipeInfo.AppendLine("---------------------------------------");
            recipeInfo.AppendLine("\nSteps:");

            // Add the steps of the recipe to the recipe information
            for (int i = 0; i < Steps.Count; i++)
            {
                recipeInfo.AppendLine($"{i + 1}. {Steps[i]}");
            }

            // Add final separator to the recipe information
            recipeInfo.AppendLine("---------------------------------------");

            // Display the recipe information in a message box
            MessageBox.Show(recipeInfo.ToString(), "Recipe Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

       

        public int GetTotalCalories() // Calculates and returns the total calories of all the ingredients in the recipe
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public string GetFoodGroupName(int foodGroupNumber)
        {
            // Define a dictionary that maps food group numbers to food group names
            Dictionary<int, string> foodGroups = new Dictionary<int, string>()
    {
        { 1, "Fruits" },
        { 2, "Vegetables" },
        { 3, "Grains" },
        { 4, "Protein" },
        { 5, "Dairy" },
        { 6, "Fats and Oils" }
    };

            // Try to get the food group name associated with the given food group number
            if (foodGroups.TryGetValue(foodGroupNumber, out string foodGroupName))
            {
                // If the food group number is valid, return the corresponding food group name
                return foodGroupName;
            }

            // If the food group number is invalid, you can return a default value or throw an exception
            return string.Empty;
        }

        public void CalorieInformation()
        {
            MessageBox.Show(
                  "Calories are a measurement of the amount of energy that is contained in foods or drinks", "Calorie Information", MessageBoxButton.OK, MessageBoxImage.Information);


        }


    }
}
