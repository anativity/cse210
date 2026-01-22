using System;
using System.Collections.Generic;
class Program
{
    public static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public static void Main(string[] args )
    {
        Journal journal = new Journal();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = GetRandomPrompt();
                Console.WriteLine(prompt);

                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Console.Write("Scripture of the Day: ");
                string scripture = Console.ReadLine();

                Entry entry = new Entry(prompt, response, scripture);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
        }
    }

    public static string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
}