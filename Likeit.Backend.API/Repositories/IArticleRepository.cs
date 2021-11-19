using Likeit.Backend.API.Models;

namespace Likeit.Backend.API.Repositories;

public interface IArticleRepository
{
    IList<Article> List();
    Article GetById(int id);
    void Update(Article article);
    bool Commit();
}