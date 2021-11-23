using System.ComponentModel.DataAnnotations;

namespace Likeit.Backend.API.Models;

public class Article
{
    internal Article()
    {

    }
    public Article(string title, string body)
    {
        Title = title;
        Body = body;
        Likes = 0;
    }

    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Body { get; set; }
    public int Likes { get; set; }
    
    public void Like()
    {
        Likes++;
    }
}