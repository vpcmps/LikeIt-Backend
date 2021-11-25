using Likeit.Backend.Domain.Entities;
using Likeit.Backend.Domain.Repositories;
using Likeit.Backend.Domain.Validators;

namespace Likeit.Backend.Domain.Services;
public class ArticleDomainService : IArticleDomainService
{

    private readonly IArticleRepository _articleRepository;
    private readonly IRedisRepository _redisRepository;

    public ArticleDomainService(IArticleRepository articleRepository, IRedisRepository redisRepository)
    {
        _articleRepository = articleRepository;
        _redisRepository = redisRepository;
    }
    public void Like(Guid articleId)
    {
        var article = _articleRepository.GetById(articleId);
        article.Like();
        _articleRepository.Update(article);
        _articleRepository.Commit();
        _redisRepository.SetString(GetLikesCacheKey(articleId), article.Likes.ToString());
    }

    public void Register(Article article)
    {
        article.Id = Guid.NewGuid();

        var articleValidator = new ArticleValidator();
        var result = articleValidator.Validate(article);
        if (result.IsValid)
        {
            
            _articleRepository.Register(article);
            _articleRepository.Commit();
            _redisRepository.SetString(GetLikesCacheKey(article.Id), article.Likes.ToString());
        }
    }
    private static string GetLikesCacheKey(Guid id)
    {
        return $"LikeNumber-{id}";
    }
}

