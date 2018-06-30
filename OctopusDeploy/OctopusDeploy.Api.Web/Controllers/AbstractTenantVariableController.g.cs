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
        public abstract class AbstractTenantVariableController : AbstractApiController
        {
                protected ITenantVariableService TenantVariableService { get; private set; }

                protected IApiTenantVariableModelMapper TenantVariableModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTenantVariableController(
                        ApiSettings settings,
                        ILogger<AbstractTenantVariableController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITenantVariableService tenantVariableService,
                        IApiTenantVariableModelMapper tenantVariableModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.TenantVariableService = tenantVariableService;
                        this.TenantVariableModelMapper = tenantVariableModelMapper;
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

                [HttpPost]
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiTenantVariableResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTenantVariableRequestModel model)
                {
                        CreateResponse<ApiTenantVariableResponseModel> result = await this.TenantVariableService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/TenantVariables/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiTenantVariableResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiTenantVariableRequestModel> patch)
                {
                        ApiTenantVariableResponseModel record = await this.TenantVariableService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiTenantVariableRequestModel model = await this.PatchModel(id, patch);

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
                }

                [HttpPut]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiTenantVariableResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiTenantVariableRequestModel model)
                {
                        ApiTenantVariableRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.TenantVariableService.Update(id, request);

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
                [Route("byTenantIdOwnerIdEnvironmentIdVariableTemplateId/{tenantId}/{ownerId}/{environmentId}/{variableTemplateId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiTenantVariableResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId)
                {
                        ApiTenantVariableResponseModel response = await this.TenantVariableService.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(tenantId, ownerId, environmentId, variableTemplateId);

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
                [Route("byTenantId/{tenantId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTenantVariableResponseModel>), 200)]
                public async virtual Task<IActionResult> ByTenantId(string tenantId)
                {
                        List<ApiTenantVariableResponseModel> response = await this.TenantVariableService.ByTenantId(tenantId);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiTenantVariableRequestModel> CreatePatch(ApiTenantVariableRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTenantVariableRequestModel>();
                        patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.OwnerId, model.OwnerId);
                        patch.Replace(x => x.RelatedDocumentId, model.RelatedDocumentId);
                        patch.Replace(x => x.TenantId, model.TenantId);
                        patch.Replace(x => x.VariableTemplateId, model.VariableTemplateId);
                        return patch;
                }

                private async Task<ApiTenantVariableRequestModel> PatchModel(string id, JsonPatchDocument<ApiTenantVariableRequestModel> patch)
                {
                        var record = await this.TenantVariableService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiTenantVariableRequestModel request = this.TenantVariableModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>1b4c5b0133dc7d62958b9c0a35209992</Hash>
</Codenesium>*/