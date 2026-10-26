class Word
{
    private string _word;
    private bool _isHidden;

    public string GetWord()
    {
        return _word;
    }

    public void SetWord(string word)
    {
        _word = word;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }

    public void SetIsHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }

    public void Display()
    {
        if (_isHidden)
        {
            Console.Write("____ ");
        }
        else
        {
            Console.Write($"{_word} ");
        }
    }

    
}