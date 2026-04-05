using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;
        int totalTimeSpent = 0; // Tracks total seconds spent on all activities
        int activityCount = 0;  // Tracks number of activities completed

        // Exceeds core requirements: Added a session summary dashboard to track and display total time spent and number of activities completed across the session.

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option (1-4): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var breathing = new BreathingActivity();
                breathing.Run();
                totalTimeSpent += breathing.GetDuration();
                activityCount++;
            }
            else if (choice == "2")
            {
                var reflecting = new ReflectingActivity();
                reflecting.Run();
                totalTimeSpent += reflecting.GetDuration();
                activityCount++;
            }
            else if (choice == "3")
            {
                var listing = new ListingActivity();
                listing.Run();
                totalTimeSpent += listing.GetDuration();
                activityCount++;
            }
            else if (choice == "4")
            {
                keepRunning = false;
            }
            else
            {
                Console.WriteLine("Please enter a valid option (1-4). Press Enter to try again.");
                Console.ReadLine();
            }

            if (keepRunning)
            {
                Console.WriteLine("Press Enter to return to the main menu.");
                Console.ReadLine();
            }
        }

        // Display session summary
        Console.WriteLine("\nSession Summary:");
        Console.WriteLine($"Total mindfulness time: {totalTimeSpent} seconds across {activityCount} activities.");

        Console.WriteLine("Thanks for using the Mindfulness Program. Goodbye!");
    }
}