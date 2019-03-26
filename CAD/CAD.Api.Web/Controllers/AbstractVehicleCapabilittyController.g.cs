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
	public abstract class AbstractVehicleCapabilittyController : AbstractApiController
	{
		protected IVehicleCapabilittyService VehicleCapabilittyService { get; private set; }

		protected IApiVehicleCapabilittyServerModelMapper VehicleCapabilittyModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVehicleCapabilittyController(
			ApiSettings settings,
			ILogger<AbstractVehicleCapabilittyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleCapabilittyService vehicleCapabilittyService,
			IApiVehicleCapabilittyServerModelMapper vehicleCapabilittyModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VehicleCapabilittyService = vehicleCapabilittyService;
			this.VehicleCapabilittyModelMapper = vehicleCapabilittyModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehicleCapabilittyServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiVehicleCapabilittyServerResponseModel> response = await this.VehicleCapabilittyService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVehicleCapabilittyServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVehicleCapabilittyServerResponseModel response = await this.VehicleCapabilittyService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiVehicleCapabilittyServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVehicleCapabilittyServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVehicleCapabilittyServerResponseModel> records = new List<ApiVehicleCapabilittyServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVehicleCapabilittyServerResponseModel> result = await this.VehicleCapabilittyService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiVehicleCapabilittyServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiVehicleCapabilittyServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiVehicleCapabilittyServerRequestModel model)
		{
			CreateResponse<ApiVehicleCapabilittyServerResponseModel> result = await this.VehicleCapabilittyService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/VehicleCapabilities/{result.Record.VehicleId}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleCapabilittyServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiVehicleCapabilittyServerRequestModel> patch)
		{
			ApiVehicleCapabilittyServerResponseModel record = await this.VehicleCapabilittyService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVehicleCapabilittyServerRequestModel model = await this.PatchModel(id, patch) as ApiVehicleCapabilittyServerRequestModel;

				UpdateResponse<ApiVehicleCapabilittyServerResponseModel> result = await this.VehicleCapabilittyService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleCapabilittyServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVehicleCapabilittyServerRequestModel model)
		{
			ApiVehicleCapabilittyServerRequestModel request = await this.PatchModel(id, this.VehicleCapabilittyModelMapper.CreatePatch(model)) as ApiVehicleCapabilittyServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVehicleCapabilittyServerResponseModel> result = await this.VehicleCapabilittyService.Update(id, request);

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
			ActionResponse result = await this.VehicleCapabilittyService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		private async Task<ApiVehicleCapabilittyServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiVehicleCapabilittyServerRequestModel> patch)
		{
			var record = await this.VehicleCapabilittyService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVehicleCapabilittyServerRequestModel request = this.VehicleCapabilittyModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b7c478219ade6ff839f1944d93ebacc9</Hash>
</Codenesium>*/