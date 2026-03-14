public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        // use the stored date instead of always using "now"
        Console.WriteLine();
        Console.WriteLine($"Date: {_date} - prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
}