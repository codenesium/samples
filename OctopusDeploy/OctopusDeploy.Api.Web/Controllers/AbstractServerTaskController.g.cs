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
        public abstract class AbstractServerTaskController : AbstractApiController
        {
                protected IServerTaskService ServerTaskService { get; private set; }

                protected IApiServerTaskModelMapper ServerTaskModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractServerTaskController(
                        ApiSettings settings,
                        ILogger<AbstractServerTaskController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IServerTaskService serverTaskService,
                        IApiServerTaskModelMapper serverTaskModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ServerTaskService = serverTaskService;
                        this.ServerTaskModelMapper = serverTaskModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiServerTaskResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiServerTaskResponseModel> response = await this.ServerTaskService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiServerTaskResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiServerTaskResponseModel response = await this.ServerTaskService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiServerTaskResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiServerTaskRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiServerTaskResponseModel> records = new List<ApiServerTaskResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiServerTaskResponseModel> result = await this.ServerTaskService.Create(model);

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
                [ProducesResponseType(typeof(ApiServerTaskResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiServerTaskRequestModel model)
                {
                        CreateResponse<ApiServerTaskResponseModel> result = await this.ServerTaskService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ServerTasks/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiServerTaskResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiServerTaskRequestModel> patch)
                {
                        ApiServerTaskResponseModel record = await this.ServerTaskService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiServerTaskRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ServerTaskService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiServerTaskResponseModel response = await this.ServerTaskService.Get(id);

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
                [ProducesResponseType(typeof(ApiServerTaskResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiServerTaskRequestModel model)
                {
                        ApiServerTaskRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ServerTaskService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiServerTaskResponseModel response = await this.ServerTaskService.Get(id);

                                        return this.Ok(response);
                                }
                                else
                                {
                                        return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                                }
                        }
                }

                [HttpDelete]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(void), 204)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.ServerTaskService.Delete(id);

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
                [Route("byDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId/{description}/{queueTime}/{startTime}/{completedTime}/{errorMessage}/{concurrencyTag}/{hasPendingInterruptions}/{hasWarningsOrErrors}/{durationSeconds}/{jSON}/{state}/{name}/{projectId}/{environmentId}/{tenantId}/{serverNodeId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiServerTaskResponseModel>), 200)]
                public async virtual Task<IActionResult> ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId)
                {
                        List<ApiServerTaskResponseModel> response = await this.ServerTaskService.ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(description, queueTime, startTime, completedTime, errorMessage, concurrencyTag, hasPendingInterruptions, hasWarningsOrErrors, durationSeconds, jSON, state, name, projectId, environmentId, tenantId, serverNodeId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byStateConcurrencyTag/{state}/{concurrencyTag}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiServerTaskResponseModel>), 200)]
                public async virtual Task<IActionResult> ByStateConcurrencyTag(string state, string concurrencyTag)
                {
                        List<ApiServerTaskResponseModel> response = await this.ServerTaskService.ByStateConcurrencyTag(state, concurrencyTag);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId/{name}/{description}/{startTime}/{completedTime}/{errorMessage}/{hasWarningsOrErrors}/{projectId}/{environmentId}/{tenantId}/{durationSeconds}/{jSON}/{queueTime}/{state}/{concurrencyTag}/{hasPendingInterruptions}/{serverNodeId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiServerTaskResponseModel>), 200)]
                public async virtual Task<IActionResult> ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId)
                {
                        List<ApiServerTaskResponseModel> response = await this.ServerTaskService.ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(name, description, startTime, completedTime, errorMessage, hasWarningsOrErrors, projectId, environmentId, tenantId, durationSeconds, jSON, queueTime, state, concurrencyTag, hasPendingInterruptions, serverNodeId);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiServerTaskRequestModel> CreatePatch(ApiServerTaskRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiServerTaskRequestModel>();
                        patch.Replace(x => x.CompletedTime, model.CompletedTime);
                        patch.Replace(x => x.ConcurrencyTag, model.ConcurrencyTag);
                        patch.Replace(x => x.Description, model.Description);
                        patch.Replace(x => x.DurationSeconds, model.DurationSeconds);
                        patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
                        patch.Replace(x => x.ErrorMessage, model.ErrorMessage);
                        patch.Replace(x => x.HasPendingInterruptions, model.HasPendingInterruptions);
                        patch.Replace(x => x.HasWarningsOrErrors, model.HasWarningsOrErrors);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.ProjectId, model.ProjectId);
                        patch.Replace(x => x.QueueTime, model.QueueTime);
                        patch.Replace(x => x.ServerNodeId, model.ServerNodeId);
                        patch.Replace(x => x.StartTime, model.StartTime);
                        patch.Replace(x => x.State, model.State);
                        patch.Replace(x => x.TenantId, model.TenantId);
                        return patch;
                }

                private async Task<ApiServerTaskRequestModel> PatchModel(string id, JsonPatchDocument<ApiServerTaskRequestModel> patch)
                {
                        var record = await this.ServerTaskService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiServerTaskRequestModel request = this.ServerTaskModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>55ada6f60b2e9364605cf6000577f650</Hash>
</Codenesium>*/