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
	public abstract class AbstractQuoteTweetController : AbstractApiController
	{
		protected IQuoteTweetService QuoteTweetService { get; private set; }

		protected IApiQuoteTweetModelMapper QuoteTweetModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractQuoteTweetController(
			ApiSettings settings,
			ILogger<AbstractQuoteTweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IQuoteTweetService quoteTweetService,
			IApiQuoteTweetModelMapper quoteTweetModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.QuoteTweetService = quoteTweetService;
			this.QuoteTweetModelMapper = quoteTweetModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetResponseModel> response = await this.QuoteTweetService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiQuoteTweetResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiQuoteTweetResponseModel response = await this.QuoteTweetService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiQuoteTweetResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiQuoteTweetRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiQuoteTweetResponseModel> records = new List<ApiQuoteTweetResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiQuoteTweetResponseModel> result = await this.QuoteTweetService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiQuoteTweetResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiQuoteTweetRequestModel model)
		{
			CreateResponse<ApiQuoteTweetResponseModel> result = await this.QuoteTweetService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiQuoteTweetResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiQuoteTweetRequestModel> patch)
		{
			ApiQuoteTweetResponseModel record = await this.QuoteTweetService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiQuoteTweetRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiQuoteTweetResponseModel> result = await this.QuoteTweetService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiQuoteTweetResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiQuoteTweetRequestModel model)
		{
			ApiQuoteTweetRequestModel request = await this.PatchModel(id, this.QuoteTweetModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiQuoteTweetResponseModel> result = await this.QuoteTweetService.Update(id, request);

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
		[ProducesResponseType(typeof(List<ApiQuoteTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> ByRetweeterUserId(int retweeterUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetResponseModel> response = await this.QuoteTweetService.ByRetweeterUserId(retweeterUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("bySourceTweetId/{sourceTweetId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiQuoteTweetResponseModel>), 200)]
		public async virtual Task<IActionResult> BySourceTweetId(int sourceTweetId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiQuoteTweetResponseModel> response = await this.QuoteTweetService.BySourceTweetId(sourceTweetId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiQuoteTweetRequestModel> PatchModel(int id, JsonPatchDocument<ApiQuoteTweetRequestModel> patch)
		{
			var record = await this.QuoteTweetService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiQuoteTweetRequestModel request = this.QuoteTweetModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>15c2c6259c425936870aa25b76fdab83</Hash>
</Codenesium>*/