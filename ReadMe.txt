--------------------------------------
Trents Recipe WPF Application
--------------------------------------
Minimum System requirements:

Operating system= Windows 8.1, 10, 11).
Microsift Visual Studio 2022

[Minimum requirements to able to run Microsoft Visual Studio 2022]
Windows 11 version 21H2 or higher: Home, Pro, Pro Education, Pro for Workstations, Enterprise, and Education
Windows 10 version 1909 or higher: Home, Professional, Education, and Enterprise. 
Windows Server(2022, 2019, 2016: Standard and Datacenter)

[Minimum hardware requirements to be able to run Visual Studio 2022]
A Processor that is 1.8GHz or faster 
Quad-core or better recommended
Minimum of 4 GB of RAM but 8GB of RAM is recommended
Hard disk space: Minimum of 850 MB up to 210 GB of available space, depending on features installed; typical installations require 20-50 GB of free space.
Recommended installing Windows and Visual Studio on a solid-state drive (SSD) to increase performance, but an HDD will suffice as well.
Video card that supports a minimum display resolution of WXGA (1366 by 768); Visual Studio will work best at a resolution of 1920 by 1080 or higher.


This is a simple WPF application for managing recipe details. The application allows you to enter the details for a single recipe, display the recipe, scale the recipe, reset quantities, and clear all data to enter a new recipe. As well as view a list with the recipes added and a window for the user to view the full details of the recipes they added, as well as functionality for the user to filter the recipes by:
a. entering the name of an ingredient that must be in the recipe,
b. choosing a food group that must be in the recipe, or
c. selecting a maximum number of calories.
The user can also delete recipes.

How to run 
To use the application, simply run the RecipeConsoleApp file by opening it through Visual Studio.
You will be presented with the raw code and you will only need to run it through executing the code by clicking on 'start wihout debugging' next to 'start' at the top of the screen.
You will be presented with a menu of options upon running the code.
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
GitHub link - 
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes made based on the Lecturers Feedback:
Based on the Lectures feedback from Part 2, I have made updates to the method enterRecipe which makes use of the delegate.  I have revised the way the delegate is called. Now, when the calories for an ingredient are entered, and the total calories of all the ingredients for that recipe exceed 300 calories, the user will be notified. The delegate is also shown once 
the recipe has been addded, to warn the user that thier recipe exceeds 300 calories, along with inforamtion relevent to the number of calories.