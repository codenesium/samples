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
        public abstract class AbstractDeploymentController: AbstractApiController
        {
                protected IDeploymentService DeploymentService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractDeploymentController(
                        ServiceSettings settings,
                        ILogger<AbstractDeploymentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentService deploymentService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.DeploymentService = deploymentService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiDeploymentResponseModel> response = await this.DeploymentService.All(query.Offset, query.Limit);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiDeploymentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiDeploymentResponseModel response = await this.DeploymentService.Get(id);

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
                [ProducesResponseType(typeof(ApiDeploymentResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiDeploymentRequestModel model)
                {
                        CreateResponse<ApiDeploymentResponseModel> result = await this.DeploymentService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Deployments/{result.Record.Id.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDeploymentRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiDeploymentResponseModel> records = new List<ApiDeploymentResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiDeploymentResponseModel> result = await this.DeploymentService.Create(model);

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
                [ProducesResponseType(typeof(ApiDeploymentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiDeploymentRequestModel model)
                {
                        ActionResponse result = await this.DeploymentService.Update(id, model);

                        if (result.Success)
                        {
                                ApiDeploymentResponseModel response = await this.DeploymentService.Get(id);

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
                        ActionResponse result = await this.DeploymentService.Delete(id);

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
                [Route("getChannelId/{channelId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
                public async virtual Task<IActionResult> GetChannelId(string channelId)
                {
                        List<ApiDeploymentResponseModel> response = await this.DeploymentService.GetChannelId(channelId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId/{id}/{projectId}/{projectGroupId}/{name}/{created}/{releaseId}/{taskId}/{environmentId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
                public async virtual Task<IActionResult> GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTime created, string releaseId, string taskId, string environmentId)
                {
                        List<ApiDeploymentResponseModel> response = await this.DeploymentService.GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(id, projectId, projectGroupId, name, created, releaseId, taskId, environmentId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getTenantId/{tenantId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentResponseModel>), 200)]
                public async virtual Task<IActionResult> GetTenantId(string tenantId)
                {
                        List<ApiDeploymentResponseModel> response = await this.DeploymentService.GetTenantId(tenantId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>e030223f06968300aea981c4e1fd8973</Hash>
</Codenesium>*/