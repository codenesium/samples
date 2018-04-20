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
	public abstract class AbstractSalesOrderHeaderController: AbstractApiController
	{
		protected IBOSalesOrderHeader salesOrderHeaderManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesOrderHeaderController(
			ServiceSettings settings,
			ILogger<AbstractSalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesOrderHeader salesOrderHeaderManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.salesOrderHeaderManager = salesOrderHeaderManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(ApiResponse), 404)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(ApiResponse), 404)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.salesOrderHeaderManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] SalesOrderHeaderModel model)
		{
			var result = await this.salesOrderHeaderManager.Create(model);

			if(result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.settings.ExternalBaseUrl}/api/salesOrderHeaders/{result.Id.ToString()}");
				return this.Ok(result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<SalesOrderHeaderModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			foreach (var model in models)
			{
				var result = await this.salesOrderHeaderManager.Create(model);

				if(!result.Success)
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.NoContent();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] SalesOrderHeaderModel model)
		{
			var result = await this.salesOrderHeaderManager.Update(id, model);

			if(result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.salesOrderHeaderManager.Delete(id);

			if(result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("ByCustomerID/{id}")]
		[ReadOnly]
		[Route("~/api/Customers/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCustomerID(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetWhere(x => x.CustomerID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySalesPersonID/{id}")]
		[ReadOnly]
		[Route("~/api/SalesPersons/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySalesPersonID(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetWhere(x => x.SalesPersonID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[ReadOnly]
		[Route("~/api/SalesTerritories/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetWhere(x => x.TerritoryID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByBillToAddressID/{id}")]
		[ReadOnly]
		[Route("~/api/Addresses/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBillToAddressID(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetWhere(x => x.BillToAddressID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShipToAddressID/{id}")]
		[ReadOnly]
		[Route("~/api/Addresses/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByShipToAddressID(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetWhere(x => x.ShipToAddressID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShipMethodID/{id}")]
		[ReadOnly]
		[Route("~/api/ShipMethods/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByShipMethodID(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetWhere(x => x.ShipMethodID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCreditCardID/{id}")]
		[ReadOnly]
		[Route("~/api/CreditCards/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCreditCardID(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetWhere(x => x.CreditCardID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCurrencyRateID/{id}")]
		[ReadOnly]
		[Route("~/api/CurrencyRates/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCurrencyRateID(int id)
		{
			ApiResponse response = this.salesOrderHeaderManager.GetWhere(x => x.CurrencyRateID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>d61673f4d4b7defb9dc9623c4a0958d1</Hash>
</Codenesium>*/