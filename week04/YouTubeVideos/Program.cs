using System;

public class Program
{
    static void Main(string[] args)
    {
       
        Video video1 = new Video("Gethsemane", "Tabernacle Choir", 321);
        Video video2 = new Video("Amazing Grace", "Tabernacle Choir", 634);
        Video video3 = new Video("Angels From Realms of Glory", "Tabernacle Choir", 405);

        video1.NewComment(new Comment("josephmos", "Happy Easter"));
        video1.NewComment(new Comment("ryanstewart", "You can just feel the spirit"));
        video1.NewComment(new Comment("ithinki8", "just beautiful"));

        video2.NewComment(new Comment("chris357", "blown away"));
        video2.NewComment(new Comment("raymondk", "A beautiful song"));
        video2.NewComment(new Comment("bradrub", "I am a Christian"));

        video3.NewComment(new Comment("mereditch55", "Gloria in excelsis deo"));
        video3.NewComment(new Comment("irishnicol", "masterpiece makes me cry"));
        video3.NewComment(new Comment("tashaorm", "I am not religious; this makes me emotional"));

        List<Video> videos = new List<Video>() { video1, video2, video3 };

        foreach (Video v in videos)
        {
            Console.WriteLine(v.GetDisplayVideo());
            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine(c.GetDisplayComments());
            }
            Console.WriteLine();
        }
    }
}