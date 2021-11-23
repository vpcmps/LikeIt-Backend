using Likeit.Backend.Application.Services;
using Likeit.Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Likeit.Backend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleAppService _articleAppService;

    public ArticleController(IArticleAppService articleRepository)
    {
        _articleAppService = articleRepository;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Article article)
    {
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _articleAppService.Register(article);
            _articleAppService.Commit();
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
        return Ok(_articleAppService.GetById(id).Likes);
    }

    [HttpPost("{id:int}/like")]
    public IActionResult Post(int id)
    {
        try
        {
            var article = _articleAppService.GetById(id);
            article.Like();
            _articleAppService.Update(article);
            _articleAppService.Commit();
            return Ok(article);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}