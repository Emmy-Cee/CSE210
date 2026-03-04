using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome(){
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName(){
            Console.Write("Please enter your name: ");
            string input = Console.ReadLine();
            return input;
        }

        static int PromptUserNumber(){
            Console.Write("Please enter your number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            return number;
        }

        static int SquareNumber(int number){
            int result = number * number;
            return result;
        }

        static void DisplayResult()
        {
            string name = PromptUserName();
            int number = PromptUserNumber();
            int squaredNumber = SquareNumber(number);
            Console.WriteLine($"{name}, the square of your number is: {squaredNumber}");
        }

        DisplayWelcome();
        DisplayResult();
    }
}