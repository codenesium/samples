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
        public abstract class AbstractReleaseController: AbstractApiController
        {
                protected IReleaseService ReleaseService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractReleaseController(
                        ServiceSettings settings,
                        ILogger<AbstractReleaseController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IReleaseService releaseService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ReleaseService = releaseService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiReleaseResponseModel> response = await this.ReleaseService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiReleaseResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiReleaseResponseModel response = await this.ReleaseService.Get(id);

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
                [ProducesResponseType(typeof(ApiReleaseResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiReleaseRequestModel model)
                {
                        CreateResponse<ApiReleaseResponseModel> result = await this.ReleaseService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Releases/{result.Record.Id.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiReleaseRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiReleaseResponseModel> records = new List<ApiReleaseResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiReleaseResponseModel> result = await this.ReleaseService.Create(model);

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
                [ProducesResponseType(typeof(ApiReleaseResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiReleaseRequestModel model)
                {
                        ActionResponse result = await this.ReleaseService.Update(id, model);

                        if (result.Success)
                        {
                                ApiReleaseResponseModel response = await this.ReleaseService.Get(id);

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
                        ActionResponse result = await this.ReleaseService.Delete(id);

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
                [Route("getVersionProjectId/{version}/{projectId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiReleaseResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetVersionProjectId(string version, string projectId)
                {
                        ApiReleaseResponseModel response = await this.ReleaseService.GetVersionProjectId(version, projectId);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                [HttpGet]
                [Route("getIdAssembled/{id}/{assembled}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
                public async virtual Task<IActionResult> GetIdAssembled(string id, DateTimeOffset assembled)
                {
                        List<ApiReleaseResponseModel> response = await this.ReleaseService.GetIdAssembled(id, assembled);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getProjectDeploymentProcessSnapshotId/{projectDeploymentProcessSnapshotId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
                public async virtual Task<IActionResult> GetProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId)
                {
                        List<ApiReleaseResponseModel> response = await this.ReleaseService.GetProjectDeploymentProcessSnapshotId(projectDeploymentProcessSnapshotId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled/{id}/{version}/{projectVariableSetSnapshotId}/{projectDeploymentProcessSnapshotId}/{jSON}/{projectId}/{channelId}/{assembled}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
                public async virtual Task<IActionResult> GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled)
                {
                        List<ApiReleaseResponseModel> response = await this.ReleaseService.GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(id, version, projectVariableSetSnapshotId, projectDeploymentProcessSnapshotId, jSON, projectId, channelId, assembled);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled/{id}/{channelId}/{projectVariableSetSnapshotId}/{projectDeploymentProcessSnapshotId}/{jSON}/{projectId}/{version}/{assembled}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiReleaseResponseModel>), 200)]
                public async virtual Task<IActionResult> GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled)
                {
                        List<ApiReleaseResponseModel> response = await this.ReleaseService.GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(id, channelId, projectVariableSetSnapshotId, projectDeploymentProcessSnapshotId, jSON, projectId, version, assembled);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>f969ff5cba5c53527f683ffc7fd8a1b9</Hash>
</Codenesium>*/