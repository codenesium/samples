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
	public abstract class AbstractLocationController : AbstractApiController
	{
		protected ILocationService LocationService { get; private set; }

		protected IApiLocationServerModelMapper LocationModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractLocationController(
			ApiSettings settings,
			ILogger<AbstractLocationController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILocationService locationService,
			IApiLocationServerModelMapper locationModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.LocationService = locationService;
			this.LocationModelMapper = locationModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLocationServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiLocationServerResponseModel> response = await this.LocationService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiLocationServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiLocationServerResponseModel response = await this.LocationService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiLocationServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiLocationServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiLocationServerResponseModel> records = new List<ApiLocationServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiLocationServerResponseModel> result = await this.LocationService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiLocationServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiLocationServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiLocationServerRequestModel model)
		{
			CreateResponse<ApiLocationServerResponseModel> result = await this.LocationService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Locations/{result.Record.LocationId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiLocationServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiLocationServerRequestModel> patch)
		{
			ApiLocationServerResponseModel record = await this.LocationService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiLocationServerRequestModel model = await this.PatchModel(id, patch) as ApiLocationServerRequestModel;

				UpdateResponse<ApiLocationServerResponseModel> result = await this.LocationService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiLocationServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiLocationServerRequestModel model)
		{
			ApiLocationServerRequestModel request = await this.PatchModel(id, this.LocationModelMapper.CreatePatch(model)) as ApiLocationServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiLocationServerResponseModel> result = await this.LocationService.Update(id, request);

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
			ActionResponse result = await this.LocationService.Delete(id);

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
		[Route("{locationId}/Tweets")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiTweetServerResponseModel>), 200)]
		public async virtual Task<IActionResult> TweetsByLocationId(int locationId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiTweetServerResponseModel> response = await this.LocationService.TweetsByLocationId(locationId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{locationLocationId}/Users")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiUserServerResponseModel>), 200)]
		public async virtual Task<IActionResult> UsersByLocationLocationId(int locationLocationId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiUserServerResponseModel> response = await this.LocationService.UsersByLocationLocationId(locationLocationId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byUserUserId/{userUserId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLocationServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByUserUserId(int userUserId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiLocationServerResponseModel> response = await this.LocationService.ByUserUserId(userUserId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiLocationServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiLocationServerRequestModel> patch)
		{
			var record = await this.LocationService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiLocationServerRequestModel request = this.LocationModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3de166617ddb8e15f4c3a495a6004304</Hash>
</Codenesium>*/