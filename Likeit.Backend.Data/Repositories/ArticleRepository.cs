using Likeit.Backend.Data.Contexts;
using Likeit.Backend.Domain.Entities;
using Likeit.Backend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Likeit.Backend.Data.Repositories;

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

    public Article GetById(Guid id)
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
        _context.Add(article);
    }
}