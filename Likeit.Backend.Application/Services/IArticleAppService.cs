using Likeit.Backend.Domain.Entities;

namespace Likeit.Backend.Application.Services
{
    public interface IArticleAppService
    {
        void Register(Article article);
        int GetLikesCountByArticleId(Guid id);
        void Like(Guid articleId);
    }
}