using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. " +
            "Clear your mind and focus on your breathing.";
        _duration = 30;
    }

    public void Run()
    {
        Console.WriteLine("Enter duration in seconds for the breathing activity:");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer for the duration:");
        }

        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(4);
            if (DateTime.Now >= endTime) break;

            Console.WriteLine("Breathe out...");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}