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
	public abstract class AbstractVehicleCapabilityController : AbstractApiController
	{
		protected IVehicleCapabilityService VehicleCapabilityService { get; private set; }

		protected IApiVehicleCapabilityServerModelMapper VehicleCapabilityModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVehicleCapabilityController(
			ApiSettings settings,
			ILogger<AbstractVehicleCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleCapabilityService vehicleCapabilityService,
			IApiVehicleCapabilityServerModelMapper vehicleCapabilityModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VehicleCapabilityService = vehicleCapabilityService;
			this.VehicleCapabilityModelMapper = vehicleCapabilityModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehicleCapabilityServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiVehicleCapabilityServerResponseModel> response = await this.VehicleCapabilityService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVehicleCapabilityServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVehicleCapabilityServerResponseModel response = await this.VehicleCapabilityService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiVehicleCapabilityServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVehicleCapabilityServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVehicleCapabilityServerResponseModel> records = new List<ApiVehicleCapabilityServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVehicleCapabilityServerResponseModel> result = await this.VehicleCapabilityService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiVehicleCapabilityServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiVehicleCapabilityServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiVehicleCapabilityServerRequestModel model)
		{
			CreateResponse<ApiVehicleCapabilityServerResponseModel> result = await this.VehicleCapabilityService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/VehicleCapabilities/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiVehicleCapabilityServerRequestModel> patch)
		{
			ApiVehicleCapabilityServerResponseModel record = await this.VehicleCapabilityService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVehicleCapabilityServerRequestModel model = await this.PatchModel(id, patch) as ApiVehicleCapabilityServerRequestModel;

				UpdateResponse<ApiVehicleCapabilityServerResponseModel> result = await this.VehicleCapabilityService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVehicleCapabilityServerRequestModel model)
		{
			ApiVehicleCapabilityServerRequestModel request = await this.PatchModel(id, this.VehicleCapabilityModelMapper.CreatePatch(model)) as ApiVehicleCapabilityServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVehicleCapabilityServerResponseModel> result = await this.VehicleCapabilityService.Update(id, request);

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
			ActionResponse result = await this.VehicleCapabilityService.Delete(id);

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
		[Route("{vehicleCapabilityId}/VehicleRefCapabilities")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehicleRefCapabilityServerResponseModel>), 200)]
		public async virtual Task<IActionResult> VehicleRefCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVehicleRefCapabilityServerResponseModel> response = await this.VehicleCapabilityService.VehicleRefCapabilitiesByVehicleCapabilityId(vehicleCapabilityId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiVehicleCapabilityServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiVehicleCapabilityServerRequestModel> patch)
		{
			var record = await this.VehicleCapabilityService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVehicleCapabilityServerRequestModel request = this.VehicleCapabilityModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d34e5777d63e90088637b78e06e8c65c</Hash>
</Codenesium>*/