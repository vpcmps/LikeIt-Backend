using Likeit.Backend.Domain.Events;
using Likeit.Backend.Domain.Services;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Likeit.Backend.Worker;

public class RegisterArticleEventConsumer : IConsumer<RegisterArticleEvent>
{
    readonly ILogger<RegisterArticleEvent> _logger;
    private readonly IArticleDomainService _articleDomainService;

    public RegisterArticleEventConsumer(ILogger<RegisterArticleEvent> logger, IArticleDomainService articleAppService)
    {
        _logger = logger;
        this._articleDomainService = articleAppService;
    }

    public Task Consume(ConsumeContext<RegisterArticleEvent> context)
    {
        var articleEvent = context.Message;
        _articleDomainService.Register(new Domain.Entities.Article(articleEvent.Title, articleEvent.Body));

        return Task.CompletedTask;
    }
}