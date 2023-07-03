using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
      

        public string recipeName;
        public int numSteps;
        public int numIngredients;
        public string IngredientName;
        private bool ingredientNameEntered = false; // Flag to track if ingredient name is entered
        public double Quantity;
        public string Unit;
        public int Calories;
        public string FoodGroup;
        public double factor;


        public AddRecipeWindow()
        {
            InitializeComponent();

        }

        private void RecipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            recipeName = Recipe_Name_TextBox.Text;
            //Recipe r = new Recipe(recipeName);
        }

        private void Num_Of_Ingredients_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Num_Of_Ingredients_TextBox.Text))
            {
                if (int.TryParse(Num_Of_Ingredients_TextBox.Text, out int result))
                {
                    numIngredients = result;
                }
                else
                {
                    // Display an error message or handle the invalid input appropriately
                    MessageBox.Show("Invalid input. Please enter a valid integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    // You may choose to reset the TextBox text to a default value or empty string here
                    // Num_Of_Ingredients_TextBox.Text = string.Empty;
                }
            }
            else
            {
                numIngredients = 0; // Set a default value when the text is empty
            }
        }

        private void Number_Of_Steps_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Number_Of_Steps_TextBox.Text))
            {
                if (int.TryParse(Number_Of_Steps_TextBox.Text, out int result))
                {
                    numSteps = result;
                }
                else
                {
                    // Display an error message or handle the invalid input appropriately
                    MessageBox.Show("Invalid input. Please enter a valid integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    // You may choose to reset the TextBox text to a default value or empty string here
                    // Number_Of_Steps_TextBox.Text = string.Empty;
                }
            }
            else
            {
                numSteps = 0; // Set a default value when the text is empty
            }
        }

        private   void Print_Button_Click(object sender, RoutedEventArgs e)
        {

             RecipeCollection.Instance.EnterRecipe(recipeName, numIngredients, numSteps);

           

        }

        private void HideGridButton_Click(object sender, RoutedEventArgs e)
        {
            Num_Of_Ingredients_TextBox.Text = string.Empty;
            Number_Of_Steps_TextBox.Text = string.Empty;
            Recipe_Name_TextBox.Text = string.Empty;
        }

        private void Main_menu_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            RecipeCollection.Instance.DisplayRecipeList();
        }

        private void Ingredient_Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IngredientName = Ingredient_Name_TextBox.Text;
            ingredientNameEntered = true; // Set the flag to true when ingredient name is entered
        }

        private void Quantity_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Quantity = Convert.ToInt32(Quantity_TextBox.Text);
            if (ingredientNameEntered) // Check if ingredient name is entered
        {
            Quantity = Convert.ToInt32(Quantity_TextBox.Text);
        }
        else
        {
            // Display an error message or handle it appropriately
            MessageBox.Show("Please enter the ingredient name first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Quantity_TextBox.Text = string.Empty; // Clear the quantity text box
        }

        }

        private void Unit_Of_measurment_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Unit= Quantity_TextBox.Text;
        }

        private void Calories_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calories = Convert.ToInt32( Calories_TextBox.Text);
        }

        private void Food_Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FoodGroup = Food_Group_TextBox.Text;
        }

        private void ClearRecipeTextBoxes()
        {
            Recipe_Name_TextBox.Text = string.Empty;
            Num_Of_Ingredients_TextBox.Text = string.Empty;
            Number_Of_Steps_TextBox.Text = string.Empty;
        }

       public void ClearIngredientTextBoxes()
        {
            Ingredient_Name_TextBox.Text = string.Empty;
            Quantity_TextBox.Text = string.Empty;
            Unit_Of_measurment_TextBox.Text = string.Empty;
            Calories_TextBox.Text = string.Empty;
            Food_Group_TextBox.Text = string.Empty;
        }

    
    }
}
