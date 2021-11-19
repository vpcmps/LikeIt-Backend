using Likeit.Backend.API.Models;
using Likeit.Backend.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Likeit.Backend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;

    public ArticleController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    [HttpGet(Name = "GetArticles")]
    public IEnumerable<Article> Get()
    {
        return _articleRepository.List();
    }

    [HttpPost("{id:int}/like")]
    public IActionResult Post(int id)
    {
        var article = _articleRepository.GetById(id);
        return Ok(article);
    }
}