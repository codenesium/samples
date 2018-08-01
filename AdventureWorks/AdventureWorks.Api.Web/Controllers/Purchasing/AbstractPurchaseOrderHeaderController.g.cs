using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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

		protected IApiPurchaseOrderHeaderModelMapper PurchaseOrderHeaderModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractPurchaseOrderHeaderController(
			ApiSettings settings,
			ILogger<AbstractPurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderHeaderService purchaseOrderHeaderService,
			IApiPurchaseOrderHeaderModelMapper purchaseOrderHeaderModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.PurchaseOrderHeaderService = purchaseOrderHeaderService;
			this.PurchaseOrderHeaderModelMapper = purchaseOrderHeaderModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPurchaseOrderHeaderResponseModel> response = await this.PurchaseOrderHeaderService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPurchaseOrderHeaderResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPurchaseOrderHeaderResponseModel response = await this.PurchaseOrderHeaderService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPurchaseOrderHeaderRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiPurchaseOrderHeaderResponseModel> records = new List<ApiPurchaseOrderHeaderResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.PurchaseOrderHeaderService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiPurchaseOrderHeaderResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPurchaseOrderHeaderRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.PurchaseOrderHeaderService.Create(model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPurchaseOrderHeaderResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPurchaseOrderHeaderRequestModel> patch)
		{
			ApiPurchaseOrderHeaderResponseModel record = await this.PurchaseOrderHeaderService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiPurchaseOrderHeaderRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.PurchaseOrderHeaderService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiPurchaseOrderHeaderResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPurchaseOrderHeaderRequestModel model)
		{
			ApiPurchaseOrderHeaderRequestModel request = await this.PatchModel(id, this.PurchaseOrderHeaderModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.PurchaseOrderHeaderService.Update(id, request);

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
			ActionResponse result = await this.PurchaseOrderHeaderService.Delete(id);

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
		[Route("byEmployeeID/{employeeID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> ByEmployeeID(int employeeID)
		{
			List<ApiPurchaseOrderHeaderResponseModel> response = await this.PurchaseOrderHeaderService.ByEmployeeID(employeeID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("byVendorID/{vendorID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> ByVendorID(int vendorID)
		{
			List<ApiPurchaseOrderHeaderResponseModel> response = await this.PurchaseOrderHeaderService.ByVendorID(vendorID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{purchaseOrderID}/PurchaseOrderDetails")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> PurchaseOrderDetails(int purchaseOrderID, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPurchaseOrderDetailResponseModel> response = await this.PurchaseOrderHeaderService.PurchaseOrderDetails(purchaseOrderID, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiPurchaseOrderHeaderRequestModel> PatchModel(int id, JsonPatchDocument<ApiPurchaseOrderHeaderRequestModel> patch)
		{
			var record = await this.PurchaseOrderHeaderService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiPurchaseOrderHeaderRequestModel request = this.PurchaseOrderHeaderModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>c47bc0265209d4f20843cd38cfe4c90d</Hash>
</Codenesium>*/