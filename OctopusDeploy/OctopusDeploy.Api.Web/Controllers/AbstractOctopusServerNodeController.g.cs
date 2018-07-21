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
        public abstract class AbstractOctopusServerNodeController : AbstractApiController
        {
                protected IOctopusServerNodeService OctopusServerNodeService { get; private set; }

                protected IApiOctopusServerNodeModelMapper OctopusServerNodeModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractOctopusServerNodeController(
                        ApiSettings settings,
                        ILogger<AbstractOctopusServerNodeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IOctopusServerNodeService octopusServerNodeService,
                        IApiOctopusServerNodeModelMapper octopusServerNodeModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.OctopusServerNodeService = octopusServerNodeService;
                        this.OctopusServerNodeModelMapper = octopusServerNodeModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiOctopusServerNodeResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiOctopusServerNodeResponseModel> response = await this.OctopusServerNodeService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiOctopusServerNodeResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiOctopusServerNodeResponseModel response = await this.OctopusServerNodeService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiOctopusServerNodeResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiOctopusServerNodeRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiOctopusServerNodeResponseModel> records = new List<ApiOctopusServerNodeResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiOctopusServerNodeResponseModel> result = await this.OctopusServerNodeService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiOctopusServerNodeResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiOctopusServerNodeRequestModel model)
                {
                        CreateResponse<ApiOctopusServerNodeResponseModel> result = await this.OctopusServerNodeService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/OctopusServerNodes/{result.Record.Id}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiOctopusServerNodeResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiOctopusServerNodeRequestModel> patch)
                {
                        ApiOctopusServerNodeResponseModel record = await this.OctopusServerNodeService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiOctopusServerNodeRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiOctopusServerNodeResponseModel> result = await this.OctopusServerNodeService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiOctopusServerNodeResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiOctopusServerNodeRequestModel model)
                {
                        ApiOctopusServerNodeRequestModel request = await this.PatchModel(id, this.OctopusServerNodeModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiOctopusServerNodeResponseModel> result = await this.OctopusServerNodeService.Update(id, request);

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
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.OctopusServerNodeService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private async Task<ApiOctopusServerNodeRequestModel> PatchModel(string id, JsonPatchDocument<ApiOctopusServerNodeRequestModel> patch)
                {
                        var record = await this.OctopusServerNodeService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiOctopusServerNodeRequestModel request = this.OctopusServerNodeModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>22cb45247ace2862d8d12dac718fce00</Hash>
</Codenesium>*/