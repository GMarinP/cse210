class Scripture
{
    private List<Word> _wordList;
    private string _scripture;
    private Reference _reference;

    public void SetScripture(string scripture)
    {
        _scripture = scripture;
    }

    public List<string> ParseScripture()
    {
        List<string> words = new List<string>();
        string[] splitWords = _scripture.Split(' ');

        foreach (string word in splitWords)
        {
            words.Add(word);
        }

        return words;
    }
}