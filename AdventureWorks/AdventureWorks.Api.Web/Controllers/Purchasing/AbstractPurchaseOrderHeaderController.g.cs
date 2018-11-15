using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractPurchaseOrderHeaderController : AbstractApiController
	{
		protected IPurchaseOrderHeaderService PurchaseOrderHeaderService { get; private set; }

		protected IApiPurchaseOrderHeaderServerModelMapper PurchaseOrderHeaderModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPurchaseOrderHeaderController(
			ApiSettings settings,
			ILogger<AbstractPurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderHeaderService purchaseOrderHeaderService,
			IApiPurchaseOrderHeaderServerModelMapper purchaseOrderHeaderModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PurchaseOrderHeaderService = purchaseOrderHeaderService;
			this.PurchaseOrderHeaderModelMapper = purchaseOrderHeaderModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await this.PurchaseOrderHeaderService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPurchaseOrderHeaderServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPurchaseOrderHeaderServerResponseModel response = await this.PurchaseOrderHeaderService.Get(id);

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
		[ProducesResponseType(typeof(CreateResponse<List<ApiPurchaseOrderHeaderServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPurchaseOrderHeaderServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPurchaseOrderHeaderServerResponseModel> records = new List<ApiPurchaseOrderHeaderServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPurchaseOrderHeaderServerResponseModel> result = await this.PurchaseOrderHeaderService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiPurchaseOrderHeaderServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiPurchaseOrderHeaderServerRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderServerResponseModel> result = await this.PurchaseOrderHeaderService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/PurchaseOrderHeaders/{result.Record.PurchaseOrderID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPurchaseOrderHeaderServerRequestModel> patch)
		{
			ApiPurchaseOrderHeaderServerResponseModel record = await this.PurchaseOrderHeaderService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPurchaseOrderHeaderServerRequestModel model = await this.PatchModel(id, patch) as ApiPurchaseOrderHeaderServerRequestModel;

				UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel> result = await this.PurchaseOrderHeaderService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPurchaseOrderHeaderServerRequestModel model)
		{
			ApiPurchaseOrderHeaderServerRequestModel request = await this.PatchModel(id, this.PurchaseOrderHeaderModelMapper.CreatePatch(model)) as ApiPurchaseOrderHeaderServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel> result = await this.PurchaseOrderHeaderService.Update(id, request);

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
			ActionResponse result = await this.PurchaseOrderHeaderService.Delete(id);

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
		[Route("byEmployeeID/{employeeID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByEmployeeID(int employeeID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await this.PurchaseOrderHeaderService.ByEmployeeID(employeeID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byVendorID/{vendorID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByVendorID(int vendorID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await this.PurchaseOrderHeaderService.ByVendorID(vendorID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPurchaseOrderHeaderServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiPurchaseOrderHeaderServerRequestModel> patch)
		{
			var record = await this.PurchaseOrderHeaderService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPurchaseOrderHeaderServerRequestModel request = this.PurchaseOrderHeaderModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>00fc0db66a7304fa4f1ea7c4c58ac0e6</Hash>
</Codenesium>*/