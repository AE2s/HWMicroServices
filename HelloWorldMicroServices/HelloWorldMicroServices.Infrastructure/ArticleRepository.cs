using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldMicroServices.Domain;
using HelloWorldMicroServices.Domain.Models;

namespace HelloWorldMicroServices.Infrastructure
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly List<Article> _articles;

        public ArticleRepository()
        {
            _articles=new List<Article>
            {
                new Article
                {
                    Title = "React",
                    Description = "framework js",
                    Author = new Author
                    {
                        FirstName = "Fb",
                        LastName = string.Empty
                    },
                    Tags = new List<Tag>(){new Tag
                        {
                            Name = "framework"
                        }
                    }
                }
            };
        }
        public async Task<List<Article>> GetArticles()
        {
            return await Task.Run(() => _articles);
        }

        public void AddArticle(Article article)
        {
            _articles.Add(article);
        }

        public void DeleteArticle(string articleTitle)
        {
            _articles.RemoveAll(x => x.Title == articleTitle);
        }

        public void UpdateArticle(Article article)
        {
            var articleToUpdate =_articles.FirstOrDefault(a => a.Title == article.Title);
            if (articleToUpdate != null)
            {
                articleToUpdate.Description = article.Description;
            }
            
        }
    }
}
