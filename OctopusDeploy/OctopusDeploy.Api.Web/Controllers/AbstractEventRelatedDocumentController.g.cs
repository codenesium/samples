using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        public abstract class AbstractEventRelatedDocumentController: AbstractApiController
        {
                protected IEventRelatedDocumentService EventRelatedDocumentService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractEventRelatedDocumentController(
                        ServiceSettings settings,
                        ILogger<AbstractEventRelatedDocumentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEventRelatedDocumentService eventRelatedDocumentService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.EventRelatedDocumentService = eventRelatedDocumentService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventRelatedDocumentResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEventRelatedDocumentResponseModel> response = await this.EventRelatedDocumentService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEventRelatedDocumentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiEventRelatedDocumentResponseModel response = await this.EventRelatedDocumentService.Get(id);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                [HttpPost]
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiEventRelatedDocumentResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiEventRelatedDocumentRequestModel model)
                {
                        CreateResponse<ApiEventRelatedDocumentResponseModel> result = await this.EventRelatedDocumentService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/EventRelatedDocuments/{result.Record.Id.ToString()}");
                                return this.Ok(result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPost]
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiEventRelatedDocumentResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEventRelatedDocumentRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiEventRelatedDocumentResponseModel> records = new List<ApiEventRelatedDocumentResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiEventRelatedDocumentResponseModel> result = await this.EventRelatedDocumentService.Create(model);

                                if (result.Success)
                                {
                                        records.Add(result.Record);
                                }
                                else
                                {
                                        return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                                }
                        }

                        return this.Ok(records);
                }

                [HttpPut]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiEventRelatedDocumentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEventRelatedDocumentRequestModel model)
                {
                        ActionResponse result = await this.EventRelatedDocumentService.Update(id, model);

                        if (result.Success)
                        {
                                ApiEventRelatedDocumentResponseModel response = await this.EventRelatedDocumentService.Get(id);

                                return this.Ok(response);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpDelete]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(void), 204)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Delete(int id)
                {
                        ActionResponse result = await this.EventRelatedDocumentService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpGet]
                [Route("getEventId/{eventId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventRelatedDocumentResponseModel>), 200)]
                public async virtual Task<IActionResult> GetEventId(string eventId)
                {
                        List<ApiEventRelatedDocumentResponseModel> response = await this.EventRelatedDocumentService.GetEventId(eventId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getEventIdRelatedDocumentId/{eventId}/{relatedDocumentId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventRelatedDocumentResponseModel>), 200)]
                public async virtual Task<IActionResult> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId)
                {
                        List<ApiEventRelatedDocumentResponseModel> response = await this.EventRelatedDocumentService.GetEventIdRelatedDocumentId(eventId, relatedDocumentId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>ccad4178038d50cfb073bf6fedc7f51b</Hash>
</Codenesium>*/