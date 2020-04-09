using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldMicroServices.Domain;
using HelloWorldMicroServices.Domain.Commands;
using HelloWorldMicroServices.Domain.Models;
using HelloWorldMicroServices.Domain.Queries;
using MediatR;
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
        private readonly IMediator _mediator;

        public ArticleController(ICommandService commandService, IQueryService queryService, IMediator mediator)
        {
            _commandService = commandService;
            _queryService = queryService;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(_queryService);
            return Ok(result);
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