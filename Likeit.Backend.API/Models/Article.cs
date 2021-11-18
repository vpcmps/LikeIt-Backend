namespace Likeit.Backend.API.Models;

public class Article
{
    public Article(string title, string body)
    {
        Title = title;
        Body = body;
        Likes = 0;
    }
    public string Title { get; set; }
    public string Body { get; set; }
    public int Likes { get; set; }

    public void Like()
    {
        Likes++;
    }
}