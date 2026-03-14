/*
 * Journal Program - Additional Creativity Features
 * 
 * This program implements a simple console-based journal application with the following additional creative enhancements:
 * 
 * 1 Custom Prompts Feature: Users can add their own custom prompts to the journal, which are stored
 *    in the PromptGenerator and used alongside default prompts for more personalized journaling.
 * 
 * 2 Session Continuation Loop: After completing a journal session, users are prompted to continue,
 *    allowing multiple journaling sessions within a single program run for extended use.
 * 
 * 3 User-Friendly Menu: A clear and concise menu is provided for users to navigate through the journal options,
 *    enhancing the overall user experience and making it easier to access different features.
 *
 */

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        string choice = "yes";

        // Introductory message of the program       Console.WriteLine("Welcome to the Journal Program! ");
        Console.WriteLine("This program will help you reflect on your day by providing you with prompts to write about. ");
        Console.WriteLine("You can also save your journal entries to a file and load them back later. ");

        Console.Write("Would you like to start your journal? (yes/no) ");
        choice = Console.ReadLine();

        while (choice.ToLower() != "no" && input != "5")
        {
            Console.WriteLine("Great! Let's get started. ");
            Console.Write("Would you like to make custom prompts for your journal? (yes/no) ");
            string customPrompts = Console.ReadLine();
            if (customPrompts.ToLower() == "yes")
            {
                PromptGenerator promptGenerator = new PromptGenerator();
                Console.WriteLine("Enter your custom prompts (type 'done' when finished): ");
                string prompt = Console.ReadLine();

                while (prompt.ToLower() != "done")
                {
                    promptGenerator.AddPrompt(prompt);
                    prompt = Console.ReadLine();
                }
            }

            Journal journal = new Journal();

            Console.WriteLine();
            Console.WriteLine("Please select one of the following options: ");
            // Menu options for the user to select from
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display your Journal entries");
            Console.WriteLine("3. Save your Journal entries to a file");
            Console.WriteLine("4. Load Journal entries from a file");
            Console.WriteLine("5. Exit");

            Console.WriteLine();
            Console.Write("What will you like to do? ");
            input = Console.ReadLine();

            while (input != "5")
            {
                if (input == "1")
                {
                    // Create a new journal entry
                    PromptGenerator promptGenerator = new PromptGenerator();
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    string entryText = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    Entry entry = new Entry();
                    entry._date = date;
                    entry._promptText = prompt;
                    entry._entryText = entryText;
                    journal.AddEntry(entry);
                }
                else if (input == "2")
                {
                    // Display all journal entries
                    journal.DisplayAll();
                }
                else if (input == "3")
                {
                    // Save journal entries to a file
                    Console.Write("Enter the filename to save your journal (e.g., journal.txt): ");
                    string filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                    Console.WriteLine();
                    Console.WriteLine("Journal saved to " + filename);
                    Console.WriteLine();
                }
                else if (input == "4")
                {
                    // Load journal entries from a file
                    Console.Write("Enter the filename to load your journal (e.g., journal.txt): ");
                    string filename = Console.ReadLine();
                    if (File.Exists(filename))
                    {
                        journal.LoadFromFile(filename);
                        Console.WriteLine();
                        Console.WriteLine("Journal loaded from " + filename);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("File " + filename + " not found.");
                    }
                }
                else if (input == "5")
                {
                    // Exit the program
                    Console.WriteLine("Thank you for using the Journal Program! Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select a valid option.");
                }

                // Re-display the menu options after each action
                Console.WriteLine("Please select one of the following options: ");
                Console.WriteLine("1. Write a new journal entry");
                Console.WriteLine("2. Display your Journal entries");
                Console.WriteLine("3. Save your Journal entries to a file");
                Console.WriteLine("4. Load Journal entries from a file");
                Console.WriteLine("5. Exit");

                Console.WriteLine();
                Console.Write("What will you like to do? ");
                input = Console.ReadLine();
            }
        }
    }
}