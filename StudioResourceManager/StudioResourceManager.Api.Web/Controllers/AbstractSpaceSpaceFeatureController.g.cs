using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	public abstract class AbstractSpaceSpaceFeatureController : AbstractApiController
	{
		protected ISpaceSpaceFeatureService SpaceSpaceFeatureService { get; private set; }

		protected IApiSpaceSpaceFeatureServerModelMapper SpaceSpaceFeatureModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSpaceSpaceFeatureController(
			ApiSettings settings,
			ILogger<AbstractSpaceSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceSpaceFeatureService spaceSpaceFeatureService,
			IApiSpaceSpaceFeatureServerModelMapper spaceSpaceFeatureModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SpaceSpaceFeatureService = spaceSpaceFeatureService;
			this.SpaceSpaceFeatureModelMapper = spaceSpaceFeatureModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceSpaceFeatureServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await this.SpaceSpaceFeatureService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSpaceSpaceFeatureServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSpaceSpaceFeatureServerResponseModel response = await this.SpaceSpaceFeatureService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiSpaceSpaceFeatureServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpaceSpaceFeatureServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSpaceSpaceFeatureServerResponseModel> records = new List<ApiSpaceSpaceFeatureServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSpaceSpaceFeatureServerResponseModel> result = await this.SpaceSpaceFeatureService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiSpaceSpaceFeatureServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiSpaceSpaceFeatureServerRequestModel model)
		{
			CreateResponse<ApiSpaceSpaceFeatureServerResponseModel> result = await this.SpaceSpaceFeatureService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SpaceSpaceFeatures/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel> patch)
		{
			ApiSpaceSpaceFeatureServerResponseModel record = await this.SpaceSpaceFeatureService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSpaceSpaceFeatureServerRequestModel model = await this.PatchModel(id, patch) as ApiSpaceSpaceFeatureServerRequestModel;

				UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel> result = await this.SpaceSpaceFeatureService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpaceSpaceFeatureServerRequestModel model)
		{
			ApiSpaceSpaceFeatureServerRequestModel request = await this.PatchModel(id, this.SpaceSpaceFeatureModelMapper.CreatePatch(model)) as ApiSpaceSpaceFeatureServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel> result = await this.SpaceSpaceFeatureService.Update(id, request);

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
			ActionResponse result = await this.SpaceSpaceFeatureService.Delete(id);

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
		[Route("bySpaceFeatureId/{spaceFeatureId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceSpaceFeatureServerResponseModel>), 200)]
		public async virtual Task<IActionResult> BySpaceFeatureId(int spaceFeatureId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await this.SpaceSpaceFeatureService.BySpaceFeatureId(spaceFeatureId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("bySpaceId/{spaceId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceSpaceFeatureServerResponseModel>), 200)]
		public async virtual Task<IActionResult> BySpaceId(int spaceId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await this.SpaceSpaceFeatureService.BySpaceId(spaceId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSpaceSpaceFeatureServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel> patch)
		{
			var record = await this.SpaceSpaceFeatureService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSpaceSpaceFeatureServerRequestModel request = this.SpaceSpaceFeatureModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>becb8cbc31fae88cef9aa0eeb9315c06</Hash>
</Codenesium>*/