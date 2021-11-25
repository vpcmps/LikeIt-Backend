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

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id:guid}/likes", Name = "GetArticleLikes")]
    public IActionResult Get(Guid id)
    {
        return Ok(_articleAppService.GetLikesCountByArticleId(id));
    }

    [HttpPost("{id:guid}/like")]
    public IActionResult Post(Guid id)
    {
        try
        {
            _articleAppService.Like(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}