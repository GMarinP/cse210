using System.Text;

class Journal
{
    //attributes
    public List<string> _prompts = new List<string>()
    {
        "What was the best part of your day?",
        "What are you grateful for today?",
        "What is one thing you learned today?",
        "What is a goal you have for tomorrow?",
        "What is something that made you smile today?",
        "What is something that made you sad today?",
        "Who was the most interesting person I interacted with today?",
        "How did I see the hand of the Lord in my life today?",
        "If I had one thing I could do over today, what would it be?"
    };
    public List<Entry> _entries = new List<Entry>();

    //behaviours
    public void AddEntry(Entry entry)
    {
        // add entries to the list
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        // Display the entries currently loaded in the journal.
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($@"
            Entry Date: {entry._date}
            Your Prompt: {entry._prompt}
            Your Response: {entry._response}
            ");
        }
    }

    public void LoadJournal()
    {
        // Ask for a file name so the program works on any computer.
        Console.Write("Enter the file name or path to load: ");
        string filePath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("A file name is required.");
            return;
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"The file '{filePath}' was not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        _entries.Clear();

         foreach (string line in lines.Skip(1)) // Skip the header
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] fields = line.Split(';', 3);

            if (fields.Length != 3)
            {
                Console.WriteLine($"Skipping invalid row: {line}");
                continue;
            }

            Entry entry = new Entry();
            entry._date = fields[0];
            entry._prompt = fields[1];
            entry._response = fields[2];

            _entries.Add(entry);
        }

        Console.WriteLine($"Loaded {_entries.Count} entries.");
        
    }

    public void SaveJournal()
    {
        // Ask for a file name so the program works on any computer.
        Console.Write("Enter the file name or path to save: ");
        string filePath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("A file name is required.");
            return;
        }

        // Save a complete file rather than appending duplicate entries.
        var csv = new StringBuilder();
        csv.AppendLine("date;prompt;response");

        foreach (Entry entry in _entries)
        {
            csv.AppendLine(string.Join(";", entry._date, entry._prompt, entry._response));
        }

        File.WriteAllText(filePath, csv.ToString());
        Console.WriteLine($"Journal saved to {Path.GetFullPath(filePath)}.");
    }
}
