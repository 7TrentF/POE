using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        public void ScaleRecipe(double factor)
        {

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
                /*John S
                  https://stackoverflow.com/questions/2675196/c-sharp-method-to-scale-values
                  accessed: 24 april 2023
                */
            }
            //MessageBox.Show("Scaled Recipe", "Scaled Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            PrintRecipe(); // Prints the scaled recipe to the console.

        }

        public void PrintRecipe()
        {
            StringBuilder recipeText = new StringBuilder();

            recipeText.AppendLine("---------------------------------------");
            recipeText.AppendLine($"Recipe Name: {RecipeName}");
            recipeText.AppendLine("---------------------------------------");

            recipeText.AppendLine("\nIngredients:");

            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredient ingredient = Ingredients[i];
                recipeText.AppendLine($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            recipeText.AppendLine("\nRecipe Information:");

            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredient ingredient = Ingredients[i];
                recipeText.AppendLine($"Ingredient: {ingredient.Name}");
                recipeText.AppendLine($"Calories:   {ingredient.Calories}");
                recipeText.AppendLine($"Food Group: {ingredient.FoodGroup}");
                recipeText.AppendLine();
            }

            recipeText.AppendLine("Steps:");

            for (int i = 0; i < Steps.Count; i++)
            {
                string step = Steps[i];
                recipeText.AppendLine($"{i + 1}. {step}");
            }

            recipeText.AppendLine("---------------------------------------");

            MessageBox.Show(recipeText.ToString(), "Recipe Details");
        }

        public void ResetQuantities()
        {
            string answer = Interaction.InputBox("Do you want to reset the quantities to the original values? (y/n)").ToLower();    // Asks the user if they want to reset the recipe to its original quantities and reads their response.

            if (answer == "y")
            {
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    Ingredient ingredient = Ingredients[i];
                    Ingredients[i].Quantity = OriginalQuantities[i];
                }
                MessageBox.Show("The recipe quantities have been reset to their original values:", "Quantities Reset", MessageBoxButton.OK, MessageBoxImage.Information);
                PrintRecipe();
            }
            else if (answer == "n")
            {
                // Handle the case when the user's response is "n"
                MessageBox.Show("The recipe quantities will not be reset.", "Quantities Not Reset", MessageBoxButton.OK, MessageBoxImage.Information);
                // Add any additional code specific to this case if needed
            }
            else
            {
                // Handle the case when the user's response is neither "y" nor "n"
                MessageBox.Show("Invalid response. The recipe quantities will not be reset.", "Invalid Response", MessageBoxButton.OK, MessageBoxImage.Warning);
                // Add any additional code specific to this case if needed
            }
        }

        public void ClearRecipe() // Clear the recipe by resetting its properties and clearing the lists
        {

            string answer = Interaction.InputBox("Do you want to  clear the recipe? (y/n)").ToLower();// Asks the user if they want to reset the recipe to its original quantities and reads their response.

            if (answer == "y")
            {
                RecipeName = string.Empty;// Reset the recipe name to an empty string
                Ingredients.Clear(); // Clear the Ingredients list, removing all elements
                Steps.Clear(); // Clear the Steps list, removing all elements
                OriginalQuantities.Clear(); // Clear the OriginalQuantities list, removing all element

                Console.WriteLine("\n The recipe has been cleared");
                PrintRecipe();
            }
            else if (answer == "n")
            {
                // Handle the case when the user's response is "n"
                MessageBox.Show("The recipe will not be cleared.", "Recipe Not Cleared", MessageBoxButton.OK, MessageBoxImage.Information);
                // Add any additional code specific to this case if needed
                PrintRecipe();
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
            StringBuilder recipeInfo = new StringBuilder();
            recipeInfo.AppendLine("---------------------------------------");
            recipeInfo.AppendLine($"Recipe Name: {RecipeName}");
            recipeInfo.AppendLine("---------------------------------------");
            recipeInfo.AppendLine("Recipe Information:\n");

            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredient ingredient = Ingredients[i];
                recipeInfo.AppendLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
                recipeInfo.AppendLine($"Calories: {ingredient.Calories}");
                recipeInfo.AppendLine($"Food Group: {ingredient.FoodGroup}\n");
            }

            recipeInfo.AppendLine($"Total Calories: {GetTotalCalories()}\n");
            recipeInfo.AppendLine("---------------------------------------");
            recipeInfo.AppendLine("As a guide: The average man needs 2,500kcal a day,");
            recipeInfo.AppendLine("Whereas the average woman needs 2,000kcal a day.");
            recipeInfo.AppendLine("This could be different based on your:");
            recipeInfo.AppendLine("- Age\n- Weight\n- Height\n- How much exercise you do.");
            recipeInfo.AppendLine("---------------------------------------");
            recipeInfo.AppendLine("\nSteps:");

            for (int i = 0; i < Steps.Count; i++)
            {
                recipeInfo.AppendLine($"{i + 1}. {Steps[i]}");
            }

            recipeInfo.AppendLine("---------------------------------------");

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
            Dictionary<int, string> foodGroups = new Dictionary<int, string>()
    {
        { 1, "Fruits" },
        { 2, "Vegetables" },
        { 3, "Grains" },
        { 4, "Protein" },
        { 5, "Dairy" },
        { 6, "Fats and Oils" }
    };

            if (foodGroups.TryGetValue(foodGroupNumber, out string foodGroupName))
            {
                return foodGroupName;
            }

            // If the food group number is invalid, you can return a default value or throw an exception
            return string.Empty;
        }

        public void recipeMessage()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to enter another recipe?", "Recipe Entry", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

            }
            else
            {
                // User does not want to enter another recipe
                // Add your code here to handle the user's choice
            }
        }


    }
}
