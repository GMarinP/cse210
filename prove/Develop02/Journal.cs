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
    }

    public void LoadJournal()
    {
        // ask the user for a file name and it replaces the current journal with that file
    }

    public void SaveJournal()
    {
        // ask the user for a file name and saves the journal to that file in csv format
        var csv = new StringBuilder();

        foreach (Entry entry in _entries)
        {
            var first = entry._date.ToString();
            var second = entry._prompt.ToString();
            var third = entry._response.ToString();
            var newLine = string.Format("{0},{1},{2}", first, second, third);
            csv.AppendLine(newLine); 

        }

        File.AppendAllText("C:\\Users\\giova\\OneDrive\\BYU-I\\CSE 210\\cse210\\prove\\Develop02\\journal.csv", csv.ToString());
    }
}