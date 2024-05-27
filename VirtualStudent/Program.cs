using System;

namespace VirtualStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            // prompt user for student name
            Console.Write("Please enter a student's name: ");
            string studentName = Console.ReadLine();

            Console.WriteLine();

            // create a new student instance
            Student currentStudent = new Student(studentName);

            Console.WriteLine("Obtaining Real Marks ...");
            Console.WriteLine();

            // run method
            currentStudent.ObtainMarks();

            Console.WriteLine();
            Console.WriteLine(
                "Student {0} obtained a final grade of {1}",
                currentStudent.Name,
                currentStudent.Grade
            );
            Console.ReadLine();
        }
    }
}
