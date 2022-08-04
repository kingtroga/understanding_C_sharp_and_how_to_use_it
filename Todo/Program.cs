using System;
using System.Collections.Generic;

namespace Todo
{
    class Program
    {
        static public void Main(string[] args)
        {
            // Instatiate an object that has access to the
            // non static methods in TodoFunctions
            TodoFunctions td = new TodoFunctions();

            // Setting up a data_structure to store the
            // menu to be displayed to the user
            Dictionary<string, string> the_menu = new Dictionary<string, string>() {
                {"L","List"},
                {"A", "Add"},
                {"U", "Update"},
                {"D", "Delete"},
                {"S", "Save the data to file"},
                {"R", "Restore data from file"},
                {"Q", "Quit this program"}
            };

            // initial set up of all_tasks
            List<string> all_tasks = new List<string>();

            // a data structure to store the "List" menu suboptions
            Dictionary<string, string> list_menu = new Dictionary<string, string>()
            {
                {"A", "all tasks"},
                {"C", "completed tasks"},
                {"I", "incomplete tasks" }
            };

            // a data structure to store the mapping of the integer priority
            // values to their textual interpretation
            Dictionary<int, string> priority_scale = new Dictionary<int, string>()
            {
                {1, "Lowest"},
                {2, "Low"},
                {3, "Medium"},
                {4, "High"},
                {5, "Highest"}
            };

            string opt;

            while (true)
            {
                // output the main menu to the user's screen
                td.PrintMainMenu(the_menu);

                // Collect the user's input and store it inside 
                // the opt variable
                Console.Write("::: Enter a menu option\n>");
                opt = Console.ReadLine();


                // checking to see if the user's input is part of the
                // menu shown
                break;
            }


        }
    }
}