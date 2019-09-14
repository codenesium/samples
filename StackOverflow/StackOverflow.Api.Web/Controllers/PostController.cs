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
	[Route("api/posts")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PostController : AbstractApiController
	{
		protected IPostService PostService { get; private set; }

		protected IApiPostServerModelMapper PostModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public PostController(
			ApiSettings settings,
			ILogger<PostController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostService postService,
			IApiPostServerModelMapper postModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PostService = postService;
			this.PostModelMapper = postModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiPostServerResponseModel> response = await this.PostService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPostServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPostServerResponseModel response = await this.PostService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPostServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPostServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPostServerResponseModel> records = new List<ApiPostServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPostServerResponseModel> result = await this.PostService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPostServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPostServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPostServerRequestModel model)
		{
			CreateResponse<ApiPostServerResponseModel> result = await this.PostService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPostServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPostServerRequestModel> patch)
		{
			ApiPostServerResponseModel record = await this.PostService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPostServerRequestModel model = await this.PatchModel(id, patch) as ApiPostServerRequestModel;

				UpdateResponse<ApiPostServerResponseModel> result = await this.PostService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPostServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPostServerRequestModel model)
		{
			ApiPostServerRequestModel request = await this.PatchModel(id, this.PostModelMapper.CreatePatch(model)) as ApiPostServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPostServerResponseModel> result = await this.PostService.Update(id, request);

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
			ActionResponse result = await this.PostService.Delete(id);

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
		[ProducesResponseType(typeof(List<ApiPostServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByOwnerUserId(int? ownerUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostServerResponseModel> response = await this.PostService.ByOwnerUserId(ownerUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byLastEditorUserId/{lastEditorUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLastEditorUserId(int? lastEditorUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostServerResponseModel> response = await this.PostService.ByLastEditorUserId(lastEditorUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byPostTypeId/{postTypeId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByPostTypeId(int postTypeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostServerResponseModel> response = await this.PostService.ByPostTypeId(postTypeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byParentId/{parentId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByParentId(int? parentId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostServerResponseModel> response = await this.PostService.ByParentId(parentId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{postId}/Comments")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiCommentServerResponseModel>), 200)]
		public async virtual Task<IActionResult> CommentsByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiCommentServerResponseModel> response = await this.PostService.CommentsByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{parentId}/Posts")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostsByParentId(int parentId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostServerResponseModel> response = await this.PostService.PostsByParentId(parentId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{excerptPostId}/Tags")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTagServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TagsByExcerptPostId(int excerptPostId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTagServerResponseModel> response = await this.PostService.TagsByExcerptPostId(excerptPostId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{wikiPostId}/TagsByWikiPostId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTagServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TagsByWikiPostId(int wikiPostId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTagServerResponseModel> response = await this.PostService.TagsByWikiPostId(wikiPostId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{postId}/Votes")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVoteServerResponseModel>), 200)]
		public async virtual Task<IActionResult> VotesByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVoteServerResponseModel> response = await this.PostService.VotesByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{postId}/PostHistories")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostHistoryServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostHistoriesByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostHistoryServerResponseModel> response = await this.PostService.PostHistoriesByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{postId}/PostLinks")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinkServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostLinksByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinkServerResponseModel> response = await this.PostService.PostLinksByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{relatedPostId}/PostLinksByRelatedPostId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinkServerResponseModel>), 200)]
		public async virtual Task<IActionResult> PostLinksByRelatedPostId(int relatedPostId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinkServerResponseModel> response = await this.PostService.PostLinksByRelatedPostId(relatedPostId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPostServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPostServerRequestModel> patch)
		{
			var record = await this.PostService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPostServerRequestModel request = this.PostModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b4d79c53614b0ef56de360f36c618c28</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/