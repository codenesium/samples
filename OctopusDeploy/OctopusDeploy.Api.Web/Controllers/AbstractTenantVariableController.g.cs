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
        public abstract class AbstractTenantVariableController: AbstractApiController
        {
                protected ITenantVariableService TenantVariableService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTenantVariableController(
                        ApiSettings settings,
                        ILogger<AbstractTenantVariableController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITenantVariableService tenantVariableService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.TenantVariableService = tenantVariableService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTenantVariableResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTenantVariableResponseModel> response = await this.TenantVariableService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiTenantVariableResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiTenantVariableResponseModel response = await this.TenantVariableService.Get(id);

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
                [ProducesResponseType(typeof(ApiTenantVariableResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTenantVariableRequestModel model)
                {
                        CreateResponse<ApiTenantVariableResponseModel> result = await this.TenantVariableService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/TenantVariables/{result.Record.Id.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiTenantVariableResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTenantVariableRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiTenantVariableResponseModel> records = new List<ApiTenantVariableResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiTenantVariableResponseModel> result = await this.TenantVariableService.Create(model);

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
                [ProducesResponseType(typeof(ApiTenantVariableResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiTenantVariableRequestModel model)
                {
                        ActionResponse result = await this.TenantVariableService.Update(id, model);

                        if (result.Success)
                        {
                                ApiTenantVariableResponseModel response = await this.TenantVariableService.Get(id);

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
                        ActionResponse result = await this.TenantVariableService.Delete(id);

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
                [Route("getTenantIdOwnerIdEnvironmentIdVariableTemplateId/{tenantId}/{ownerId}/{environmentId}/{variableTemplateId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiTenantVariableResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId)
                {
                        ApiTenantVariableResponseModel response = await this.TenantVariableService.GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(tenantId, ownerId, environmentId, variableTemplateId);

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
                [Route("getTenantId/{tenantId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTenantVariableResponseModel>), 200)]
                public async virtual Task<IActionResult> GetTenantId(string tenantId)
                {
                        List<ApiTenantVariableResponseModel> response = await this.TenantVariableService.GetTenantId(tenantId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>bcf1e78371387abb979d865b33718c0b</Hash>
</Codenesium>*/