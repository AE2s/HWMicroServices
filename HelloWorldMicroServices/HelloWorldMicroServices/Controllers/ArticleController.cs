using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldMicroServices.Domain;
using HelloWorldMicroServices.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldMicroServices.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ICommandService _commandService;
        private readonly IQueryService _queryService;

        public ArticleController(ICommandService commandService, IQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpGet]
        [Route("items")]
        public IEnumerable<Article> Get()
        {
            return _queryService.GetArticles();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]Article article)
        {
            _commandService.Add(article);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete([FromBody]string title)
        {
            _commandService.DeleteArticle(title);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public ActionResult Update([FromBody]Article article)
        {
            _commandService.UpdateArticle(article);
            return Ok();
        }
    }
}