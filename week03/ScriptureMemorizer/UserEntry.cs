
public class UserEntry
{
    public Reference GetReferenceFromUser()
    {
        Console.Write("Enter the book name (e.g., John): ");
        string book = Console.ReadLine().Trim();
        if (book == "")
        {
            Console.WriteLine("Book name cannot be empty.");

        }

        Console.Write("Enter the chapter number: ");
        int chapter = int.Parse(Console.ReadLine());
        if (chapter < 1)
        {
            Console.WriteLine("Chapter must be a positive number.");
        }

        Console.Write("Enter the verse(s) (e.g., 16 or 5-6 for range): ");
        string verseInput = Console.ReadLine().Trim();
        bool hasDash = false;
        for (int i = 0; i < verseInput.Length; i++)
        {
            if (verseInput[i] == '-')
            {
                hasDash = true;
                break;
            }
        }

        if (hasDash)
        {
            string[] parts = verseInput.Split('-');
            int startVerse = int.Parse(parts[0]);
            int endVerse = int.Parse(parts[1]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            // Handle single verse
            int verse = int.Parse(verseInput);
            if (verse < 1)
            {
                Console.WriteLine("Verse must be a positive number.");
            }
            return new Reference(book, chapter, verse);
        }
    }

    public string GetScriptureText()
    {
        Console.Write("Enter the scripture text: ");
        string text = Console.ReadLine() + "\n";

        if (text == "")
        {
            Console.WriteLine("Scripture text cannot be empty.");
        }
        return text;
    }

    public string GetDefaultScripture()
    {
        string text = "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life";
        return text + "\n";
    }
}
