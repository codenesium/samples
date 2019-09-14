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
	[Route("api/postLinks")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PostLinkController : AbstractApiController
	{
		protected IPostLinkService PostLinkService { get; private set; }

		protected IApiPostLinkServerModelMapper PostLinkModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public PostLinkController(
			ApiSettings settings,
			ILogger<PostLinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostLinkService postLinkService,
			IApiPostLinkServerModelMapper postLinkModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PostLinkService = postLinkService;
			this.PostLinkModelMapper = postLinkModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinkServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiPostLinkServerResponseModel> response = await this.PostLinkService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPostLinkServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPostLinkServerResponseModel response = await this.PostLinkService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPostLinkServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPostLinkServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPostLinkServerResponseModel> records = new List<ApiPostLinkServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPostLinkServerResponseModel> result = await this.PostLinkService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPostLinkServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPostLinkServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPostLinkServerRequestModel model)
		{
			CreateResponse<ApiPostLinkServerResponseModel> result = await this.PostLinkService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PostLinks/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPostLinkServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPostLinkServerRequestModel> patch)
		{
			ApiPostLinkServerResponseModel record = await this.PostLinkService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPostLinkServerRequestModel model = await this.PatchModel(id, patch) as ApiPostLinkServerRequestModel;

				UpdateResponse<ApiPostLinkServerResponseModel> result = await this.PostLinkService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPostLinkServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPostLinkServerRequestModel model)
		{
			ApiPostLinkServerRequestModel request = await this.PatchModel(id, this.PostLinkModelMapper.CreatePatch(model)) as ApiPostLinkServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPostLinkServerResponseModel> result = await this.PostLinkService.Update(id, request);

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
			ActionResponse result = await this.PostLinkService.Delete(id);

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
		[Route("byLinkTypeId/{linkTypeId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinkServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLinkTypeId(int linkTypeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinkServerResponseModel> response = await this.PostLinkService.ByLinkTypeId(linkTypeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byPostId/{postId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinkServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinkServerResponseModel> response = await this.PostLinkService.ByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byRelatedPostId/{relatedPostId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinkServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByRelatedPostId(int relatedPostId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinkServerResponseModel> response = await this.PostLinkService.ByRelatedPostId(relatedPostId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPostLinkServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPostLinkServerRequestModel> patch)
		{
			var record = await this.PostLinkService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPostLinkServerRequestModel request = this.PostLinkModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6c2d0511ca821d9dc2e97cc001182e89</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/