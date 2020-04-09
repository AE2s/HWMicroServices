using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWorldMicroServices.Domain.Models;

namespace HelloWorldMicroServices.Domain
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetArticles();
        void AddArticle(Article article);
        void DeleteArticle(string articleTitle);
        void UpdateArticle(Article article);
    }
}