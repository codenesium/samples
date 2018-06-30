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
        public abstract class AbstractPostsController : AbstractApiController
        {
                protected IPostsService PostsService { get; private set; }

                protected IApiPostsModelMapper PostsModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPostsController(
                        ApiSettings settings,
                        ILogger<AbstractPostsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPostsService postsService,
                        IApiPostsModelMapper postsModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PostsService = postsService;
                        this.PostsModelMapper = postsModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPostsResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPostsResponseModel> response = await this.PostsService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPostsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPostsResponseModel response = await this.PostsService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiPostsResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPostsRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPostsResponseModel> records = new List<ApiPostsResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPostsResponseModel> result = await this.PostsService.Create(model);

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
                [ProducesResponseType(typeof(ApiPostsResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPostsRequestModel model)
                {
                        CreateResponse<ApiPostsResponseModel> result = await this.PostsService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Posts/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiPostsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPostsRequestModel> patch)
                {
                        ApiPostsResponseModel record = await this.PostsService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiPostsRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.PostsService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiPostsResponseModel response = await this.PostsService.Get(id);

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
                [ProducesResponseType(typeof(ApiPostsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPostsRequestModel model)
                {
                        ApiPostsRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.PostsService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiPostsResponseModel response = await this.PostsService.Get(id);

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
                        ActionResponse result = await this.PostsService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiPostsRequestModel> CreatePatch(ApiPostsRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPostsRequestModel>();
                        patch.Replace(x => x.AcceptedAnswerId, model.AcceptedAnswerId);
                        patch.Replace(x => x.AnswerCount, model.AnswerCount);
                        patch.Replace(x => x.Body, model.Body);
                        patch.Replace(x => x.ClosedDate, model.ClosedDate);
                        patch.Replace(x => x.CommentCount, model.CommentCount);
                        patch.Replace(x => x.CommunityOwnedDate, model.CommunityOwnedDate);
                        patch.Replace(x => x.CreationDate, model.CreationDate);
                        patch.Replace(x => x.FavoriteCount, model.FavoriteCount);
                        patch.Replace(x => x.LastActivityDate, model.LastActivityDate);
                        patch.Replace(x => x.LastEditDate, model.LastEditDate);
                        patch.Replace(x => x.LastEditorDisplayName, model.LastEditorDisplayName);
                        patch.Replace(x => x.LastEditorUserId, model.LastEditorUserId);
                        patch.Replace(x => x.OwnerUserId, model.OwnerUserId);
                        patch.Replace(x => x.ParentId, model.ParentId);
                        patch.Replace(x => x.PostTypeId, model.PostTypeId);
                        patch.Replace(x => x.Score, model.Score);
                        patch.Replace(x => x.Tags, model.Tags);
                        patch.Replace(x => x.Title, model.Title);
                        patch.Replace(x => x.ViewCount, model.ViewCount);
                        return patch;
                }

                private async Task<ApiPostsRequestModel> PatchModel(int id, JsonPatchDocument<ApiPostsRequestModel> patch)
                {
                        var record = await this.PostsService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiPostsRequestModel request = this.PostsModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>30e216183f4f43d8829fc5c13343e045</Hash>
</Codenesium>*/