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

		protected IApiUserModelMapper UserModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractUserController(
			ApiSettings settings,
			ILogger<AbstractUserController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUserService userService,
			IApiUserModelMapper userModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.UserService = userService;
			this.UserModelMapper = userModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUserResponseModel> response = await this.UserService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiUserResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiUserResponseModel response = await this.UserService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiUserRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiUserResponseModel> records = new List<ApiUserResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiUserResponseModel> result = await this.UserService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiUserResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiUserRequestModel model)
		{
			CreateResponse<ApiUserResponseModel> result = await this.UserService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiUserResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiUserRequestModel> patch)
		{
			ApiUserResponseModel record = await this.UserService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiUserRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiUserResponseModel> result = await this.UserService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiUserResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiUserRequestModel model)
		{
			ApiUserRequestModel request = await this.PatchModel(id, this.UserModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiUserResponseModel> result = await this.UserService.Update(id, request);

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
		[ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLocationLocationId(int locationLocationId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUserResponseModel> response = await this.UserService.ByLocationLocationId(locationLocationId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{taggedUserId}/DirectTweetsByTaggedUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDirectTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> DirectTweetsByTaggedUserId(int taggedUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiDirectTweetResponseModel> response = await this.UserService.DirectTweetsByTaggedUserId(taggedUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{followedUserId}/FollowersByFollowedUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiFollowerResponseModel>), 200)]
		public async virtual Task<IActionResult> FollowersByFollowedUserId(int followedUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiFollowerResponseModel> response = await this.UserService.FollowersByFollowedUserId(followedUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{followingUserId}/FollowersByFollowingUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiFollowerResponseModel>), 200)]
		public async virtual Task<IActionResult> FollowersByFollowingUserId(int followingUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiFollowerResponseModel> response = await this.UserService.FollowersByFollowingUserId(followingUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{senderUserId}/MessagesBySenderUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessageResponseModel>), 200)]
		public async virtual Task<IActionResult> MessagesBySenderUserId(int senderUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiMessageResponseModel> response = await this.UserService.MessagesBySenderUserId(senderUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{toUserId}/MessengersByToUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessengerResponseModel>), 200)]
		public async virtual Task<IActionResult> MessengersByToUserId(int toUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiMessengerResponseModel> response = await this.UserService.MessengersByToUserId(toUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{userId}/MessengersByUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMessengerResponseModel>), 200)]
		public async virtual Task<IActionResult> MessengersByUserId(int userId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiMessengerResponseModel> response = await this.UserService.MessengersByUserId(userId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{retweeterUserId}/QuoteTweetsByRetweeterUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> QuoteTweetsByRetweeterUserId(int retweeterUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetResponseModel> response = await this.UserService.QuoteTweetsByRetweeterUserId(retweeterUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{replierUserId}/RepliesByReplierUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiReplyResponseModel>), 200)]
		public async virtual Task<IActionResult> RepliesByReplierUserId(int replierUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiReplyResponseModel> response = await this.UserService.RepliesByReplierUserId(replierUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{retwitterUserId}/RetweetsByRetwitterUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiRetweetResponseModel>), 200)]
		public async virtual Task<IActionResult> RetweetsByRetwitterUserId(int retwitterUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiRetweetResponseModel> response = await this.UserService.RetweetsByRetwitterUserId(retwitterUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{userUserId}/TweetsByUserUserId")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> TweetsByUserUserId(int userUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetResponseModel> response = await this.UserService.TweetsByUserUserId(userUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byLikerUserId/{likerUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
		public async virtual Task<IActionResult> ByLikerUserId(int likerUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUserResponseModel> response = await this.UserService.ByLikerUserId(likerUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiUserRequestModel> PatchModel(int id, JsonPatchDocument<ApiUserRequestModel> patch)
		{
			var record = await this.UserService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiUserRequestModel request = this.UserModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>bca3f87f215c46a385acf6c4c3f9bc2e</Hash>
</Codenesium>*/