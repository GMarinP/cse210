class Reference
{
    private string _book;
    private int _chapter;
    private int _verseBeginning;
    private int _verseEnding;

    public Reference(string book, int chapter, int firstVerse, int lastverse)
    {
        _book = book;
        _chapter = chapter;
        _verseBeginning = firstVerse;
        _verseEnding = lastverse;
    }

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseBeginning = verse;
        _verseEnding = 0;
    
    }

    public void Display()
    {
        Console.WriteLine(this);
    }

    public override string ToString()
    {
        return _verseEnding == 0
            ? $"{_book} {_chapter}:{_verseBeginning}"
            : $"{_book} {_chapter}:{_verseBeginning}-{_verseEnding}";
    }
}
