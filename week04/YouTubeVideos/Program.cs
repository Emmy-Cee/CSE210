using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video();
        video1._title = "C# OOP Tutorial";
        video1._author = "Code Academy";
        video1._length = 600;

        video1._comments.Add(new Comment("John", "Very helpful video!"));
        video1._comments.Add(new Comment("Mary", "I learned a lot."));
        video1._comments.Add(new Comment("Paul", "Great explanation."));
        video1._comments.Add(new Comment("Grace", "Please make more."));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video();
        video2._title = "Understanding Classes";
        video2._author = "Dev Simplified";
        video2._length = 450;

        video2._comments.Add(new Comment("Alex", "Nice and clear."));
        video2._comments.Add(new Comment("James", "This helped me."));
        video2._comments.Add(new Comment("Sarah", "Awesome tutorial."));
        video2._comments.Add(new Comment("David", "Good examples."));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video();
        video3._title = "Encapsulation in C#";
        video3._author = "Programming Hub";
        video3._length = 520;

        video3._comments.Add(new Comment("Mike", "Now I understand."));
        video3._comments.Add(new Comment("Linda", "Very detailed."));
        video3._comments.Add(new Comment("Chris", "Thanks a lot."));
        video3._comments.Add(new Comment("Emma", "Well explained."));

        videos.Add(video3);

        // Display Videos
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"{comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}