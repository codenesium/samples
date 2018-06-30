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
        public abstract class AbstractMachineController : AbstractApiController
        {
                protected IMachineService MachineService { get; private set; }

                protected IApiMachineModelMapper MachineModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractMachineController(
                        ApiSettings settings,
                        ILogger<AbstractMachineController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMachineService machineService,
                        IApiMachineModelMapper machineModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.MachineService = machineService;
                        this.MachineModelMapper = machineModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiMachineResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiMachineResponseModel> response = await this.MachineService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiMachineResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiMachineResponseModel response = await this.MachineService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiMachineResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiMachineRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiMachineResponseModel> records = new List<ApiMachineResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiMachineResponseModel> result = await this.MachineService.Create(model);

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
                [ProducesResponseType(typeof(ApiMachineResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiMachineRequestModel model)
                {
                        CreateResponse<ApiMachineResponseModel> result = await this.MachineService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Machines/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiMachineResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiMachineRequestModel> patch)
                {
                        ApiMachineResponseModel record = await this.MachineService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiMachineRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.MachineService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiMachineResponseModel response = await this.MachineService.Get(id);

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
                [ProducesResponseType(typeof(ApiMachineResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiMachineRequestModel model)
                {
                        ApiMachineRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.MachineService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiMachineResponseModel response = await this.MachineService.Get(id);

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
                        ActionResponse result = await this.MachineService.Delete(id);

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
                [Route("byName/{name}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiMachineResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByName(string name)
                {
                        ApiMachineResponseModel response = await this.MachineService.ByName(name);

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
                [Route("byMachinePolicyId/{machinePolicyId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiMachineResponseModel>), 200)]
                public async virtual Task<IActionResult> ByMachinePolicyId(string machinePolicyId)
                {
                        List<ApiMachineResponseModel> response = await this.MachineService.ByMachinePolicyId(machinePolicyId);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiMachineRequestModel> CreatePatch(ApiMachineRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiMachineRequestModel>();
                        patch.Replace(x => x.CommunicationStyle, model.CommunicationStyle);
                        patch.Replace(x => x.EnvironmentIds, model.EnvironmentIds);
                        patch.Replace(x => x.Fingerprint, model.Fingerprint);
                        patch.Replace(x => x.IsDisabled, model.IsDisabled);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.MachinePolicyId, model.MachinePolicyId);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
                        patch.Replace(x => x.Roles, model.Roles);
                        patch.Replace(x => x.TenantIds, model.TenantIds);
                        patch.Replace(x => x.TenantTags, model.TenantTags);
                        patch.Replace(x => x.Thumbprint, model.Thumbprint);
                        return patch;
                }

                private async Task<ApiMachineRequestModel> PatchModel(string id, JsonPatchDocument<ApiMachineRequestModel> patch)
                {
                        var record = await this.MachineService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiMachineRequestModel request = this.MachineModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>ee9d3185c20c72b3bfbb20d7661e4a21</Hash>
</Codenesium>*/