class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void ShowPrologue()
    {
        Console.WriteLine($"You are starting a {_name} for {_duration} seconds.");
        Console.WriteLine(_description);
    }

    public void ShowEpilogue()
    {
        Console.WriteLine($"Good job! You have completed the {_name} for {_duration} seconds.");
    }

    public void ShowSpinner(int duration)
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        string[] symbols = { "-", "/", "|", "\\" };
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(symbols[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            index = (index + 1) % symbols.Length;
        }
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", duration)
    {

    }

    public void Run()
    {
        ShowPrologue();
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            BreatheIn();

            if (DateTime.Now < endTime)
            {
                BreatheOut();
            }
        }

        ShowSpinner(3);
        ShowEpilogue();
    }

    public void BreatheIn()
    {
        Console.WriteLine("Breathe in...");
        ShowSpinner(4);
    }

    public void BreatheOut()
    {
        Console.WriteLine("Breathe out...");
        ShowSpinner(6);
    }
}

class ReflectionActivity : Activity
{
    private Random _random = new Random();
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _subprompts = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration)
    {
        
    }

    public void RandomPrompt(List<string> prompts)
    {
        if (prompts.Count == 0)
        {
            return;
        }

        int promptIndex = _random.Next(prompts.Count);

        Console.WriteLine(prompts[promptIndex]);

        // Remove the prompt so it cannot be selected again
        prompts.RemoveAt(promptIndex);
    }

    public void Run()
    {
        ShowPrologue();
        ShowSpinner(3);
        RandomPrompt(_prompts);
        Console.WriteLine("Take a moment to reflect on this prompt.");
        ShowSpinner(5);

        List<string> availableSubprompts = new List<string>(_subprompts);
        RandomPrompt(availableSubprompts);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime && availableSubprompts.Count > 0)
        {
            RandomPrompt(availableSubprompts);
            ShowSpinner(7);
        }

        ShowSpinner(3);
        ShowEpilogue();
    }
}

class ListingActivity : Activity
{

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
    {
        
    }
    
    public void RandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[promptIndex]);
    }

    public int CountItems()
    {
        int count = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.ReadLine();
            count++;
        }

        return count;
    }

    public void Run()
    {
        Console.Clear();

        ShowPrologue();
        ShowSpinner(6);
        RandomPrompt();
        Console.WriteLine("Take a moment to reflect on this prompt.");
        ShowSpinner(5);

        Console.WriteLine("List as many items as you can:");
        int count = CountItems();
        Console.WriteLine($"You listed {count} items.");
        ShowSpinner(3);
        ShowEpilogue();
    }

}