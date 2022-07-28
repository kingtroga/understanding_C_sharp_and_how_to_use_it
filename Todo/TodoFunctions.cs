using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class TodoFunctions
    {
        

        public void PrintMainMenu(Dictionary<string, string> menu)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("What would you like to do?");

            foreach (KeyValuePair<string,string> item in menu)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("==========================");
        }

        public string GetSelection(
                           string action,
                           Dictionary<string, string> suboptions,
                           bool toUpper = true,
                           bool goBack = true)
        {
            string selection = null;
            if (goBack)
            {
                if (suboptions.ContainsKey("m") || suboptions.ContainsKey("M"))
                {
                    Console.WriteLine("Invalid submenu, which contains M as a Key.");
                }
            }
            while (!(suboptions.ContainsKey(selection)))
            {
                Console.WriteLine($"::: What would you like to {action.ToLower()}?");
                foreach(KeyValuePair<string, string> item in suboptions)
                {
                    Console.WriteLine($"{item.Key} - {suboptions[item.Key]}");
                };
                if (goBack == true)
                {
                    Console.Write("::: Enter your selection or press \'m\' to return to the main menu\n> ");
                    selection = Console.ReadLine();
                }
                else
                {
                    Console.Write("::: Enter your selection\n> ");
                    selection = Console.ReadLine();
                }
                if (toUpper)
                {
                    selection = selection.ToUpper();
                }
                if (goBack && selection.ToUpper() == "M")
                {
                    return "M";
                }
            }

            if (toUpper)
            {
                Console.WriteLine($"You selected |{selection}| to" +
                                  $" {action.ToLower()} |{suboptions[selection].ToLower()}|.");
            }
            else
            {
                Console.WriteLine($"You selected |{selection}| to" +
                    $"{action.ToLower()} |{suboptions[selection]}|");
            }
            return selection;
        }

        public void PrintTask(
            Dictionary<string, string> task,
            Dictionary<int, string> priorityScale,
            bool nameOnly = false
            )
        {
            if (nameOnly) Console.WriteLine(task["name"]);
            if (nameOnly == false)
            {
                Console.WriteLine(task["name"]);
                if (task["info"] != string.Empty) Console.WriteLine($"* {task["info"]}");


            }
        }
    }
}
