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
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write("-");
            Thread.Sleep(500);
            Console.Write("\b \b"); 
            Console.Write("/"); 
            Thread.Sleep(500);
            Console.Write("\b \b"); 
            Console.Write("|"); 
            Thread.Sleep(500);
            Console.Write("\b \b"); 
            Console.Write("\\"); 
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

    public ReflectionActivity(int duration) : base("Reflection Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
    {
        
    }

    public void RandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[promptIndex]);
    }

    public void Run()
    {
        
    }
}

class ListingActivity : Activity
{

    private List<string> _prompts = new List<string>
    {
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
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

    public void CountItems()
    {
        
    }

    public void Run()
    {
      
    }
}