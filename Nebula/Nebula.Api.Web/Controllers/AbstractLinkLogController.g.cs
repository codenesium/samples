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
        public abstract class AbstractLinkLogController : AbstractApiController
        {
                protected ILinkLogService LinkLogService { get; private set; }

                protected IApiLinkLogModelMapper LinkLogModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractLinkLogController(
                        ApiSettings settings,
                        ILogger<AbstractLinkLogController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILinkLogService linkLogService,
                        IApiLinkLogModelMapper linkLogModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.LinkLogService = linkLogService;
                        this.LinkLogModelMapper = linkLogModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiLinkLogResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLinkLogResponseModel> response = await this.LinkLogService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiLinkLogResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiLinkLogResponseModel response = await this.LinkLogService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiLinkLogResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiLinkLogRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiLinkLogResponseModel> records = new List<ApiLinkLogResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiLinkLogResponseModel> result = await this.LinkLogService.Create(model);

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
                [ProducesResponseType(typeof(ApiLinkLogResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiLinkLogRequestModel model)
                {
                        CreateResponse<ApiLinkLogResponseModel> result = await this.LinkLogService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/LinkLogs/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiLinkLogResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiLinkLogRequestModel> patch)
                {
                        ApiLinkLogResponseModel record = await this.LinkLogService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiLinkLogRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.LinkLogService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiLinkLogResponseModel response = await this.LinkLogService.Get(id);

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
                [ProducesResponseType(typeof(ApiLinkLogResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiLinkLogRequestModel model)
                {
                        ApiLinkLogRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.LinkLogService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiLinkLogResponseModel response = await this.LinkLogService.Get(id);

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
                public virtual async Task<IActionResult> Delete(int id)
                {
                        ActionResponse result = await this.LinkLogService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiLinkLogRequestModel> CreatePatch(ApiLinkLogRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLinkLogRequestModel>();
                        patch.Replace(x => x.DateEntered, model.DateEntered);
                        patch.Replace(x => x.LinkId, model.LinkId);
                        patch.Replace(x => x.Log, model.Log);
                        return patch;
                }

                private async Task<ApiLinkLogRequestModel> PatchModel(int id, JsonPatchDocument<ApiLinkLogRequestModel> patch)
                {
                        var record = await this.LinkLogService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiLinkLogRequestModel request = this.LinkLogModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>dcbff345a47635becefa4506a0098d99</Hash>
</Codenesium>*/