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
	public abstract class AbstractVehicleRefCapabilityController : AbstractApiController
	{
		protected IVehicleRefCapabilityService VehicleRefCapabilityService { get; private set; }

		protected IApiVehicleRefCapabilityServerModelMapper VehicleRefCapabilityModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVehicleRefCapabilityController(
			ApiSettings settings,
			ILogger<AbstractVehicleRefCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleRefCapabilityService vehicleRefCapabilityService,
			IApiVehicleRefCapabilityServerModelMapper vehicleRefCapabilityModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VehicleRefCapabilityService = vehicleRefCapabilityService;
			this.VehicleRefCapabilityModelMapper = vehicleRefCapabilityModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehicleRefCapabilityServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiVehicleRefCapabilityServerResponseModel> response = await this.VehicleRefCapabilityService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVehicleRefCapabilityServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVehicleRefCapabilityServerResponseModel response = await this.VehicleRefCapabilityService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiVehicleRefCapabilityServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVehicleRefCapabilityServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVehicleRefCapabilityServerResponseModel> records = new List<ApiVehicleRefCapabilityServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVehicleRefCapabilityServerResponseModel> result = await this.VehicleRefCapabilityService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiVehicleRefCapabilityServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiVehicleRefCapabilityServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiVehicleRefCapabilityServerRequestModel model)
		{
			CreateResponse<ApiVehicleRefCapabilityServerResponseModel> result = await this.VehicleRefCapabilityService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/VehicleRefCapabilities/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleRefCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiVehicleRefCapabilityServerRequestModel> patch)
		{
			ApiVehicleRefCapabilityServerResponseModel record = await this.VehicleRefCapabilityService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVehicleRefCapabilityServerRequestModel model = await this.PatchModel(id, patch) as ApiVehicleRefCapabilityServerRequestModel;

				UpdateResponse<ApiVehicleRefCapabilityServerResponseModel> result = await this.VehicleRefCapabilityService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleRefCapabilityServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVehicleRefCapabilityServerRequestModel model)
		{
			ApiVehicleRefCapabilityServerRequestModel request = await this.PatchModel(id, this.VehicleRefCapabilityModelMapper.CreatePatch(model)) as ApiVehicleRefCapabilityServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVehicleRefCapabilityServerResponseModel> result = await this.VehicleRefCapabilityService.Update(id, request);

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
			ActionResponse result = await this.VehicleRefCapabilityService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiVehicleRefCapabilityServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiVehicleRefCapabilityServerRequestModel> patch)
		{
			var record = await this.VehicleRefCapabilityService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVehicleRefCapabilityServerRequestModel request = this.VehicleRefCapabilityModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9a0788dcb4e5c40bd40078a7128477b5</Hash>
</Codenesium>*/