using System.Collections.Generic;
using HelloWorldMicroServices.Domain.Models;

namespace HelloWorldMicroServices.Domain
{
    public interface IArticleRepository
    {
        List<Article> GetArticles();
        void AddArticle(Article article);
        void DeleteArticle(string articleTitle);
        void UpdateArticle(Article article);
    }
}