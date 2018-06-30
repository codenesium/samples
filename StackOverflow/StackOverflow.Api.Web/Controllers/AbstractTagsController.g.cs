using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
        public abstract class AbstractTagsController : AbstractApiController
        {
                protected ITagsService TagsService { get; private set; }

                protected IApiTagsModelMapper TagsModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTagsController(
                        ApiSettings settings,
                        ILogger<AbstractTagsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITagsService tagsService,
                        IApiTagsModelMapper tagsModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.TagsService = tagsService;
                        this.TagsModelMapper = tagsModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTagsResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTagsResponseModel> response = await this.TagsService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiTagsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiTagsResponseModel response = await this.TagsService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiTagsResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTagsRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiTagsResponseModel> records = new List<ApiTagsResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiTagsResponseModel> result = await this.TagsService.Create(model);

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
                [ProducesResponseType(typeof(ApiTagsResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTagsRequestModel model)
                {
                        CreateResponse<ApiTagsResponseModel> result = await this.TagsService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Tags/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiTagsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTagsRequestModel> patch)
                {
                        ApiTagsResponseModel record = await this.TagsService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiTagsRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.TagsService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiTagsResponseModel response = await this.TagsService.Get(id);

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
                [ProducesResponseType(typeof(ApiTagsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTagsRequestModel model)
                {
                        ApiTagsRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.TagsService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiTagsResponseModel response = await this.TagsService.Get(id);

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
                        ActionResponse result = await this.TagsService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiTagsRequestModel> CreatePatch(ApiTagsRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTagsRequestModel>();
                        patch.Replace(x => x.Count, model.Count);
                        patch.Replace(x => x.ExcerptPostId, model.ExcerptPostId);
                        patch.Replace(x => x.TagName, model.TagName);
                        patch.Replace(x => x.WikiPostId, model.WikiPostId);
                        return patch;
                }

                private async Task<ApiTagsRequestModel> PatchModel(int id, JsonPatchDocument<ApiTagsRequestModel> patch)
                {
                        var record = await this.TagsService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiTagsRequestModel request = this.TagsModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5f8475738ea861599516423d248f284d</Hash>
</Codenesium>*/