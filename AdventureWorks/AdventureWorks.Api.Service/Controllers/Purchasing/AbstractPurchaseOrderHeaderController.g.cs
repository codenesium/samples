using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
			ILogger<AbstractPurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPurchaseOrderHeader purchaseOrderHeaderManager
			)
			: base(logger, transactionCoordinator)
		{
			this.purchaseOrderHeaderManager = purchaseOrderHeaderManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.purchaseOrderHeaderManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.purchaseOrderHeaderManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] PurchaseOrderHeaderModel model)
		{
			var result = await this.purchaseOrderHeaderManager.Create(model);

			if(result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<PurchaseOrderHeaderModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.purchaseOrderHeaderManager.Create(model);

				if(!result.Success)
				{
					return this.BadRequest(result);
				}
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] PurchaseOrderHeaderModel model)
		{
			var result = await this.purchaseOrderHeaderManager.Update(id, model);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.purchaseOrderHeaderManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpGet]
		[Route("ByEmployeeID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByEmployeeID(int id)
		{
			ApiResponse response = this.purchaseOrderHeaderManager.GetWhere(x => x.EmployeeID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByVendorID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Vendors/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByVendorID(int id)
		{
			ApiResponse response = this.purchaseOrderHeaderManager.GetWhere(x => x.VendorID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShipMethodID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ShipMethods/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByShipMethodID(int id)
		{
			ApiResponse response = this.purchaseOrderHeaderManager.GetWhere(x => x.ShipMethodID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>f5f0999559f0c942bba635d8d2706327</Hash>
</Codenesium>*/