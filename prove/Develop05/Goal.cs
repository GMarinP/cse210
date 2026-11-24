abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public virtual bool IsComplete()
    {
        return false;
    }

    public abstract int RecordEvent();

    public virtual string GetDetails()
    {
       return $"{_name} ({_description})"; 
    } 

    public abstract string GetSaveString();
}

class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points,
                      bool isCompleted = false)
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
        return _points;
    }

    public override string GetDetails()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description})";
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isCompleted}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetDetails()
    {
        return $"[ ] {_name} ({_description})";
    }

    public override string GetSaveString()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}

class ChecklistGoal : Goal
{
    private int _timesDone;
    private int _goalCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points,
                         int goalCount, int bonusPoints, int timesDone = 0)
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
        int earned = _points;
        if (_timesDone == _goalCount) earned += _bonusPoints;
        return earned;
    }

    public override string GetDetails()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description}) -- " +
               $"Completed {_timesDone}/{_goalCount} times";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|" +
               $"{_goalCount}|{_bonusPoints}|{_timesDone}";
    }
}
