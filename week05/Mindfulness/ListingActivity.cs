
public class ListingActivity : Activity
{
    private List<string> _listPrompts;

    public ListingActivity()
        : base("Listing", "This activity helps you reflect on the good things in your life by listing items.")
    {
        _listPrompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_listPrompts.Count);
        return _listPrompts[index];
    }

    public List<string> GetListFromUser(int duration)
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        return items;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        int duration = GetDuration();
        List<string> responses = GetListFromUser(duration);

        Console.WriteLine();
        Console.WriteLine($"You listed {responses.Count} items. Great Job!");

        DisplayEndingMessage();
    }
}