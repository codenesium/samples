using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
        public abstract class AbstractMachineRefTeamController : AbstractApiController
        {
                protected IMachineRefTeamService MachineRefTeamService { get; private set; }

                protected IApiMachineRefTeamModelMapper MachineRefTeamModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractMachineRefTeamController(
                        ApiSettings settings,
                        ILogger<AbstractMachineRefTeamController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMachineRefTeamService machineRefTeamService,
                        IApiMachineRefTeamModelMapper machineRefTeamModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.MachineRefTeamService = machineRefTeamService;
                        this.MachineRefTeamModelMapper = machineRefTeamModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiMachineRefTeamResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiMachineRefTeamResponseModel> response = await this.MachineRefTeamService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiMachineRefTeamResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiMachineRefTeamResponseModel response = await this.MachineRefTeamService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiMachineRefTeamResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiMachineRefTeamRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiMachineRefTeamResponseModel> records = new List<ApiMachineRefTeamResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiMachineRefTeamResponseModel> result = await this.MachineRefTeamService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiMachineRefTeamResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiMachineRefTeamRequestModel model)
                {
                        CreateResponse<ApiMachineRefTeamResponseModel> result = await this.MachineRefTeamService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/MachineRefTeams/{result.Record.Id}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiMachineRefTeamResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiMachineRefTeamRequestModel> patch)
                {
                        ApiMachineRefTeamResponseModel record = await this.MachineRefTeamService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiMachineRefTeamRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiMachineRefTeamResponseModel> result = await this.MachineRefTeamService.Update(id, model);

                                if (result.Success)
                                {
                                        return this.Ok(result);
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
                [ProducesResponseType(typeof(UpdateResponse<ApiMachineRefTeamResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiMachineRefTeamRequestModel model)
                {
                        ApiMachineRefTeamRequestModel request = await this.PatchModel(id, this.MachineRefTeamModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiMachineRefTeamResponseModel> result = await this.MachineRefTeamService.Update(id, request);

                                if (result.Success)
                                {
                                        return this.Ok(result);
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
                public virtual async Task<IActionResult> Delete(int id)
                {
                        ActionResponse result = await this.MachineRefTeamService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private async Task<ApiMachineRefTeamRequestModel> PatchModel(int id, JsonPatchDocument<ApiMachineRefTeamRequestModel> patch)
                {
                        var record = await this.MachineRefTeamService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiMachineRefTeamRequestModel request = this.MachineRefTeamModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>df1e0544cc6649bbfe4669449d08c4c8</Hash>
</Codenesium>*/