using System.IO;

public class Journal
{
    // backing field for the collection of entries
    public List<Entry> _entries;

    // constructor ensures the list is created before use
    public Journal()
    {
        _entries = new List<Entry>();
    }
    

    // add a single entry
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // display every entry by delegating to Entry.Display()
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // simple persistence format: date|prompt|text on each line
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    // rebuild list from file; existing entries are cleared
    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0];
            string promptText = parts[1];
            string entryText = parts[2];
            Entry entry = new Entry();
            entry._date = date;
            entry._promptText = promptText;
            entry._entryText = entryText;
            _entries.Add(entry);
        }

    }
}