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
	public abstract class AbstractTweetController : AbstractApiController
	{
		protected ITweetService TweetService { get; private set; }

		protected IApiTweetServerModelMapper TweetModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTweetController(
			ApiSettings settings,
			ILogger<AbstractTweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITweetService tweetService,
			IApiTweetServerModelMapper tweetModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TweetService = tweetService;
			this.TweetModelMapper = tweetModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetServerResponseModel> response = await this.TweetService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTweetServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTweetServerResponseModel response = await this.TweetService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiTweetServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTweetServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTweetServerResponseModel> records = new List<ApiTweetServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTweetServerResponseModel> result = await this.TweetService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiTweetServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiTweetServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiTweetServerRequestModel model)
		{
			CreateResponse<ApiTweetServerResponseModel> result = await this.TweetService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Tweets/{result.Record.TweetId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiTweetServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTweetServerRequestModel> patch)
		{
			ApiTweetServerResponseModel record = await this.TweetService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTweetServerRequestModel model = await this.PatchModel(id, patch) as ApiTweetServerRequestModel;

				UpdateResponse<ApiTweetServerResponseModel> result = await this.TweetService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTweetServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTweetServerRequestModel model)
		{
			ApiTweetServerRequestModel request = await this.PatchModel(id, this.TweetModelMapper.CreatePatch(model)) as ApiTweetServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTweetServerResponseModel> result = await this.TweetService.Update(id, request);

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
			ActionResponse result = await this.TweetService.Delete(id);

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
		[Route("byLocationId/{locationId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLocationId(int locationId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetServerResponseModel> response = await this.TweetService.ByLocationId(locationId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byUserUserId/{userUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByUserUserId(int userUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetServerResponseModel> response = await this.TweetService.ByUserUserId(userUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{sourceTweetId}/QuoteTweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> QuoteTweetsBySourceTweetId(int sourceTweetId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetServerResponseModel> response = await this.TweetService.QuoteTweetsBySourceTweetId(sourceTweetId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tweetTweetId}/Retweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRetweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> RetweetsByTweetTweetId(int tweetTweetId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRetweetServerResponseModel> response = await this.TweetService.RetweetsByTweetTweetId(tweetTweetId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTweetServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiTweetServerRequestModel> patch)
		{
			var record = await this.TweetService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTweetServerRequestModel request = this.TweetModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>215a30a884ecdb7c6cfd0ebc67d7013e</Hash>
</Codenesium>*/