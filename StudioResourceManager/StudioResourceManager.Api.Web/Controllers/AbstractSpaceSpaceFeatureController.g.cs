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

		protected IApiSpaceSpaceFeatureModelMapper SpaceSpaceFeatureModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSpaceSpaceFeatureController(
			ApiSettings settings,
			ILogger<AbstractSpaceSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceSpaceFeatureService spaceSpaceFeatureService,
			IApiSpaceSpaceFeatureModelMapper spaceSpaceFeatureModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SpaceSpaceFeatureService = spaceSpaceFeatureService;
			this.SpaceSpaceFeatureModelMapper = spaceSpaceFeatureModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceSpaceFeatureResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceSpaceFeatureResponseModel> response = await this.SpaceSpaceFeatureService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSpaceSpaceFeatureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSpaceSpaceFeatureResponseModel response = await this.SpaceSpaceFeatureService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiSpaceSpaceFeatureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpaceSpaceFeatureRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSpaceSpaceFeatureResponseModel> records = new List<ApiSpaceSpaceFeatureResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSpaceSpaceFeatureResponseModel> result = await this.SpaceSpaceFeatureService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiSpaceSpaceFeatureResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSpaceSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceSpaceFeatureResponseModel> result = await this.SpaceSpaceFeatureService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SpaceSpaceFeatures/{result.Record.SpaceId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSpaceSpaceFeatureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> patch)
		{
			ApiSpaceSpaceFeatureResponseModel record = await this.SpaceSpaceFeatureService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSpaceSpaceFeatureRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiSpaceSpaceFeatureResponseModel> result = await this.SpaceSpaceFeatureService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSpaceSpaceFeatureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpaceSpaceFeatureRequestModel model)
		{
			ApiSpaceSpaceFeatureRequestModel request = await this.PatchModel(id, this.SpaceSpaceFeatureModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSpaceSpaceFeatureResponseModel> result = await this.SpaceSpaceFeatureService.Update(id, request);

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

		private async Task<ApiSpaceSpaceFeatureRequestModel> PatchModel(int id, JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> patch)
		{
			var record = await this.SpaceSpaceFeatureService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSpaceSpaceFeatureRequestModel request = this.SpaceSpaceFeatureModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8a84b6ade3a90d17f43923027b0509af</Hash>
</Codenesium>*/