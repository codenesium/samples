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
	[Route("api/vehicleCapabilities")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VehicleCapabilitiesController : AbstractApiController
	{
		protected IVehicleCapabilitiesService VehicleCapabilitiesService { get; private set; }

		protected IApiVehicleCapabilitiesServerModelMapper VehicleCapabilitiesModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public VehicleCapabilitiesController(
			ApiSettings settings,
			ILogger<VehicleCapabilitiesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleCapabilitiesService vehicleCapabilitiesService,
			IApiVehicleCapabilitiesServerModelMapper vehicleCapabilitiesModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VehicleCapabilitiesService = vehicleCapabilitiesService;
			this.VehicleCapabilitiesModelMapper = vehicleCapabilitiesModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehicleCapabilitiesServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiVehicleCapabilitiesServerResponseModel> response = await this.VehicleCapabilitiesService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVehicleCapabilitiesServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVehicleCapabilitiesServerResponseModel response = await this.VehicleCapabilitiesService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiVehicleCapabilitiesServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVehicleCapabilitiesServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVehicleCapabilitiesServerResponseModel> records = new List<ApiVehicleCapabilitiesServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVehicleCapabilitiesServerResponseModel> result = await this.VehicleCapabilitiesService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiVehicleCapabilitiesServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiVehicleCapabilitiesServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiVehicleCapabilitiesServerRequestModel model)
		{
			CreateResponse<ApiVehicleCapabilitiesServerResponseModel> result = await this.VehicleCapabilitiesService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel> patch)
		{
			ApiVehicleCapabilitiesServerResponseModel record = await this.VehicleCapabilitiesService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVehicleCapabilitiesServerRequestModel model = await this.PatchModel(id, patch) as ApiVehicleCapabilitiesServerRequestModel;

				UpdateResponse<ApiVehicleCapabilitiesServerResponseModel> result = await this.VehicleCapabilitiesService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVehicleCapabilitiesServerRequestModel model)
		{
			ApiVehicleCapabilitiesServerRequestModel request = await this.PatchModel(id, this.VehicleCapabilitiesModelMapper.CreatePatch(model)) as ApiVehicleCapabilitiesServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVehicleCapabilitiesServerResponseModel> result = await this.VehicleCapabilitiesService.Update(id, request);

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
			ActionResponse result = await this.VehicleCapabilitiesService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiVehicleCapabilitiesServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel> patch)
		{
			var record = await this.VehicleCapabilitiesService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVehicleCapabilitiesServerRequestModel request = this.VehicleCapabilitiesModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3a426e0b1b8ef2fc63295a3a167ff52a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/