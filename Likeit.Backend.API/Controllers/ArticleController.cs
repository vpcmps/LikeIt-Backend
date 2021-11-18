using Likeit.Backend.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Likeit.Backend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
   
    private List<Article> Articles = new()
    {
        new Article("Lorem Ipsum 1", "Lorem ipsum dolor set"),
        new Article("Lorem Ipsum 2", "Lorem ipsum dolor set"),
        new Article("Lorem Ipsum 3", "Lorem ipsum dolor set")
    };

    [HttpGet(Name = "GetArticles")]
    public IEnumerable<Article> Get()
    {
        return Articles;
    }

    public IActionResult Post(int id)
    {
        Articles[id].Like();
        return Ok();
    }
}