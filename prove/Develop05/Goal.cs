abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Protected read-only access keeps the fields private while allowing
    // derived classes to use the shared values.
    protected string Name => _name;
    protected string Description => _description;
    protected int Points => _points;

    public virtual bool IsComplete() => false;

    // Each goal type records an event differently.
    public abstract int RecordEvent();

    public virtual string GetDetails() => $"{Name} ({Description})";

    // The first value identifies the goal type when loading a file.
    public abstract string GetSaveString();
}

class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points,
                      bool isCompleted = false) : base(name, description, points)
    {
        _isCompleted = isCompleted;
    }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override int RecordEvent()
    {
        if (_isCompleted) return 0;
        _isCompleted = true;
        return Points;
    }

    public override string GetDetails()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description})";
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_isCompleted}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetDetails()
    {
        return $"[ ] {Name} ({Description})";
    }

    public override string GetSaveString()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}

class ChecklistGoal : Goal
{
    private int _timesDone;
    private int _goalCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points,
                         int goalCount, int bonusPoints, int timesDone = 0)
        : base(name, description, points)
    {
        _timesDone = timesDone;
        _goalCount = goalCount;
        _bonusPoints = bonusPoints;
    }

    public override bool IsComplete() => _timesDone >= _goalCount;

    public override int RecordEvent()
    {
        if (IsComplete()) return 0;

        _timesDone++;
        int earned = Points;
        if (_timesDone == _goalCount) earned += _bonusPoints;
        return earned;
    }

    public override string GetDetails()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- " +
               $"Completed {_timesDone}/{_goalCount} times";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|" +
               $"{_goalCount}|{_bonusPoints}|{_timesDone}";
    }
}
