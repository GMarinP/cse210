class Scripture
{
    private List<Word> _wordList;
    private Reference _reference;

    public Scripture(Reference reference, string scripture)
    {
        _reference = reference;
        _wordList = new List<Word>();
        SetScripture(scripture);
    }

    public void SetScripture(string scripture)
    {
        _wordList.Clear();

        foreach (string text in scripture.Split(' '))
        {
            Word word = new Word();
            word.SetWord(text);
            _wordList.Add(word);
        }
    }

    public List<string> ParseScripture()
    {
        List<string> words = new List<string>();

        foreach (Word word in _wordList)
        {
            words.Add(word.GetWord());
        }

        return words;
    }

    public void Display()
    {
        Console.WriteLine(_reference);

        foreach (Word word in _wordList)
        {
            word.Display();
        }

        Console.WriteLine();
    }

    public void HideRandomWords(int number)
    {
        List<Word> visibleWords = _wordList.Where(word => !word.GetIsHidden()).ToList();
        int count = Math.Min(number, visibleWords.Count);

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Shared.Next(visibleWords.Count);
            visibleWords[randomIndex].SetIsHidden(true);
            visibleWords.RemoveAt(randomIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _wordList.All(word => word.GetIsHidden());
    }
}
