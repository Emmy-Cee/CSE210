using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest - Menu");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. List goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Display score");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice.Trim())
            {
                case "1":
                    Console.Clear();
                    CreateGoal();
                    break;
                case "2":
                    Console.Clear();
                    RecordEvent();
                    break;
                case "3":
                    Console.Clear();
                    ListGoalDetails();
                    break;
                case "4":
                    Console.Clear();
                    SaveGoals();
                    break;
                case "5":
                    Console.Clear();
                    LoadGoals();
                    break;
                case "6":
                    Console.Clear();
                    DisplayPlayerInfo();
                    break;
                case "7":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your current score is: {_score}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose a goal type:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("Selection: ");

        string choice = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter a short name for the goal: ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter a description for the goal: ");
        string description = Console.ReadLine() ?? string.Empty;

        int points;
        while (true)
        {
            Console.Write("Enter the points for completing this goal: ");
            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out points))
            {
                break;
            }
            Console.WriteLine("Please enter a valid number.");
        }

        switch (choice.Trim())
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                int target;
                while (true)
                {
                    Console.Write("Enter the target number of times for this checklist goal: ");
                    string targetInput = Console.ReadLine() ?? string.Empty;
                    if (int.TryParse(targetInput, out target))
                    {
                        break;
                    }
                    Console.WriteLine("Please enter a valid number.");
                }

                int bonus;
                while (true)
                {
                    Console.Write("Enter the bonus points for completing the checklist goal: ");
                    string bonusInput = Console.ReadLine() ?? string.Empty;
                    if (int.TryParse(bonusInput, out bonus))
                    {
                        break;
                    }
                    Console.WriteLine("Please enter a valid number.");
                }

                _goals.Add(new CheckListGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type selection.");
                return;
        }

        Console.WriteLine("Goal added successfully.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals are available to record yet.");
            return;
        }

        Console.WriteLine("Choose a goal to record:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int index;
        while (true)
        {
            Console.Write("Enter the number of the goal you completed: ");
            string indexInput = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(indexInput, out index))
            {
                index -= 1;
                break;
            }
            Console.WriteLine("Please enter a valid number.");
        }

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal goal = _goals[index];
        int pointsEarned = goal.RecordEvent();

        if (pointsEarned == 0)
        {
            Console.WriteLine("That goal is already complete or no points were earned.");
            return;
        }

        _score += pointsEarned;
        Console.WriteLine($"You earned {pointsEarned} points!");
        Console.WriteLine($"Your total score is now: {_score}");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string fileName = Console.ReadLine() ?? "goals.txt";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Goals saved to {fileName}.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string fileName = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Save file '{fileName}' was not found.");
            return;
        }

        _goals.Clear();
        _score = 0;

        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|');

            if (parts.Length == 0)
            {
                continue;
            }

            if (parts[0] == "Score" && parts.Length >= 2 && int.TryParse(parts[1], out int scoreValue))
            {
                _score = scoreValue;
                continue;
            }

            switch (parts[0])
            {
                case "SimpleGoal":
                    if (parts.Length == 5 && int.TryParse(parts[3], out int simplePoints) && bool.TryParse(parts[4], out bool completed))
                    {
                        _goals.Add(new SimpleGoal(parts[1], parts[2], simplePoints, completed));
                    }
                    break;
                case "EternalGoal":
                    if (parts.Length == 4 && int.TryParse(parts[3], out int eternalPoints))
                    {
                        _goals.Add(new EternalGoal(parts[1], parts[2], eternalPoints));
                    }
                    break;
                case "CheckListGoal":
                    if (parts.Length == 7 && int.TryParse(parts[3], out int checklistPoints) && int.TryParse(parts[4], out int target) && int.TryParse(parts[5], out int bonus) && int.TryParse(parts[6], out int amountCompleted))
                    {
                        _goals.Add(new CheckListGoal(parts[1], parts[2], checklistPoints, target, bonus, amountCompleted));
                    }
                    break;
            }
        }

        Console.WriteLine($"Goals loaded from {fileName}. Current score: {_score}");
    }

}
