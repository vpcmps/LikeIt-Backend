using FluentValidation;
using Likeit.Backend.Domain.Entities;

namespace Likeit.Backend.Domain.Validators
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Body).NotEmpty();
        }
    }
}
