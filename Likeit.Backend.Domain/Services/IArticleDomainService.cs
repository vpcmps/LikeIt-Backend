using Likeit.Backend.Domain.Entities;

namespace Likeit.Backend.Domain.Services;

public interface IArticleDomainService
{
    void Like(Guid articleId);
    void Register(Article article);
}

