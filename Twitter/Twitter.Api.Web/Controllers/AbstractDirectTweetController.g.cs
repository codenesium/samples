using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;

namespace TwitterNS.Api.Web
{
	public abstract class AbstractDirectTweetController : AbstractApiController
	{
		protected IDirectTweetService DirectTweetService { get; private set; }

		protected IApiDirectTweetServerModelMapper DirectTweetModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractDirectTweetController(
			ApiSettings settings,
			ILogger<AbstractDirectTweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDirectTweetService directTweetService,
			IApiDirectTweetServerModelMapper directTweetModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.DirectTweetService = directTweetService;
			this.DirectTweetModelMapper = directTweetModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDirectTweetServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDirectTweetServerResponseModel> response = await this.DirectTweetService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDirectTweetServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiDirectTweetServerResponseModel response = await this.DirectTweetService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiDirectTweetServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDirectTweetServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiDirectTweetServerResponseModel> records = new List<ApiDirectTweetServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiDirectTweetServerResponseModel> result = await this.DirectTweetService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiDirectTweetServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiDirectTweetServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiDirectTweetServerRequestModel model)
		{
			CreateResponse<ApiDirectTweetServerResponseModel> result = await this.DirectTweetService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/DirectTweets/{result.Record.TweetId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiDirectTweetServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiDirectTweetServerRequestModel> patch)
		{
			ApiDirectTweetServerResponseModel record = await this.DirectTweetService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiDirectTweetServerRequestModel model = await this.PatchModel(id, patch) as ApiDirectTweetServerRequestModel;

				UpdateResponse<ApiDirectTweetServerResponseModel> result = await this.DirectTweetService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiDirectTweetServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiDirectTweetServerRequestModel model)
		{
			ApiDirectTweetServerRequestModel request = await this.PatchModel(id, this.DirectTweetModelMapper.CreatePatch(model)) as ApiDirectTweetServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiDirectTweetServerResponseModel> result = await this.DirectTweetService.Update(id, request);

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
			ActionResponse result = await this.DirectTweetService.Delete(id);

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
		[Route("byTaggedUserId/{taggedUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDirectTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByTaggedUserId(int taggedUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDirectTweetServerResponseModel> response = await this.DirectTweetService.ByTaggedUserId(taggedUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiDirectTweetServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiDirectTweetServerRequestModel> patch)
		{
			var record = await this.DirectTweetService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiDirectTweetServerRequestModel request = this.DirectTweetModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a7c11faa2a6450ab5fd5067ee8cf2094</Hash>
</Codenesium>*/