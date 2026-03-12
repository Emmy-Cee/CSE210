using System;

class Program
{    
     static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "BYU-Idaho";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2020;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._company = "Google";
        job2._jobTitle = "Senior Software Engineer";
        job2._startYear = 2024;
        job2._endYear = 2026;

        Resumes myResume = new Resumes();
        myResume._name = "Emmanuel Anietie Atat";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();

    }
}