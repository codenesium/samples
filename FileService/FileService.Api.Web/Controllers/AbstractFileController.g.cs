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
        public abstract class AbstractFileController : AbstractApiController
        {
                protected IFileService FileService { get; private set; }

                protected IApiFileModelMapper FileModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractFileController(
                        ApiSettings settings,
                        ILogger<AbstractFileController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IFileService fileService,
                        IApiFileModelMapper fileModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.FileService = fileService;
                        this.FileModelMapper = fileModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiFileResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiFileResponseModel> response = await this.FileService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiFileResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiFileResponseModel response = await this.FileService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiFileResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiFileRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiFileResponseModel> records = new List<ApiFileResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiFileResponseModel> result = await this.FileService.Create(model);

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
                [ProducesResponseType(typeof(ApiFileResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiFileRequestModel model)
                {
                        CreateResponse<ApiFileResponseModel> result = await this.FileService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Files/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiFileResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiFileRequestModel> patch)
                {
                        ApiFileResponseModel record = await this.FileService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiFileRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.FileService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiFileResponseModel response = await this.FileService.Get(id);

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
                [ProducesResponseType(typeof(ApiFileResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiFileRequestModel model)
                {
                        ApiFileRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.FileService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiFileResponseModel response = await this.FileService.Get(id);

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
                        ActionResponse result = await this.FileService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiFileRequestModel> CreatePatch(ApiFileRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiFileRequestModel>();
                        patch.Replace(x => x.BucketId, model.BucketId);
                        patch.Replace(x => x.DateCreated, model.DateCreated);
                        patch.Replace(x => x.Description, model.Description);
                        patch.Replace(x => x.Expiration, model.Expiration);
                        patch.Replace(x => x.Extension, model.Extension);
                        patch.Replace(x => x.ExternalId, model.ExternalId);
                        patch.Replace(x => x.FileSizeInBytes, model.FileSizeInBytes);
                        patch.Replace(x => x.FileTypeId, model.FileTypeId);
                        patch.Replace(x => x.Location, model.Location);
                        patch.Replace(x => x.PrivateKey, model.PrivateKey);
                        patch.Replace(x => x.PublicKey, model.PublicKey);
                        return patch;
                }

                private async Task<ApiFileRequestModel> PatchModel(int id, JsonPatchDocument<ApiFileRequestModel> patch)
                {
                        var record = await this.FileService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiFileRequestModel request = this.FileModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>803a33998e789efee6fec7997552d6be</Hash>
</Codenesium>*/