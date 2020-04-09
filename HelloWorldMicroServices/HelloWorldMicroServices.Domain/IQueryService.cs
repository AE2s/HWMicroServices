using System.Collections.Generic;
using HelloWorldMicroServices.Domain.Models;

namespace HelloWorldMicroServices.Domain
{
    public interface IQueryService
    {
        List<Article> GetArticles();
    }
}