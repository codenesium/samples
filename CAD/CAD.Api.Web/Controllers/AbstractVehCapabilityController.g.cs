using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web
{
	public abstract class AbstractVehCapabilityController : AbstractApiController
	{
		protected IVehCapabilityService VehCapabilityService { get; private set; }

		protected IApiVehCapabilityServerModelMapper VehCapabilityModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVehCapabilityController(
			ApiSettings settings,
			ILogger<AbstractVehCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehCapabilityService vehCapabilityService,
			IApiVehCapabilityServerModelMapper vehCapabilityModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VehCapabilityService = vehCapabilityService;
			this.VehCapabilityModelMapper = vehCapabilityModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehCapabilityServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiVehCapabilityServerResponseModel> response = await this.VehCapabilityService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVehCapabilityServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVehCapabilityServerResponseModel response = await this.VehCapabilityService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiVehCapabilityServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVehCapabilityServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVehCapabilityServerResponseModel> records = new List<ApiVehCapabilityServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVehCapabilityServerResponseModel> result = await this.VehCapabilityService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiVehCapabilityServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiVehCapabilityServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiVehCapabilityServerRequestModel model)
		{
			CreateResponse<ApiVehCapabilityServerResponseModel> result = await this.VehCapabilityService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/VehCapabilities/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiVehCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiVehCapabilityServerRequestModel> patch)
		{
			ApiVehCapabilityServerResponseModel record = await this.VehCapabilityService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVehCapabilityServerRequestModel model = await this.PatchModel(id, patch) as ApiVehCapabilityServerRequestModel;

				UpdateResponse<ApiVehCapabilityServerResponseModel> result = await this.VehCapabilityService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVehCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVehCapabilityServerRequestModel model)
		{
			ApiVehCapabilityServerRequestModel request = await this.PatchModel(id, this.VehCapabilityModelMapper.CreatePatch(model)) as ApiVehCapabilityServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVehCapabilityServerResponseModel> result = await this.VehCapabilityService.Update(id, request);

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
			ActionResponse result = await this.VehCapabilityService.Delete(id);

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
		[Route("{vehicleCapabilityId}/VehicleCapabilities")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehicleCapabilitiesServerResponseModel>), 200)]
		public async virtual Task<IActionResult> VehicleCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVehicleCapabilitiesServerResponseModel> response = await this.VehCapabilityService.VehicleCapabilitiesByVehicleCapabilityId(vehicleCapabilityId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiVehCapabilityServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiVehCapabilityServerRequestModel> patch)
		{
			var record = await this.VehCapabilityService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVehCapabilityServerRequestModel request = this.VehCapabilityModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5c3bcbe8f281084b9713bad8105591bb</Hash>
</Codenesium>*/