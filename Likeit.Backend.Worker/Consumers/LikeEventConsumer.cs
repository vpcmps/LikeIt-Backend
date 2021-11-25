using Likeit.Backend.Application.Services;
using Likeit.Backend.Domain.Events;
using Likeit.Backend.Domain.Services;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Likeit.Backend.Worker;

public class LikeEventConsumer : IConsumer<LikeEvent>
{
    readonly ILogger<LikeEventConsumer> _logger;
    private readonly IArticleDomainService _articleDomainService;

    public LikeEventConsumer(ILogger<LikeEventConsumer> logger, IArticleDomainService articleAppService)
    {
        _logger = logger;
        this._articleDomainService = articleAppService;
    }

    public Task Consume(ConsumeContext<LikeEvent> context)
    {
        var like = context.Message;
        _articleDomainService.Like(like.ArticleId);

        return Task.CompletedTask;
    }
}