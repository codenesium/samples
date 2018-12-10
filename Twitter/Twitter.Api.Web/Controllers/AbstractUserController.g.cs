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
	public abstract class AbstractUserController : AbstractApiController
	{
		protected IUserService UserService { get; private set; }

		protected IApiUserServerModelMapper UserModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractUserController(
			ApiSettings settings,
			ILogger<AbstractUserController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUserService userService,
			IApiUserServerModelMapper userModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.UserService = userService;
			this.UserModelMapper = userModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUserServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUserServerResponseModel> response = await this.UserService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiUserServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiUserServerResponseModel response = await this.UserService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiUserServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiUserServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiUserServerResponseModel> records = new List<ApiUserServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiUserServerResponseModel> result = await this.UserService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiUserServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiUserServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiUserServerRequestModel model)
		{
			CreateResponse<ApiUserServerResponseModel> result = await this.UserService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Users/{result.Record.UserId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiUserServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiUserServerRequestModel> patch)
		{
			ApiUserServerResponseModel record = await this.UserService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiUserServerRequestModel model = await this.PatchModel(id, patch) as ApiUserServerRequestModel;

				UpdateResponse<ApiUserServerResponseModel> result = await this.UserService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiUserServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiUserServerRequestModel model)
		{
			ApiUserServerRequestModel request = await this.PatchModel(id, this.UserModelMapper.CreatePatch(model)) as ApiUserServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiUserServerResponseModel> result = await this.UserService.Update(id, request);

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
			ActionResponse result = await this.UserService.Delete(id);

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
		[Route("byLocationLocationId/{locationLocationId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUserServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLocationLocationId(int locationLocationId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUserServerResponseModel> response = await this.UserService.ByLocationLocationId(locationLocationId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{taggedUserId}/DirectTweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDirectTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> DirectTweetsByTaggedUserId(int taggedUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDirectTweetServerResponseModel> response = await this.UserService.DirectTweetsByTaggedUserId(taggedUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{followedUserId}/Followers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiFollowerServerResponseModel>), 200)]
		public async virtual Task<IActionResult> FollowersByFollowedUserId(int followedUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiFollowerServerResponseModel> response = await this.UserService.FollowersByFollowedUserId(followedUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{followingUserId}/FollowersByFollowingUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiFollowerServerResponseModel>), 200)]
		public async virtual Task<IActionResult> FollowersByFollowingUserId(int followingUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiFollowerServerResponseModel> response = await this.UserService.FollowersByFollowingUserId(followingUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{senderUserId}/Messages")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessageServerResponseModel>), 200)]
		public async virtual Task<IActionResult> MessagesBySenderUserId(int senderUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiMessageServerResponseModel> response = await this.UserService.MessagesBySenderUserId(senderUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{toUserId}/Messengers")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessengerServerResponseModel>), 200)]
		public async virtual Task<IActionResult> MessengersByToUserId(int toUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiMessengerServerResponseModel> response = await this.UserService.MessengersByToUserId(toUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{userId}/MessengersByUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessengerServerResponseModel>), 200)]
		public async virtual Task<IActionResult> MessengersByUserId(int userId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiMessengerServerResponseModel> response = await this.UserService.MessengersByUserId(userId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{retweeterUserId}/QuoteTweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> QuoteTweetsByRetweeterUserId(int retweeterUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetServerResponseModel> response = await this.UserService.QuoteTweetsByRetweeterUserId(retweeterUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{replierUserId}/Replies")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiReplyServerResponseModel>), 200)]
		public async virtual Task<IActionResult> RepliesByReplierUserId(int replierUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiReplyServerResponseModel> response = await this.UserService.RepliesByReplierUserId(replierUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{retwitterUserId}/Retweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRetweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> RetweetsByRetwitterUserId(int retwitterUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRetweetServerResponseModel> response = await this.UserService.RetweetsByRetwitterUserId(retwitterUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{userUserId}/Tweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TweetsByUserUserId(int userUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetServerResponseModel> response = await this.UserService.TweetsByUserUserId(userUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiUserServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiUserServerRequestModel> patch)
		{
			var record = await this.UserService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiUserServerRequestModel request = this.UserModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d1dbe49f36eeaf436ca8045f15619a18</Hash>
</Codenesium>*/