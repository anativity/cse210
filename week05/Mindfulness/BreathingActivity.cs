
public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            Console.WriteLine();
            ShowCountDown(5);

            Console.WriteLine("Breathe out...");
            Console.WriteLine();
            ShowCountDown(5);

            Console.WriteLine();
            elapsed += 10;
        }

        DisplayEndingMessage();
    }
}