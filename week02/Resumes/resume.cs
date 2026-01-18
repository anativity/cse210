public class Resume
{
    public string _fullName = "";

    public List<Job> jobs = new List<Job>();
    
    public Resume()
    {
        
    }
    public void Display()
    {
        Console.WriteLine($"Resume for Name: {_fullName}");
        Console.WriteLine("Jobs:");

        foreach(Job j in jobs)
        {
            j.Display();
        }
    }
}