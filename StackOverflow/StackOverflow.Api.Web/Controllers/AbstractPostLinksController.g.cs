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
	public abstract class AbstractPostLinksController : AbstractApiController
	{
		protected IPostLinksService PostLinksService { get; private set; }

		protected IApiPostLinksServerModelMapper PostLinksModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPostLinksController(
			ApiSettings settings,
			ILogger<AbstractPostLinksController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostLinksService postLinksService,
			IApiPostLinksServerModelMapper postLinksModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PostLinksService = postLinksService;
			this.PostLinksModelMapper = postLinksModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinksServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiPostLinksServerResponseModel> response = await this.PostLinksService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPostLinksServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPostLinksServerResponseModel response = await this.PostLinksService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPostLinksServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPostLinksServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPostLinksServerResponseModel> records = new List<ApiPostLinksServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPostLinksServerResponseModel> result = await this.PostLinksService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPostLinksServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPostLinksServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPostLinksServerRequestModel model)
		{
			CreateResponse<ApiPostLinksServerResponseModel> result = await this.PostLinksService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPostLinksServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPostLinksServerRequestModel> patch)
		{
			ApiPostLinksServerResponseModel record = await this.PostLinksService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPostLinksServerRequestModel model = await this.PatchModel(id, patch) as ApiPostLinksServerRequestModel;

				UpdateResponse<ApiPostLinksServerResponseModel> result = await this.PostLinksService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPostLinksServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPostLinksServerRequestModel model)
		{
			ApiPostLinksServerRequestModel request = await this.PatchModel(id, this.PostLinksModelMapper.CreatePatch(model)) as ApiPostLinksServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPostLinksServerResponseModel> result = await this.PostLinksService.Update(id, request);

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
			ActionResponse result = await this.PostLinksService.Delete(id);

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
		[ProducesResponseType(typeof(List<ApiPostLinksServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLinkTypeId(int linkTypeId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinksServerResponseModel> response = await this.PostLinksService.ByLinkTypeId(linkTypeId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byPostId/{postId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinksServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByPostId(int postId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinksServerResponseModel> response = await this.PostLinksService.ByPostId(postId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byRelatedPostId/{relatedPostId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPostLinksServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByRelatedPostId(int relatedPostId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPostLinksServerResponseModel> response = await this.PostLinksService.ByRelatedPostId(relatedPostId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPostLinksServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPostLinksServerRequestModel> patch)
		{
			var record = await this.PostLinksService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPostLinksServerRequestModel request = this.PostLinksModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>635677a002ec03755d4d507c2e981cab</Hash>
</Codenesium>*/