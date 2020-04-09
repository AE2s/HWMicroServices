using System.Collections.Generic;
using HelloWorldMicroServices.Domain.Models;

namespace HelloWorldMicroServices.Domain
{
    public class QueryService : IQueryService
    {
        private readonly IArticleRepository _articleRepository;

        public QueryService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<Article> GetArticles()
        {
            return _articleRepository.GetArticles();
        }
    }
}