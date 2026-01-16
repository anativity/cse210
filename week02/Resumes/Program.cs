using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1.company = "Microsoft";
        job1._startYear = 2019;
        job1.endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2.company = "Apple";
        job2._startYear = 2022;
        job2.endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume.jobs.Add(job1);
        myResume.jobs.Add(job2);

        myResume.Display();

    }
}