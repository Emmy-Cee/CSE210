using System;
using System.Collections.Generic;

class Program
{
    // EXCEEDS REQUIREMENTS: 
    // 1. This program allows users to input their own scriptures
    // for memorization, providing a personalized experience. It supports both single
    // verses and verse ranges, with input validation and helpful prompts.

    // 2. A new class UserEntry is added to handle the user's input after the user has 
    // chosen to add a customized scripture from the user.

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");

        UserEntry entry = new UserEntry();
        Scripture scripture;

        Console.Write("Would you like to enter a personal scripture of your choice (yes/no)? ");
        string userInput = Console.ReadLine().ToLower();

        if (userInput == "yes" || userInput == "y")
        {
            Reference reference = entry.GetReferenceFromUser();
            string text = entry.GetScriptureText();
            scripture = new Scripture(reference, text);
        }
        else
        {
            Reference reference = new Reference("John", 3, 16);
            string text = entry.GetDefaultScripture();
            scripture = new Scripture(reference, text);
        }    

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide more or type 'quit': ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }          

            scripture.HideRandomWords(3);
        }
        Console.WriteLine("\nDone!");
    }
}