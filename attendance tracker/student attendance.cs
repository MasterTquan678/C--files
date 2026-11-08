//******************************************//
// Author: Antquan Smiley II
// Date: 11/7/2026
// Descrption: A program that tracks the attendance of the classroom
//******************************************//

using System;

namespace AttendanceTracker
{
    class Program 
    {
        static void Main(string[]args) 
        {
            Console.WriteLine("Welcome to the Classroom Attendance Tracker!");
            // Ask how many students
            Console.Write("Enter the number of students: ");
            int numStudents = int.Parse(Console.ReadLine());
            // Array for student names
            string[] studentNames = new string[numStudents];
            for (int i = 0; i < numStudents; i++)
            {
                 Console.Write($"Enter name for student #{i + 1}: ");

                studentNames[i] = Console.ReadLine();
            }
            // 2D array for attendance
            int[,] attendance = new int[numStudents, 5];
            
            for (int i = 0; i < numStudents; i++)
            {
                Console.WriteLine($"\nAttendance for {studentNames[i]} (Y/N):");
                for (int day = 0; day < 5; day++)
                {
                    string input = "";
                    bool valid = false;

                    while (!valid)
                    {
                        Console.Write($"  Day {day + 1} (Y/N): ");
                        input = Console.ReadLine()?.Trim().ToUpper();

                        if (input == "Y" || input == "N") 
                        {
                            valid = true;
                        }
                        else 
                        {
                            Console.WriteLine("  Invalid input. Please enter 'Y' or 'N'.");
                        }
                    }
                    attendance[i, day] = (input == "Y") ? 1 : 0;
                }
            }
            // Display results
             Console.WriteLine("\n--- Attendance Summary ---");
             for (int i = 0; i < numStudents; i++)
             {
                int totalDays = 0;

                for (int day = 0; day < 5; day++)
                {
                    totalDays += attendance[i, day];
                }
                 Console.WriteLine($"{studentNames[i]}: {totalDays} / 5 days present");
             }
        }
    }
}