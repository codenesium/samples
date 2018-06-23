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
        public abstract class AbstractDeploymentEnvironmentController : AbstractApiController
        {
                protected IDeploymentEnvironmentService DeploymentEnvironmentService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractDeploymentEnvironmentController(
                        ApiSettings settings,
                        ILogger<AbstractDeploymentEnvironmentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentEnvironmentService deploymentEnvironmentService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.DeploymentEnvironmentService = deploymentEnvironmentService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentEnvironmentResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiDeploymentEnvironmentResponseModel> response = await this.DeploymentEnvironmentService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiDeploymentEnvironmentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiDeploymentEnvironmentResponseModel response = await this.DeploymentEnvironmentService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiDeploymentEnvironmentResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDeploymentEnvironmentRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiDeploymentEnvironmentResponseModel> records = new List<ApiDeploymentEnvironmentResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiDeploymentEnvironmentResponseModel> result = await this.DeploymentEnvironmentService.Create(model);

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
                [ProducesResponseType(typeof(ApiDeploymentEnvironmentResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiDeploymentEnvironmentRequestModel model)
                {
                        CreateResponse<ApiDeploymentEnvironmentResponseModel> result = await this.DeploymentEnvironmentService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/DeploymentEnvironments/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiDeploymentEnvironmentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiDeploymentEnvironmentRequestModel> patch)
                {
                        ApiDeploymentEnvironmentResponseModel record = await this.DeploymentEnvironmentService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiDeploymentEnvironmentRequestModel model = new ApiDeploymentEnvironmentRequestModel();
                                model.SetProperties(model.DataVersion,
                                                    model.JSON,
                                                    model.Name,
                                                    model.SortOrder);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.DeploymentEnvironmentService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiDeploymentEnvironmentResponseModel response = await this.DeploymentEnvironmentService.Get(id);

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
                [ProducesResponseType(typeof(ApiDeploymentEnvironmentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiDeploymentEnvironmentRequestModel model)
                {
                        ActionResponse result = await this.DeploymentEnvironmentService.Update(id, model);

                        if (result.Success)
                        {
                                ApiDeploymentEnvironmentResponseModel response = await this.DeploymentEnvironmentService.Get(id);

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
                        ActionResponse result = await this.DeploymentEnvironmentService.Delete(id);

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
                [Route("getName/{name}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiDeploymentEnvironmentResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetName(string name)
                {
                        ApiDeploymentEnvironmentResponseModel response = await this.DeploymentEnvironmentService.GetName(name);

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
                [Route("getDataVersion/{dataVersion}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentEnvironmentResponseModel>), 200)]
                public async virtual Task<IActionResult> GetDataVersion(byte[] dataVersion)
                {
                        List<ApiDeploymentEnvironmentResponseModel> response = await this.DeploymentEnvironmentService.GetDataVersion(dataVersion);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>acd60b61d702ca0011f06057f0b55799</Hash>
</Codenesium>*/