using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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

		protected IApiPostsServerModelMapper PostsModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPostsController(
			ApiSettings settings,
			ILogger<AbstractPostsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostsService postsService,
			IApiPostsServerModelMapper postsModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PostsService = postsService;
			this.PostsModelMapper = postsModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostsServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiPostsServerResponseModel> response = await this.PostsService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPostsServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPostsServerResponseModel response = await this.PostsService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPostsServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPostsServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPostsServerResponseModel> records = new List<ApiPostsServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPostsServerResponseModel> result = await this.PostsService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPostsServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPostsServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPostsServerRequestModel model)
		{
			CreateResponse<ApiPostsServerResponseModel> result = await this.PostsService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Posts/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPostsServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPostsServerRequestModel> patch)
		{
			ApiPostsServerResponseModel record = await this.PostsService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPostsServerRequestModel model = await this.PatchModel(id, patch) as ApiPostsServerRequestModel;

				UpdateResponse<ApiPostsServerResponseModel> result = await this.PostsService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPostsServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPostsServerRequestModel model)
		{
			ApiPostsServerRequestModel request = await this.PatchModel(id, this.PostsModelMapper.CreatePatch(model)) as ApiPostsServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPostsServerResponseModel> result = await this.PostsService.Update(id, request);

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
		[ProducesResponseType(typeof(ActionResponse), 200)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.PostsService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("byOwnerUserId/{ownerUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostsServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByOwnerUserId(int? ownerUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostsServerResponseModel> response = await this.PostsService.ByOwnerUserId(ownerUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byLastEditorUserId/{lastEditorUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostsServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLastEditorUserId(int? lastEditorUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostsServerResponseModel> response = await this.PostsService.ByLastEditorUserId(lastEditorUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byPostTypeId/{postTypeId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostsServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByPostTypeId(int postTypeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostsServerResponseModel> response = await this.PostsService.ByPostTypeId(postTypeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byParentId/{parentId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostsServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByParentId(int? parentId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostsServerResponseModel> response = await this.PostsService.ByParentId(parentId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{postId}/Comments")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCommentsServerResponseModel>), 200)]
		public async virtual Task<IActionResult> CommentsByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCommentsServerResponseModel> response = await this.PostsService.CommentsByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{parentId}/Posts")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostsServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostsByParentId(int parentId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostsServerResponseModel> response = await this.PostsService.PostsByParentId(parentId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{excerptPostId}/Tags")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTagsServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TagsByExcerptPostId(int excerptPostId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTagsServerResponseModel> response = await this.PostsService.TagsByExcerptPostId(excerptPostId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{wikiPostId}/TagsByWikiPostId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTagsServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TagsByWikiPostId(int wikiPostId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTagsServerResponseModel> response = await this.PostsService.TagsByWikiPostId(wikiPostId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{postId}/Votes")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVotesServerResponseModel>), 200)]
		public async virtual Task<IActionResult> VotesByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVotesServerResponseModel> response = await this.PostsService.VotesByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{postId}/PostHistory")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostHistoryServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostHistoryByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostHistoryServerResponseModel> response = await this.PostsService.PostHistoryByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{postId}/PostLinks")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinksServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostLinksByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinksServerResponseModel> response = await this.PostsService.PostLinksByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{relatedPostId}/PostLinksByRelatedPostId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinksServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostLinksByRelatedPostId(int relatedPostId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinksServerResponseModel> response = await this.PostsService.PostLinksByRelatedPostId(relatedPostId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPostsServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPostsServerRequestModel> patch)
		{
			var record = await this.PostsService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPostsServerRequestModel request = this.PostsModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3767af66d63701103cc3ff8103f5a3fd</Hash>
</Codenesium>*/