using System;
using System.Collections.Generic;
//This has an extra feature to randomly choose between several scriptures (not just one)
class Program
{
    static void Main(string[] args)
    {
        List<(Reference reference, string text)> scriptureBank = new List<(Reference, string)>
        {
            (
                new Reference("1 Samuel", 1, 15),
                "And Hannah answered and said, No, my lord, I am a woman of a sorrowful spirit: I have drunk neither wine nor strong drink, but have poured out my soul before the Lord."
            ),
            (
                new Reference("Luke", 1, 38),
                "And Mary said, Behold the handmaid of the Lord; be it unto me according to thy word. And the angel departed from her."
            ),
            (
                new Reference("Doctrine and Covenants", 25, 10),
                "And verily I say unto thee that thou shalt lay aside the things of this world, and seek for the things of a better."
            )
        };

        Random random = new Random();
        int index = random.Next(scriptureBank.Count);

        Reference reference = scriptureBank[index].reference; 
        string text = scriptureBank[index].text;           

        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");

            userInput = Console.ReadLine();

            if (userInput == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Program finished.");
    }
}