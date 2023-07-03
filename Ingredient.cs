using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Application_WPF
{
    internal class Ingredient
    {
        public string Name { get; set; }       //Public string to store the name of the ingredient 
                                               //Allow the variable to be read and modified from outside the ingredient 
        public double Quantity { get; set; }   //Public double to store the quantity of the specified ingredient 
                                               //Allow the variable to be read and modified from outside the ingredient class
        public string Unit { get; set; }       //Public string variable to store the unit of measurement of the ingredient
                                               //Allow the variable to be read and modified from outside the ingredient class
        public int Calories { get; set; }      // Number of calories in the ingredient

        public string FoodGroup { get; set; }  // Food group to which the ingredient belongs
    }
}
