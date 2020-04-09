using System.Collections.Generic;
using HelloWorldMicroServices.Domain.Models;
using MediatR;

namespace HelloWorldMicroServices.Domain.Queries
{
    public class QueryService : IQueryService,IRequest<List<Article>>
    {
        
    }
}