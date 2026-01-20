using System;
using System.Reflection.Metadata.Ecma335;
class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        // job1._jobTitle = "Software Engineer";
        // job1._company = "Microsoft";
        // job1._startYear = 2019;
        // job1._endYear = 2022;

        // Job job2 = new Job();
        // job2._jobTitle = "Manager";
        // job2._company = "Apple";
        // job2._startYear = 2022;
        // job2._endYear = 2023;

        // Job _job3 = new Job(); 

        Resume myResume = new Resume();
        myResume._fullName = "Allison Rose";

        
        myResume.jobs.Add(job1);
        // myResume.jobs.Add(job2);
        // myResume.jobs.Add(_job3);

        myResume.Display();

    }
}