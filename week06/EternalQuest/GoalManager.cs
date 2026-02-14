using System;
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level = 1;
    private int _xp = 0;
    private int _xpToNext = 100;
    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"Score: {_score}  Level: {GetLevelEmoji()}  XP: {_xp}/{_xpToNext}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");

            string choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") SaveGoals();
            else if (choice == "5") LoadGoals();
            else if (choice == "6") running = false;
        }
    }
    private string GetLevelEmoji()
    {
        return _level switch
        {
            1 => "🙂",
            2 => "😊",
            3 => "😁",
            4 => "🤩",
            5 => "😇",
            _ => "😇"
        };
    }
    private void AddXP(int amount)
    {
        _xp += amount;
        while (_xp >= _xpToNext && _level < 5)
        {
            _xp -= _xpToNext;
            _level++;
            _xpToNext += 50;
            Console.WriteLine($"You leveled up! Level {_level} {GetLevelEmoji()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Target: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }
    public void ListGoalDetails()
    {
        int i = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetDetailsString()}");
            i++;
        }
    }
    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int points = _goals[index].RecordEvent();
        _score += points;
        AddXP(points);
    }
    public void SaveGoals()
    {
        using (StreamWriter sw = new StreamWriter("goals.txt"))
        {
            sw.WriteLine(_score);
            sw.WriteLine(_level);
            sw.WriteLine(_xp);
            sw.WriteLine(_xpToNext);

            foreach (Goal g in _goals)
            {
                sw.WriteLine(g.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals()
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _xp = int.Parse(lines[2]);
        _xpToNext = int.Parse(lines[3]);

        for (int i = 4; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                var g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (bool.Parse(parts[4])) g.RecordEvent();
                _goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                var g = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                int completed = int.Parse(parts[6]);
                for (int c = 0; c < completed; c++) g.RecordEvent();
                _goals.Add(g);
            }
        }
    }
}