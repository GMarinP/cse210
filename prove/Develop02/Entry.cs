using System;

class Entry
{
    //attributes
    public string _date;
    public string _prompt;
    public string _response;

    Journal journal = new Journal();

    //behaviours

    public void GetResponse()
    {

        _response = Console.ReadLine();
    }

    public void GetDate()
    {
        Console.WriteLine("What day is it today?");
        _date = Console.ReadLine();
    }

    public void GiveRandomPrompt()
    {
        Random r = new Random();
        int index = r.Next(0, 9);
        _prompt = journal._prompts[index];
        Console.WriteLine(_prompt);
    }

}