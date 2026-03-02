using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string gradeSign = "";
        if (grade % 10 >= 7)
        {
            gradeSign = "+";
        }
        else if (grade % 10 < 3)
        {
            gradeSign = "-";
        }
        else{
            gradeSign = "";
        }

        if (grade >= 90)
        {
            Console.WriteLine($"Nice try, Your grade percentage {grade} is an A{gradeSign}");
        }
        else if (grade >= 80)
        {
            Console.WriteLine($"Great!!, Your grade percentage {grade} is a B{gradeSign}");
        }
        else if (grade >= 70)
        {
            Console.WriteLine($"Good!, Your grade percentage {grade} is a C{gradeSign}");
        }
        else if (grade >= 60)
        {
            Console.WriteLine($"Your grade percentage {grade} is a D{gradeSign}. Keep Trying Harder");
        }
        else
        {
            Console.WriteLine($"Your grade percentage {grade} is an F{gradeSign}. Don't give up, try again!");
        }

    }
}