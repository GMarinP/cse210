class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public virtual void displayGoal()
    {
        Console.WriteLine($"Goal: {_name}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Points: {_points}");
    }

    public virtual void GetSaveString()
    {
        Console.WriteLine($"{_name},{_description},{_points}");
    }

    public int GetPoints()
    {
        return _points;
    }
}

class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isCompleted = false;
    }

    override public void displayGoal()
    {
        base.displayGoal();
        Console.WriteLine($"Completed: {_isCompleted}");
    }

    override public void GetSaveString()
    {
        Console.WriteLine($"SimpleGoal,{_name},{_description},{_points},{_isCompleted}");
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    override public void displayGoal()
    {
        base.displayGoal();
        Console.WriteLine("This goal can be completed multiple times.");
    }

    override public void GetSaveString()
    {
        Console.WriteLine($"EternalGoal,{_name},{_description},{_points}");
    }
}

class ChecklistGoal : Goal
{
    private int _timesDone;
    private int _goalCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int goalCount, int bonusPoints) : base(name, description, points)
    {
        _timesDone = 0;
        _goalCount = goalCount;
        _bonusPoints = bonusPoints;
    }
}