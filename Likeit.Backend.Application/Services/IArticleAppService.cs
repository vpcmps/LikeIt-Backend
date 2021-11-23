using Likeit.Backend.Domain.Entities;

namespace Likeit.Backend.Application.Services
{
    public interface IArticleAppService
    {
        void Register(Article article);
        Article GetById(Guid id);
        void Like(Guid articleId);
    }
}