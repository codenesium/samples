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

		protected IApiTweetModelMapper TweetModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractTweetController(
			ApiSettings settings,
			ILogger<AbstractTweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITweetService tweetService,
			IApiTweetModelMapper tweetModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.TweetService = tweetService;
			this.TweetModelMapper = tweetModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetResponseModel> response = await this.TweetService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiTweetResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiTweetResponseModel response = await this.TweetService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiTweetResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTweetRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiTweetResponseModel> records = new List<ApiTweetResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiTweetResponseModel> result = await this.TweetService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiTweetResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiTweetRequestModel model)
		{
			CreateResponse<ApiTweetResponseModel> result = await this.TweetService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTweetResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTweetRequestModel> patch)
		{
			ApiTweetResponseModel record = await this.TweetService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiTweetRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiTweetResponseModel> result = await this.TweetService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiTweetResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTweetRequestModel model)
		{
			ApiTweetRequestModel request = await this.PatchModel(id, this.TweetModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiTweetResponseModel> result = await this.TweetService.Update(id, request);

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
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.TweetService.Delete(id);

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
		[Route("byLocationId/{locationId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLocationId(int locationId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetResponseModel> response = await this.TweetService.ByLocationId(locationId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byUserUserId/{userUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> ByUserUserId(int userUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetResponseModel> response = await this.TweetService.ByUserUserId(userUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{sourceTweetId}/QuoteTweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> QuoteTweets(int sourceTweetId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetResponseModel> response = await this.TweetService.QuoteTweets(sourceTweetId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{tweetTweetId}/Retweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRetweetResponseModel>), 200)]
		public async virtual Task<IActionResult> Retweets(int tweetTweetId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRetweetResponseModel> response = await this.TweetService.Retweets(tweetTweetId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiTweetRequestModel> PatchModel(int id, JsonPatchDocument<ApiTweetRequestModel> patch)
		{
			var record = await this.TweetService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiTweetRequestModel request = this.TweetModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d59945fe906db764ab2dadfb0d7b9bea</Hash>
</Codenesium>*/