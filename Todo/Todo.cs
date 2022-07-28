using System;
using System.Collections.Generic;

namespace Todo
{
    public class Todo
    {
        static void Main(string[] args)
        {
            // Instatiate a TodoFunctions Object to 
            // access all the functions created
            TodoFunctions td = new TodoFunctions();

            // Data Structure to store the menu
            Dictionary<string, string> theMenu = new Dictionary<string, string>()
            {
                {"L", "List"},
                {"A", "Add"},
                {"U", "Update"},
                {"D", "Delete"},
                {"S", "Save the data to file"},
                {"R", "Restore data from file"},
                {"Q", "Quit this program"}
            };

            // intial set up of all tasks
            List<Dictionary<string, string>> allTasks = new List<Dictionary<string,string>>();

            //Data structure to store the List menu
            // suboptions
            Dictionary<string, string> listMenu = new Dictionary<string, string>()
            {
                {"A", "all tasks"},
                {"C", "completed tasks"},
                {"I", "incomplete tasks"}
            };

            // Data structure to store the mapping of the 
            // the integer priority values to their textural interpretation
            Dictionary<int, string> priorityScale = new Dictionary<int, string>()
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
                // Output the main menu
                // to the user's screen
                td.PrintMainMenu(theMenu);

                // Collect the user's input
                // and store it inside the opt
                // variable
                Console.Write(":::Enter a menu option\n>");
                opt = Console.ReadLine();
                opt = opt.ToUpper(); // to allow us to input lower- or upper- case letters

                if (!(theMenu.ContainsKey(opt)))
                {
                    Console.WriteLine($"WARNING: {opt} is an invalid menu option.\n");
                    continue;
                }
                else if (opt == "L")
                {
                    Console.WriteLine($"You selected option {opt} to > {theMenu[opt]}");
                    if (allTasks == null || allTasks.Count == 0)
                    {
                        Console.WriteLine("WARNING: There is noting to display!");
                        Console.WriteLine("::: Press Enter to continue");
                        Console.ReadLine();
                        continue;
                    };
                    string subOpt = td.GetSelection(theMenu[opt], listMenu);
                    
                }

                // The "List" option
                //else if (opt == "L")
                //{

                //}
            }
        }
    }
}