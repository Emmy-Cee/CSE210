using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split the text into words and create Word objects
        string[] wordTexts = text.Split(' ');
        foreach (string wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int hiddenCount = 0;
        int attempts = 0;
        int maxAttempts = numberToHide * 3; // Prevent infinite loop

        while (hiddenCount < numberToHide && attempts < maxAttempts)
        {
            int randomIndex = _random.Next(_words.Count);
            Word word = _words[randomIndex];

            if (!word.IsHidden())
            {
                word.Hide();
                hiddenCount++;
            }

            attempts++;
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}