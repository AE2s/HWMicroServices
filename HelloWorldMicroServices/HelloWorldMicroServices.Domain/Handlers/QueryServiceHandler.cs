using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HelloWorldMicroServices.Domain.Models;
using HelloWorldMicroServices.Domain.Queries;
using MediatR;

namespace HelloWorldMicroServices.Domain.Handlers
{
    public class QueryServiceHandler : IRequestHandler<QueryService, List<Article>>

    {
    private readonly IArticleRepository _articleRepository;

    public QueryServiceHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<List<Article>> Handle(QueryService request, CancellationToken cancellationToken)
    {
        return await _articleRepository.GetArticles();
    }
    }
}
