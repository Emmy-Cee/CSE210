using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished!");

        int userNum = 1;
        int sum = 0;
        int max = 0;
        int count = 0;

        while (userNum != 0)
        {
            Console.Write("Enter a number? ");
            string input = Console.ReadLine();
            userNum = int.Parse(input);

            List<int> numbers = new List<int>();
            if (userNum != 0)
            {
                numbers.Add(userNum);
                count++;
            }
            else {
                break;
            }

            foreach (int num in numbers)
            {
                sum += num;
            }

            if (userNum > max)
            {
                max = userNum;
            }

        }
        
        Console.WriteLine($"The sum of the numbers is {sum}");
        Console.WriteLine($"The max number is {max}");

        // Average Calculator
        float average = (float)sum / count;
        Console.WriteLine($"The average of the numbers is {average}");
        
    }
}