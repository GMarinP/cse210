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
        // read the csv file and display the entries in a readable format
        string filePath = "C:\\Users\\giova\\OneDrive\\BYU-I\\CSE 210\\cse210\\prove\\Develop02\\journal.csv";
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines.Skip(1))
        {
            string[] fields = line.Split(';');
            Console.WriteLine($@"
            Entry Date: {fields[0]}
            Your Prompt: {fields[1]}
            Your Response: {fields[2]}
            ");
        }
    }

    public void LoadJournal()
    {
        // ask the user for a file name and it replaces the current journal with that file
        Console.WriteLine("Paste the path of the file you want to upload");
        string filePath = Console.ReadLine();

        string[] lines = File.ReadAllLines(filePath);
        _entries.Clear();

         foreach (string line in lines.Skip(1)) // Skip the header
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] fields = line.Split(';');

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
        // ask the user for a file name and saves the journal to that file in csv format
        var csv = new StringBuilder();
        string filePath = "C:\\Users\\giova\\OneDrive\\BYU-I\\CSE 210\\cse210\\prove\\Develop02\\journal.csv";


        foreach (Entry entry in _entries)
        {
            var first = entry._date.ToString();
            var second = entry._prompt.ToString();
            var third = entry._response.ToString();
            var newLine = string.Join(";", first, second, third);
            csv.AppendLine(newLine); 
        }

        File.AppendAllText(filePath, csv.ToString());
    }
}