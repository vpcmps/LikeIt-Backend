using Likeit.Backend.Domain.Entities;

namespace Likeit.Backend.Domain.Repositories;

public interface IArticleRepository
{
    IList<Article> List();
    Article GetById(Guid id);
    void Update(Article article);
    bool Commit();
    void Register(Article article);
}