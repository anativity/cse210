public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _scripture;

    public Entry(string prompt, string response, string scripture)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _response = response;
        _scripture = scripture;
    }

    public string SaveString()
    {
        return $"{_date}|{_prompt}|{_response}|{_scripture}";
    }

    public static Entry LoadFromString(string line)
    {
        string[] parts = line.Split('|');
        Entry e = new Entry(parts[1], parts[2], parts[3]);
        e._date = parts[0];
        return e;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Scripture of the Day: {_scripture}");
        Console.WriteLine();
    }
}