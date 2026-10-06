//*************************************************************//
// Author: Antquan Smiley II
// Date: 9/25/2026
// Description: Student Report Card
//*************************************************************//

#include <iostream>
#include <iomanip>
#include <string>
#include <fstream>

using namespace std;

// Structure to hold student data
struct Student {
    string firstName;
    string lastName;
    double homeworks[10];
    double midterm;
    double finalExam;
    double daysPresent;
    double daysAbsent
    double totalDays;
};

// Function to calculate letter grade based on final score
char calculateLetterGrade(double finalGrade) {
    if (finalGrade >= 90.0) return 'A';
    if (finalGrade >= 80.0) return 'B';
    if (finalGrade >= 70.0) return 'C';
    if (finalGrade >= 60.0) return 'D';
    return 'F';
}

int main() {
    // Open input and output files
    ifstream inFile("students.txt");
    ofstream outFile("report_cards.txt");

    // Check if files opened successfully
    if (!inFile) {
        cerr << "Error: Could not open input file 'students.txt'" << endl;
        return 1;
    }
    if (!outFile) {
        cerr << "Error: Could not create output file 'report_cards.txt'" << endl;
        return 1;
    }

    // Write the report header to the output file
    outFile << "=========================================================================================\n";
    outFile << "                                   STUDENT REPORT CARDS                                  \n";
    outFile << "=========================================================================================\n";
    outFile << left << setw(18) << "Student Name" 
            << setw(10) << "HW Avg" 
            << setw(10) << "Midterm" 
            << setw(12) << "Final Exam" 
            << setw(13) << "Attendance" 
            << setw(13) << "Final Score" 
            << "Grade\n";
    outFile << "-----------------------------------------------------------------------------------------\n";

    Student student;

    // Loop through the input file until EOF
    while (inFile >> student.firstName >> student.lastName) {
        double hwSum = 0.0;
        
        // Read 10 homework grades
        for (int i = 0; i < 10; ++i) {
            inFile >> student.homeworks[i];
            hwSum += student.homeworks[i];
        }

        // Read remaining grade and attendance data
        inFile >> student.midterm >> student.finalExam >> student.daysPresent >> student.totalDays;

        // Perform calculations
        double hwAverage = hwSum / 10.0;
        double attendancePercentage = (student.daysPresent / student.totalDays / student.daysAbsent) * 100.0;
        
        // Calculate weighted final grade
        double finalGrade = (hwAverage * 0.55) + (student.midterm * 0.20) + (student.finalExam * 0.25);
        char letterGrade = calculateLetterGrade(finalGrade);

        // Format and print the student row
        string fullName = student.lastName + ", " + student.firstName;
        
        outFile << fixed << setprecision(1);
        outFile << left << setw(18) << fullName
                << setw(10) << hwAverage
                << setw(10) << student.midterm
                << setw(12) << student.finalExam
                << setw(1.0) << attendancePercentage << "%      "
                << setw(13) << finalGrade
                << letterGrade << "\n";
    }

    outFile << "=========================================================================================\n";

    // Close files
    inFile.close();
    outFile.close();

    cout << "Report cards generated successfully in 'report_cards.txt'." << endl;

    return 0;
}


