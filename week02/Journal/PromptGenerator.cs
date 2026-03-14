using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts;

    // create the collection and seed it with some default questions
    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What was the best part of your day?",
            "What are you grateful for today?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "Describe a challenge you faced and how you handled it.",
            "What did you learn today?",
            "Who made you smile today and why?"
        };
    }

    public string GetRandomPrompt()
    {
        var randomGenerator = new Random();
        int index = randomGenerator.Next(0, _prompts.Count);
        return _prompts[index];
    }

    // optional helper if you want to add more prompts at runtime
    public void AddPrompt(string prompt)
    {
        _prompts.Add(prompt);
    }
}