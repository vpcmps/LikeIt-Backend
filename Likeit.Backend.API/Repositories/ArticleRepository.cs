using Likeit.Backend.API.Contexts;
using Likeit.Backend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Likeit.Backend.API.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly LikeitContext _context;

    public ArticleRepository(LikeitContext context)
    {
        _context = context;
    }

    public IList<Article> List()
    {
        return _context.Set<Article>().ToList();
    }

    public Article GetById(int id)
    {
        return _context.Set<Article>().FirstOrDefault(x => x.Id == id) ?? throw new Exception();
    }

    public void Update(Article article)
    {
        _context.Entry(article).State = EntityState.Modified;
    }

    public bool Commit()
    {
        return _context.SaveChanges() >= 0;
    }

    public void Register(Article article)
    {
        throw new NotImplementedException();
    }
}