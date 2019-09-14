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
	[Route("api/quoteTweets")]
	[ApiController]
	[ApiVersion("1.0")]

	public class QuoteTweetController : AbstractApiController
	{
		protected IQuoteTweetService QuoteTweetService { get; private set; }

		protected IApiQuoteTweetServerModelMapper QuoteTweetModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public QuoteTweetController(
			ApiSettings settings,
			ILogger<QuoteTweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IQuoteTweetService quoteTweetService,
			IApiQuoteTweetServerModelMapper quoteTweetModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.QuoteTweetService = quoteTweetService;
			this.QuoteTweetModelMapper = quoteTweetModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiQuoteTweetServerResponseModel> response = await this.QuoteTweetService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiQuoteTweetServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiQuoteTweetServerResponseModel response = await this.QuoteTweetService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiQuoteTweetServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiQuoteTweetServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiQuoteTweetServerResponseModel> records = new List<ApiQuoteTweetServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiQuoteTweetServerResponseModel> result = await this.QuoteTweetService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiQuoteTweetServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiQuoteTweetServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiQuoteTweetServerRequestModel model)
		{
			CreateResponse<ApiQuoteTweetServerResponseModel> result = await this.QuoteTweetService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/QuoteTweets/{result.Record.QuoteTweetId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiQuoteTweetServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiQuoteTweetServerRequestModel> patch)
		{
			ApiQuoteTweetServerResponseModel record = await this.QuoteTweetService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiQuoteTweetServerRequestModel model = await this.PatchModel(id, patch) as ApiQuoteTweetServerRequestModel;

				UpdateResponse<ApiQuoteTweetServerResponseModel> result = await this.QuoteTweetService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiQuoteTweetServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiQuoteTweetServerRequestModel model)
		{
			ApiQuoteTweetServerRequestModel request = await this.PatchModel(id, this.QuoteTweetModelMapper.CreatePatch(model)) as ApiQuoteTweetServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiQuoteTweetServerResponseModel> result = await this.QuoteTweetService.Update(id, request);

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
			ActionResponse result = await this.QuoteTweetService.Delete(id);

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
		[Route("byRetweeterUserId/{retweeterUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByRetweeterUserId(int retweeterUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetServerResponseModel> response = await this.QuoteTweetService.ByRetweeterUserId(retweeterUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("bySourceTweetId/{sourceTweetId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> BySourceTweetId(int sourceTweetId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetServerResponseModel> response = await this.QuoteTweetService.BySourceTweetId(sourceTweetId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiQuoteTweetServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiQuoteTweetServerRequestModel> patch)
		{
			var record = await this.QuoteTweetService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiQuoteTweetServerRequestModel request = this.QuoteTweetModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f61bc6bd205bb376cb3ecfec29add8e0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/