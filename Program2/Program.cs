using System;

// Prompt user to enter a name.
Console.WriteLine("Enter you name, please: ");

// Now read the name enterd.
string name = Console.ReadLine();

// Greet the use with the name that was entered.
Console.WriteLine("Hello, " + name);

// Wait for user to acknowledge the results.
Console.WriteLine("Press Enter to terminate...");
Console.Read();