using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment test1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(test1.GetSummary());

        Console.WriteLine(); // Blank Line

        MathAssignment test2 = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 57.3", "Problems 8-19");
        Console.WriteLine(test2.GetSummary());
        Console.WriteLine(test2.GetHomeworkList());

        Console.WriteLine(); // Blank Line

        WritingAssignment test3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(test3.GetSummary());
        Console.WriteLine(test3.GetWritingInformation());
    }
}