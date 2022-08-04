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
            foreach (KeyValuePair<string, string> pair in menu)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            Console.WriteLine("==========================");
        }
    }
}
