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
	[Route("api/vehicleOfficers")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VehicleOfficerController : AbstractApiController
	{
		protected IVehicleOfficerService VehicleOfficerService { get; private set; }

		protected IApiVehicleOfficerServerModelMapper VehicleOfficerModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public VehicleOfficerController(
			ApiSettings settings,
			ILogger<VehicleOfficerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleOfficerService vehicleOfficerService,
			IApiVehicleOfficerServerModelMapper vehicleOfficerModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VehicleOfficerService = vehicleOfficerService;
			this.VehicleOfficerModelMapper = vehicleOfficerModelMapper;
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehicleOfficerServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset, string query)
		{
			SearchQuery searchQuery = new SearchQuery();
			if (!searchQuery.Process(this.MaxLimit, this.DefaultLimit, limit, offset, query, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, searchQuery.Error);
			}

			List<ApiVehicleOfficerServerResponseModel> response = await this.VehicleOfficerService.All(searchQuery.Limit, searchQuery.Offset, searchQuery.Query);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVehicleOfficerServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVehicleOfficerServerResponseModel response = await this.VehicleOfficerService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiVehicleOfficerServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVehicleOfficerServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiVehicleOfficerServerResponseModel> records = new List<ApiVehicleOfficerServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiVehicleOfficerServerResponseModel> result = await this.VehicleOfficerService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiVehicleOfficerServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiVehicleOfficerServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiVehicleOfficerServerRequestModel model)
		{
			CreateResponse<ApiVehicleOfficerServerResponseModel> result = await this.VehicleOfficerService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/VehicleOfficers/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleOfficerServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiVehicleOfficerServerRequestModel> patch)
		{
			ApiVehicleOfficerServerResponseModel record = await this.VehicleOfficerService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiVehicleOfficerServerRequestModel model = await this.PatchModel(id, patch) as ApiVehicleOfficerServerRequestModel;

				UpdateResponse<ApiVehicleOfficerServerResponseModel> result = await this.VehicleOfficerService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiVehicleOfficerServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVehicleOfficerServerRequestModel model)
		{
			ApiVehicleOfficerServerRequestModel request = await this.PatchModel(id, this.VehicleOfficerModelMapper.CreatePatch(model)) as ApiVehicleOfficerServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiVehicleOfficerServerResponseModel> result = await this.VehicleOfficerService.Update(id, request);

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
			ActionResponse result = await this.VehicleOfficerService.Delete(id);

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
		[Route("byOfficerId/{officerId}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVehicleOfficerServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByOfficerId(int officerId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, string.Empty, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVehicleOfficerServerResponseModel> response = await this.VehicleOfficerService.ByOfficerId(officerId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiVehicleOfficerServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiVehicleOfficerServerRequestModel> patch)
		{
			var record = await this.VehicleOfficerService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVehicleOfficerServerRequestModel request = this.VehicleOfficerModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a034e5aa5686973a89070e3d9b227189</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/