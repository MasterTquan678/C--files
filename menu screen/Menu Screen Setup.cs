//************************************************************//
// Menu Screen Setup
// Author: Antquan Smiley II
// Date: 10/9/2026
// Description: This file contains the setup for the menu screen of the application. It includes the layout, buttons, and event handlers for user interactions.
//************************************************************//

using System;

class MenuScreen
{
    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Mathematical Game Menu");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Display message");
            Console.WriteLine("4. Multiply");
            Console.WriteLine("5. Divide");
            Console.WriteLine("6. Exit");
            Console.Write("Please select an option (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformCalculation("Addition");
                    break;
                case "2":
                    PerformCalculation("Subtraction");
                    break;
                case "3":
                    Console.WriteLine("You're a smart, talented individual!");
                    break;
                case "4":
                    PerformCalculation("Multiplication");
                    break;
                case "5":
                    PerformCalculation("Division");
                    break;
                case "6":
                    keepRunning = false;
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
            WaitForUserInput();
            
            
        }
    }

    static void PerformCalculation(string operation)
    {
        Console.WriteLine($"You selected {operation}. Please enter two numbers.");

        Console.Write("Enter the first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (operation)
        {
            case "Addition":
                result = num1 + num2;
                break;
            case "Subtraction":
                result = num1 - num2;
                break;
            case "Multiplication":
                result = num1 * num2;
                break;
            case "Division":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    WaitForUserInput();
                    return;
                }
                break;
        }

        Console.WriteLine($"The result of {operation} is: {result}");
        WaitForUserInput();

        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }
}

