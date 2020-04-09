using System.Collections.Generic;
using System.Threading;
using HelloWorldMicroServices.Domain.Commands;
using HelloWorldMicroServices.Domain.Handlers;
using HelloWorldMicroServices.Domain.Models;
using HelloWorldMicroServices.Domain.Queries;
using NFluent;
using NSubstitute;
using Xunit;

namespace HelloWorldMicroServices.Domain.Tests
{
    public class ArticleTest
    {
        [Fact]
        public void Should_contains_one_article_when_add_an_article()
        {
            Article article = new Article { Title = "title", Description = "description" };
            IArticleRepository repository = Substitute.For<IArticleRepository>();
            var expected = new List<Article> { article };
            repository.GetArticles().Returns(expected);

            ICommandService commandService = new CommandService(repository);
            commandService.Add(article);
            QueryService queryService=new QueryService();
            QueryServiceHandler queryServiceHandler = new QueryServiceHandler(repository);
            var articles = queryServiceHandler.Handle(queryService,CancellationToken.None);

            Check.That(articles.Result).ContainsExactly(expected);

        }

        [Fact]
        public void Should_contains_zero_element_when_article_is_deleted()
        {
            Article article = new Article { Title = "title", Description = "description" };
            IArticleRepository repository = Substitute.For<IArticleRepository>();
            
            ICommandService commandService=new CommandService(repository);
            commandService.DeleteArticle(article.Title);

            repository.Received().DeleteArticle(article.Title);
            
        }

        [Fact]
        public void Should_update_article_when_calling_update_service()
        {
            Article article = new Article {Title = "title", Description = "description"};
            IArticleRepository repository = Substitute.For<IArticleRepository>();

            ICommandService commandService = new CommandService(repository);
            commandService.UpdateArticle(article);

            repository.Received().UpdateArticle(article);

        }

    }
}
