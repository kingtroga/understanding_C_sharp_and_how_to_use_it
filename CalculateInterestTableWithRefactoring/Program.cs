using System;

namespace CalculateInterestTableMoreForgiving
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define a maximum interest rate.
            int maximumInterest = 50;

            // Prompt user to enter source principal; keep prompting
            // until the correct value is entered.
            decimal principal;
            principal = InputPositiveDecimal("Principal");

            // Now enter the interest rate.
            decimal interest;
            interest = InputPositiveDecimal("Interest");

            // Both the principal and the interest appear to be
            // legal; finally, input the number of years.
            Console.Write("Enter number of years: ");
            string durationInput = Console.ReadLine();
            int duration = Convert.ToInt32(durationInput);

            // Verify the input.
            Console.WriteLine();  // Skip a line.
            Console.WriteLine("Principal     = " + principal);
            Console.WriteLine("Interest      = " + interest + "%");
            Console.WriteLine("Duration      = " + duration + " years");
            Console.WriteLine();

            // Now loop through the specified number of years.
            principal = OutputInterestTable(principal, interest, duration);
        }

        private static decimal InputPositiveDecimal(string prompt)
        {
            decimal value;
            while (true)
            {
                Console.Write($"Enter {prompt}: ");
                string principalInput = Console.ReadLine();
                value = Convert.ToDecimal(principalInput);

                // Exit if the value entered is correct.
                if (value >= 0)
                {
                    break;
                }

                // Generate an error on incorrect input.
                Console.WriteLine($"{prompt} cannot be negative");
                Console.WriteLine("Try again");
                Console.WriteLine();
            }

            return value;
        }

        private static decimal OutputInterestTable(decimal principal, decimal interest, int duration)
        {
            int year = 1;
            while (year <= duration)
            {
                // Calculate the value of the principal plus interest.
                decimal interestPaid;
                interestPaid = principal * (interest / 100);

                // Now calculate the new principal by adding
                // the interest to the previous principal.
                principal = principal + interestPaid;

                // Round off the principal to the nearest cent.
                principal = decimal.Round(principal, 2);

                // Output the result.
                Console.WriteLine(year + "-" + principal);

                // Skip over to next year.
                year = year + 1;
            }

            Console.Read();
            return principal;
        }
    }
}
