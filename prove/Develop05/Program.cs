using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _score = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice: ");

            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine() ?? "";

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";
        int points = ReadInt("What is the amount of points associated with this goal? ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            int count = ReadInt("How many times must this goal be completed? ");
            int bonus = ReadInt("What is the bonus for completing it? ");
            _goals.Add(new ChecklistGoal(name, description, points, count, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully.");
    }

    private static void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    private static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        ListGoals();
        int choice = ReadInt("Which goal did you accomplish? ") - 1;

        if (choice < 0 || choice >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int earned = _goals[choice].RecordEvent();
        _score += earned;

        if (earned == 0)
        {
            Console.WriteLine("That goal is already complete.");
        }
        else
        {
            Console.WriteLine($"Congratulations! You earned {earned} points.");
            Console.WriteLine($"Your new score is {_score}.");
        }
    }

    private static void SaveGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        using StreamWriter output = new StreamWriter(filename);
        output.WriteLine(_score);
        foreach (Goal goal in _goals)
        {
            output.WriteLine(goal.GetSaveString());
        }

        Console.WriteLine("Goals saved successfully.");
    }

    private static void LoadGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                Goal goal = CreateGoalFromSaveString(lines[i]);
                if (goal != null) _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private static Goal CreateGoalFromSaveString(string saveString)
    {
        string[] parts = saveString.Split('|');

        try
        {
            switch (parts[0])
            {
                case "SimpleGoal":
                    return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]),
                                           bool.Parse(parts[4]));
                case "EternalGoal":
                    return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                case "ChecklistGoal":
                    return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                             int.Parse(parts[4]), int.Parse(parts[5]),
                                             int.Parse(parts[6]));
                default:
                    return null;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("A saved goal had invalid data and was skipped.");
            return null;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("A saved goal was incomplete and was skipped.");
            return null;
        }
    }

    private static int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);

        while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
        {
            Console.Write("Please enter a non-negative whole number: ");
        }

        return value;
    }
}
