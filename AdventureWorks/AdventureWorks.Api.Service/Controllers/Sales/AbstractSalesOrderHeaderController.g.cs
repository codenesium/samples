using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractSalesOrderHeaderController: AbstractApiController
	{
		protected ISalesOrderHeaderRepository salesOrderHeaderRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesOrderHeaderController(
			ILogger<AbstractSalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderRepository salesOrderHeaderRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.salesOrderHeaderRepository = salesOrderHeaderRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetById(id);
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
			ApiResponse response = this.salesOrderHeaderRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SalesOrderHeaderModel model)
		{
			var id = this.salesOrderHeaderRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SalesOrderHeaderModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.salesOrderHeaderRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SalesOrderHeaderModel model)
		{
			this.salesOrderHeaderRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesOrderHeaderRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByCustomerID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Customers/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCustomerID(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetWhere(x => x.CustomerID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySalesPersonID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SalesPersons/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySalesPersonID(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetWhere(x => x.SalesPersonID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetWhere(x => x.TerritoryID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByBillToAddressID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Addresses/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBillToAddressID(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetWhere(x => x.BillToAddressID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShipToAddressID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Addresses/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByShipToAddressID(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetWhere(x => x.ShipToAddressID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShipMethodID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/ShipMethods/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByShipMethodID(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetWhere(x => x.ShipMethodID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCreditCardID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/CreditCards/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCreditCardID(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetWhere(x => x.CreditCardID == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCurrencyRateID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/CurrencyRates/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCurrencyRateID(int id)
		{
			ApiResponse response = this.salesOrderHeaderRepository.GetWhere(x => x.CurrencyRateID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>9854e436ef47c5acf98253572d4aff87</Hash>
</Codenesium>*/