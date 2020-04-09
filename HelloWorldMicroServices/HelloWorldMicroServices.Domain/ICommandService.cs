using HelloWorldMicroServices.Domain.Models;

namespace HelloWorldMicroServices.Domain
{
    public interface ICommandService
    {
        void Add(Article article);
        void DeleteArticle(string articleTitle);
        void UpdateArticle(Article article);
    }
}