using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Magic Number Game!");

        string choice = "yes";
        while (choice == "yes")
        {

            Random randomGenerator = new Random();
            int compGuess = randomGenerator.Next(0, 100);

            int guessCount = 0;
            int guess = -1;
            while (guess != compGuess){
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                if (guess == compGuess)
                {
                    Console.WriteLine($"The magic number is: {compGuess}");
                    Console.WriteLine("You guessed right!");
                }
                else if (guess > compGuess)
                {
                    Console.WriteLine("Lower!");
                }
                else
                {
                    Console.WriteLine("Higher!");
                }
            }

            Console.WriteLine($"You guessed the number in {guessCount} attempts.");

            Console.Write("Do you want to play again? (yes/no) ");
            choice = Console.ReadLine();
        }

    }
}