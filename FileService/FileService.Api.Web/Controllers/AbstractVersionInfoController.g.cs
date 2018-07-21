using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Web
{
        public abstract class AbstractVersionInfoController : AbstractApiController
        {
                protected IVersionInfoService VersionInfoService { get; private set; }

                protected IApiVersionInfoModelMapper VersionInfoModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractVersionInfoController(
                        ApiSettings settings,
                        ILogger<AbstractVersionInfoController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVersionInfoService versionInfoService,
                        IApiVersionInfoModelMapper versionInfoModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.VersionInfoService = versionInfoService;
                        this.VersionInfoModelMapper = versionInfoModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiVersionInfoResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiVersionInfoResponseModel> response = await this.VersionInfoService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiVersionInfoResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(long id)
                {
                        ApiVersionInfoResponseModel response = await this.VersionInfoService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiVersionInfoResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVersionInfoRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiVersionInfoResponseModel> records = new List<ApiVersionInfoResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiVersionInfoResponseModel> result = await this.VersionInfoService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiVersionInfoResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiVersionInfoRequestModel model)
                {
                        CreateResponse<ApiVersionInfoResponseModel> result = await this.VersionInfoService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/VersionInfoes/{result.Record.Version}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiVersionInfoResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(long id, [FromBody] JsonPatchDocument<ApiVersionInfoRequestModel> patch)
                {
                        ApiVersionInfoResponseModel record = await this.VersionInfoService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiVersionInfoRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiVersionInfoResponseModel> result = await this.VersionInfoService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiVersionInfoResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(long id, [FromBody] ApiVersionInfoRequestModel model)
                {
                        ApiVersionInfoRequestModel request = await this.PatchModel(id, this.VersionInfoModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiVersionInfoResponseModel> result = await this.VersionInfoService.Update(id, request);

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
                public virtual async Task<IActionResult> Delete(long id)
                {
                        ActionResponse result = await this.VersionInfoService.Delete(id);

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
                [Route("byVersion/{version}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiVersionInfoResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByVersion(long version)
                {
                        ApiVersionInfoResponseModel response = await this.VersionInfoService.ByVersion(version);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                private async Task<ApiVersionInfoRequestModel> PatchModel(long id, JsonPatchDocument<ApiVersionInfoRequestModel> patch)
                {
                        var record = await this.VersionInfoService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiVersionInfoRequestModel request = this.VersionInfoModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a67d2b8a8d2654ba8f96016ed8e39d01</Hash>
</Codenesium>*/