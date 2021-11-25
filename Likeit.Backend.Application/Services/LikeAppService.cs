using Likeit.Backend.Domain.Entities;
using Likeit.Backend.Domain.Events;
using Likeit.Backend.Domain.Repositories;
using MassTransit;

namespace Likeit.Backend.Application.Services
{
    public class ArticleAppService : IArticleAppService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IRedisRepository _redisRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public ArticleAppService(IArticleRepository articleRepository, IRedisRepository redisRepository, IPublishEndpoint publishEndpoint)
        {
            _articleRepository = articleRepository;
            _redisRepository = redisRepository;
            _publishEndpoint = publishEndpoint;
        }

        public int GetLikesCountByArticleId(Guid id)
        {

            var likes = _redisRepository.GetByKey(GetLikesCacheKey(id));

            if (string.IsNullOrEmpty(likes))
            {
                var article = _articleRepository.GetById(id);

                if (article is null)
                    throw new Exception("Article not found");

                return article.Likes;
            }

            return int.Parse(likes);
        }

        public void Like(Guid articleId)
        {
            _publishEndpoint.Publish(new LikeEvent()
            {
                ArticleId = articleId
            });
        }

        public void Register(Article article)
        {
            _publishEndpoint.Publish(new RegisterArticleEvent()
            {
                Title = article.Title,
                Body = article.Body
            });
        }
        private static string GetLikesCacheKey(Guid id)
        {
            return $"LikeNumber-{id}";
        }
    }
}
