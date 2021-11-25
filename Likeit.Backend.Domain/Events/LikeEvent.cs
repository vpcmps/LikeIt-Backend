using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likeit.Backend.Domain.Events;
public class LikeEvent
{
    public Guid ArticleId { get; set; }
}

public class RegisterArticleEvent
{
    public string Title { get; set; }
    public string Body { get; set; }
}

