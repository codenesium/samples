using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
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
        public abstract class AbstractDeploymentRelatedMachineController : AbstractApiController
        {
                protected IDeploymentRelatedMachineService DeploymentRelatedMachineService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractDeploymentRelatedMachineController(
                        ApiSettings settings,
                        ILogger<AbstractDeploymentRelatedMachineController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentRelatedMachineService deploymentRelatedMachineService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.DeploymentRelatedMachineService = deploymentRelatedMachineService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiDeploymentRelatedMachineResponseModel> response = await this.DeploymentRelatedMachineService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiDeploymentRelatedMachineResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiDeploymentRelatedMachineResponseModel response = await this.DeploymentRelatedMachineService.Get(id);

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
                [ProducesResponseType(typeof(ApiDeploymentRelatedMachineResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiDeploymentRelatedMachineRequestModel model)
                {
                        CreateResponse<ApiDeploymentRelatedMachineResponseModel> result = await this.DeploymentRelatedMachineService.Create(model);

                        if (result.Success)
                        {
                                return this.Created ($"{this.Settings.ExternalBaseUrl}/api/DeploymentRelatedMachines/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPost]
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDeploymentRelatedMachineRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiDeploymentRelatedMachineResponseModel> records = new List<ApiDeploymentRelatedMachineResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiDeploymentRelatedMachineResponseModel> result = await this.DeploymentRelatedMachineService.Create(model);

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
                [ProducesResponseType(typeof(ApiDeploymentRelatedMachineResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiDeploymentRelatedMachineRequestModel model)
                {
                        ActionResponse result = await this.DeploymentRelatedMachineService.Update(id, model);

                        if (result.Success)
                        {
                                ApiDeploymentRelatedMachineResponseModel response = await this.DeploymentRelatedMachineService.Get(id);

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
                        ActionResponse result = await this.DeploymentRelatedMachineService.Delete(id);

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
                [Route("getDeploymentId/{deploymentId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
                public async virtual Task<IActionResult> GetDeploymentId(string deploymentId)
                {
                        List<ApiDeploymentRelatedMachineResponseModel> response = await this.DeploymentRelatedMachineService.GetDeploymentId(deploymentId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getMachineId/{machineId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDeploymentRelatedMachineResponseModel>), 200)]
                public async virtual Task<IActionResult> GetMachineId(string machineId)
                {
                        List<ApiDeploymentRelatedMachineResponseModel> response = await this.DeploymentRelatedMachineService.GetMachineId(machineId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>b4792ad98b9655a08b5ab8f25a199977</Hash>
</Codenesium>*/