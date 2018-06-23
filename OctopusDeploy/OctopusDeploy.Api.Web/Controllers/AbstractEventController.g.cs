using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
        public abstract class AbstractEventController : AbstractApiController
        {
                protected IEventService EventService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractEventController(
                        ApiSettings settings,
                        ILogger<AbstractEventController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEventService eventService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.EventService = eventService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEventResponseModel> response = await this.EventService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEventResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiEventResponseModel response = await this.EventService.Get(id);

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
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiEventResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEventRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiEventResponseModel> records = new List<ApiEventResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiEventResponseModel> result = await this.EventService.Create(model);

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

                [HttpPost]
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiEventResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiEventRequestModel model)
                {
                        CreateResponse<ApiEventResponseModel> result = await this.EventService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Events/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiEventResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiEventRequestModel> patch)
                {
                        ApiEventResponseModel record = await this.EventService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiEventRequestModel model = new ApiEventRequestModel();
                                model.SetProperties(model.AutoId,
                                                    model.Category,
                                                    model.EnvironmentId,
                                                    model.JSON,
                                                    model.Message,
                                                    model.Occurred,
                                                    model.ProjectId,
                                                    model.RelatedDocumentIds,
                                                    model.TenantId,
                                                    model.UserId,
                                                    model.Username);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.EventService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiEventResponseModel response = await this.EventService.Get(id);

                                        return this.Ok(response);
                                }
                                else
                                {
                                        return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                                }
                        }
                }

                [HttpPut]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiEventResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiEventRequestModel model)
                {
                        ActionResponse result = await this.EventService.Update(id, model);

                        if (result.Success)
                        {
                                ApiEventResponseModel response = await this.EventService.Get(id);

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
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.EventService.Delete(id);

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
                [Route("getAutoId/{autoId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventResponseModel>), 200)]
                public async virtual Task<IActionResult> GetAutoId(long autoId)
                {
                        List<ApiEventResponseModel> response = await this.EventService.GetAutoId(autoId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getIdRelatedDocumentIdsOccurredCategoryAutoId/{id}/{relatedDocumentIds}/{occurred}/{category}/{autoId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventResponseModel>), 200)]
                public async virtual Task<IActionResult> GetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId)
                {
                        List<ApiEventResponseModel> response = await this.EventService.GetIdRelatedDocumentIdsOccurredCategoryAutoId(id, relatedDocumentIds, occurred, category, autoId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId/{id}/{relatedDocumentIds}/{projectId}/{environmentId}/{category}/{userId}/{occurred}/{tenantId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventResponseModel>), 200)]
                public async virtual Task<IActionResult> GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId)
                {
                        List<ApiEventResponseModel> response = await this.EventService.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(id, relatedDocumentIds, projectId, environmentId, category, userId, occurred, tenantId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getIdOccurred/{id}/{occurred}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventResponseModel>), 200)]
                public async virtual Task<IActionResult> GetIdOccurred(string id, DateTimeOffset occurred)
                {
                        List<ApiEventResponseModel> response = await this.EventService.GetIdOccurred(id, occurred);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{eventId}/EventRelatedDocuments")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEventResponseModel>), 200)]
                public async virtual Task<IActionResult> EventRelatedDocuments(string eventId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEventRelatedDocumentResponseModel> response = await this.EventService.EventRelatedDocuments(eventId, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>f99e36bd277fb86d5151eb0c70049bef</Hash>
</Codenesium>*/