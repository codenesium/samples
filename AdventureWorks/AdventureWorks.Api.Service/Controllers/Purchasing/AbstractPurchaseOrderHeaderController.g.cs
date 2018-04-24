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
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOPurchaseOrderHeader), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOPurchaseOrderHeader response = this.purchaseOrderHeaderManager.GetById(id).PurchaseOrderHeaders.FirstOrDefault();
			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOPurchaseOrderHeader>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.purchaseOrderHeaderManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.PurchaseOrderHeaders);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOPurchaseOrderHeader), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] PurchaseOrderHeaderModel model)
		{
			CreateResponse<int> result = await this.purchaseOrderHeaderManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/purchaseOrderHeaders/{result.Id.ToString()}");
				POCOPurchaseOrderHeader response = this.purchaseOrderHeaderManager.GetById(result.Id).PurchaseOrderHeaders.First();
				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<int>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<PurchaseOrderHeaderModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.purchaseOrderHeaderManager.Create(model);

				if(result.Success)
				{
					ids.Add(result.Id);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(ids);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOPurchaseOrderHeader), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] PurchaseOrderHeaderModel model)
		{
			try
			{
				ActionResponse result = await this.purchaseOrderHeaderManager.Update(id, model);

				if (result.Success)
				{
					POCOPurchaseOrderHeader response = this.purchaseOrderHeaderManager.GetById(id).PurchaseOrderHeaders.First();
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
		[Route("ByEmployeeID/{id}")]
		[ReadOnly]
		[Route("~/api/Employees/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOPurchaseOrderHeader>), 200)]
		public virtual IActionResult ByEmployeeID(int id)
		{
			ApiResponse response = this.purchaseOrderHeaderManager.GetWhere(x => x.EmployeeID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.PurchaseOrderHeaders);
			}
		}

		[HttpGet]
		[Route("ByVendorID/{id}")]
		[ReadOnly]
		[Route("~/api/Vendors/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOPurchaseOrderHeader>), 200)]
		public virtual IActionResult ByVendorID(int id)
		{
			ApiResponse response = this.purchaseOrderHeaderManager.GetWhere(x => x.VendorID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.PurchaseOrderHeaders);
			}
		}

		[HttpGet]
		[Route("ByShipMethodID/{id}")]
		[ReadOnly]
		[Route("~/api/ShipMethods/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOPurchaseOrderHeader>), 200)]
		public virtual IActionResult ByShipMethodID(int id)
		{
			ApiResponse response = this.purchaseOrderHeaderManager.GetWhere(x => x.ShipMethodID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.PurchaseOrderHeaders);
			}
		}
	}
}

/*<Codenesium>
    <Hash>b868a5514096773a922cc2fcf058d11a</Hash>
</Codenesium>*/