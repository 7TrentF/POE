using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POE_Application_WPF
{
    internal class Delegate
    {
        public delegate void NotifyUser(string recipeName, int totalCalories); // Delegate declaration for notifying the user about recipe calories

        public void NotifyUserExceededCaloriesRecipe(string recipeName, int totalCalories)
        {
            MessageBox.Show($"WARNING!!!:\n" +
                            $"The recipe '{recipeName}' has exceeded 300 calories.\n" +
                            $"Eating more than 300 to 400 calories in a meal will likely cause a surplus of energy, and thus result in weight gain\n" +
                            $"\nTotal calories: {totalCalories}", "Calorie Limit Exceeded", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void NotifyUserExceededCalories(string ingredientName)
        {
            MessageBox.Show($"WARNING!!!:\n" +
                            $"The calories for the ingridient: '{ingredientName}' (when added to the recipe total) exceeds 300 calories.\n" +
                            $"Eating more than 300 to 400 calories in a meal will likely cause a surplus of energy", "Calorie Limit Exceeded", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        /* 
         *  /*  Author: Doyle, B. (2016) 
            title of the book: C♯ Programming: From problem analysis to program design.Boston, MA: Cengage Learning. pg 686-690
            accessed:  6 june 2023

            Author: Samuel Kubjana
            Class example: DelegateExample
        */
    }
    }
