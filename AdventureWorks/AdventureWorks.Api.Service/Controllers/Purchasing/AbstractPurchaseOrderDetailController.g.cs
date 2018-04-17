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
	public abstract class AbstractPurchaseOrderDetailController: AbstractApiController
	{
		protected IBOPurchaseOrderDetail purchaseOrderDetailManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractPurchaseOrderDetailController(
			ILogger<AbstractPurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPurchaseOrderDetail purchaseOrderDetailManager
			)
			: base(logger, transactionCoordinator)
		{
			this.purchaseOrderDetailManager = purchaseOrderDetailManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.purchaseOrderDetailManager.GetById(id);
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
			ApiResponse response = this.purchaseOrderDetailManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] PurchaseOrderDetailModel model)
		{
			var result = await this.purchaseOrderDetailManager.Create(model);

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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<PurchaseOrderDetailModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.purchaseOrderDetailManager.Create(model);

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
		public virtual async Task<IActionResult> Update(int id, [FromBody] PurchaseOrderDetailModel model)
		{
			var result = await this.purchaseOrderDetailManager.Update(id, model);

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
			var result = await this.purchaseOrderDetailManager.Delete(id);

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
		[Route("ByPurchaseOrderID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/PurchaseOrderHeaders/{id}/PurchaseOrderDetails")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByPurchaseOrderID(int id)
		{
			ApiResponse response = this.purchaseOrderDetailManager.GetWhere(x => x.PurchaseOrderID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/PurchaseOrderDetails")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			ApiResponse response = this.purchaseOrderDetailManager.GetWhere(x => x.ProductID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>13fa3d307525c7d7ecff59d3dd4784ab</Hash>
</Codenesium>*/