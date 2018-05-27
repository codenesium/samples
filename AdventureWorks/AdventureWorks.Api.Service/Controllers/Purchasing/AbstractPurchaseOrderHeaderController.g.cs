using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractPurchaseOrderHeaderController: AbstractApiController
	{
		protected IBOPurchaseOrderHeader purchaseOrderHeaderManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractPurchaseOrderHeaderController(
			ServiceSettings settings,
			ILogger<AbstractPurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPurchaseOrderHeader purchaseOrderHeaderManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.purchaseOrderHeaderManager = purchaseOrderHeaderManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiPurchaseOrderHeaderResponseModel> response = await this.purchaseOrderHeaderManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiPurchaseOrderHeaderResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiPurchaseOrderHeaderResponseModel response = await this.purchaseOrderHeaderManager.Get(id);

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
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ApiPurchaseOrderHeaderResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiPurchaseOrderHeaderRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.purchaseOrderHeaderManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.PurchaseOrderID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/PurchaseOrderHeaders/{result.Record.PurchaseOrderID.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
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
				CreateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.purchaseOrderHeaderManager.Create(model);

				if(result.Success)
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

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(DTOPurchaseOrderHeader), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPurchaseOrderHeaderRequestModel model)
		{
			try
			{
				ActionResponse result = await this.purchaseOrderHeaderManager.Update(id, model);

				if (result.Success)
				{
					ApiPurchaseOrderHeaderResponseModel response = await this.purchaseOrderHeaderManager.Get(id);

					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.purchaseOrderHeaderManager.Delete(id);

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
		[Route("getEmployeeID/{employeeID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> GetEmployeeID(int employeeID)
		{
			List<ApiPurchaseOrderHeaderResponseModel> response = await this.purchaseOrderHeaderManager.GetEmployeeID(employeeID);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("getVendorID/{vendorID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
		public async virtual Task<IActionResult> GetVendorID(int vendorID)
		{
			List<ApiPurchaseOrderHeaderResponseModel> response = await this.purchaseOrderHeaderManager.GetVendorID(vendorID);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>5aeff58c9163059c6e7a9a35a0e0b2a8</Hash>
</Codenesium>*/