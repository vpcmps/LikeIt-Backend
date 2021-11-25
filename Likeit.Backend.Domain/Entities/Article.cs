namespace Likeit.Backend.Domain.Entities;

public class Article
{
    internal Article()
    {
        Title = string.Empty;
        Body = string.Empty;
    }
    public Article(string title, string body)
    {
        Title = title;
        Body = body;
        Likes = 0;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int Likes { get; set; }
    
    public void Like()
    {
        Likes++;
    }
}