using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
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

namespace FermataFishNS.Api.Web
{
	public abstract class AbstractSpaceXSpaceFeatureController : AbstractApiController
	{
		protected ISpaceXSpaceFeatureService SpaceXSpaceFeatureService { get; private set; }

		protected IApiSpaceXSpaceFeatureModelMapper SpaceXSpaceFeatureModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractSpaceXSpaceFeatureController(
			ApiSettings settings,
			ILogger<AbstractSpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceXSpaceFeatureService spaceXSpaceFeatureService,
			IApiSpaceXSpaceFeatureModelMapper spaceXSpaceFeatureModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.SpaceXSpaceFeatureService = spaceXSpaceFeatureService;
			this.SpaceXSpaceFeatureModelMapper = spaceXSpaceFeatureModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceXSpaceFeatureResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceXSpaceFeatureResponseModel> response = await this.SpaceXSpaceFeatureService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiSpaceXSpaceFeatureResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiSpaceXSpaceFeatureResponseModel response = await this.SpaceXSpaceFeatureService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiSpaceXSpaceFeatureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpaceXSpaceFeatureRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiSpaceXSpaceFeatureResponseModel> records = new List<ApiSpaceXSpaceFeatureResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiSpaceXSpaceFeatureResponseModel> result = await this.SpaceXSpaceFeatureService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiSpaceXSpaceFeatureResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiSpaceXSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceXSpaceFeatureResponseModel> result = await this.SpaceXSpaceFeatureService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/SpaceXSpaceFeatures/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> patch)
		{
			ApiSpaceXSpaceFeatureResponseModel record = await this.SpaceXSpaceFeatureService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiSpaceXSpaceFeatureRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiSpaceXSpaceFeatureResponseModel> result = await this.SpaceXSpaceFeatureService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpaceXSpaceFeatureRequestModel model)
		{
			ApiSpaceXSpaceFeatureRequestModel request = await this.PatchModel(id, this.SpaceXSpaceFeatureModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiSpaceXSpaceFeatureResponseModel> result = await this.SpaceXSpaceFeatureService.Update(id, request);

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
			ActionResponse result = await this.SpaceXSpaceFeatureService.Delete(id);

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
		[Route("byStudioId/{studioId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiSpaceXSpaceFeatureResponseModel>), 200)]
		public async virtual Task<IActionResult> ByStudioId(int studioId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiSpaceXSpaceFeatureResponseModel> response = await this.SpaceXSpaceFeatureService.ByStudioId(studioId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiSpaceXSpaceFeatureRequestModel> PatchModel(int id, JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> patch)
		{
			var record = await this.SpaceXSpaceFeatureService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiSpaceXSpaceFeatureRequestModel request = this.SpaceXSpaceFeatureModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3ebc5b747baf89f9cb57497b86ce1634</Hash>
</Codenesium>*/