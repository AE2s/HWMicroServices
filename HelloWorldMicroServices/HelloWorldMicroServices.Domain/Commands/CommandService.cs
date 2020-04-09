using HelloWorldMicroServices.Domain.Models;

namespace HelloWorldMicroServices.Domain.Commands
{
    public class CommandService : ICommandService
    {
        private readonly IArticleRepository _articleRepository;

        public CommandService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Add(Article article)
        {
            _articleRepository.AddArticle(article);
        }

        public void DeleteArticle(string articleTitle)
        {
            _articleRepository.DeleteArticle(articleTitle);
        }

        public void UpdateArticle(Article article)
        {
            _articleRepository.UpdateArticle(article);
        }
    }
}