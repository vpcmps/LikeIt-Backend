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

    [HttpPost]
    public IActionResult Post([FromBody] Article article)
    {
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _articleRepository.Register(article);
            _articleRepository.Commit();
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id:int}/likes", Name = "GetArticleLikes")]
    public IActionResult Get(int id)
    {
        return Ok(_articleRepository.GetById(id).Likes);
    }

    [HttpPost("{id:int}/like")]
    public IActionResult Post(int id)
    {
        try
        {
            var article = _articleRepository.GetById(id);
            article.Like();
            _articleRepository.Update(article);
            _articleRepository.Commit();
            return Ok(article);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}