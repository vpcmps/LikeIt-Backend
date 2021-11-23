using FluentValidation;
using Likeit.Backend.API.Models;

namespace Likeit.Backend.API.Validations
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Body).NotEmpty();
        }
    }
}
