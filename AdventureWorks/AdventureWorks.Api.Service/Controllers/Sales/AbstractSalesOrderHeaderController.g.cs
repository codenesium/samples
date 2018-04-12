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

		protected ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSalesOrderHeaderController(
			ILogger<AbstractSalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.salesOrderHeaderRepository = salesOrderHeaderRepository;
			this.salesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.salesOrderHeaderRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SalesOrderHeaderModel model)
		{
			this.salesOrderHeaderModelValidator.CreateMode();
			var validationResult = this.salesOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesOrderHeaderRepository.Create(
					model.RevisionNumber,
					model.OrderDate,
					model.DueDate,
					model.ShipDate,
					model.Status,
					model.OnlineOrderFlag,
					model.SalesOrderNumber,
					model.PurchaseOrderNumber,
					model.AccountNumber,
					model.CustomerID,
					model.SalesPersonID,
					model.TerritoryID,
					model.BillToAddressID,
					model.ShipToAddressID,
					model.ShipMethodID,
					model.CreditCardID,
					model.CreditCardApprovalCode,
					model.CurrencyRateID,
					model.SubTotal,
					model.TaxAmt,
					model.Freight,
					model.TotalDue,
					model.Comment,
					model.Rowguid,
					model.ModifiedDate);
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[SalesOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SalesOrderHeaderModel> models)
		{
			this.salesOrderHeaderModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.salesOrderHeaderModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.salesOrderHeaderRepository.Create(
					model.RevisionNumber,
					model.OrderDate,
					model.DueDate,
					model.ShipDate,
					model.Status,
					model.OnlineOrderFlag,
					model.SalesOrderNumber,
					model.PurchaseOrderNumber,
					model.AccountNumber,
					model.CustomerID,
					model.SalesPersonID,
					model.TerritoryID,
					model.BillToAddressID,
					model.ShipToAddressID,
					model.ShipMethodID,
					model.CreditCardID,
					model.CreditCardApprovalCode,
					model.CurrencyRateID,
					model.SubTotal,
					model.TaxAmt,
					model.Freight,
					model.TotalDue,
					model.Comment,
					model.Rowguid,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SalesOrderHeaderModel model)
		{
			if (this.salesOrderHeaderRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.salesOrderHeaderModelValidator.UpdateMode();
			var validationResult = this.salesOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesOrderHeaderRepository.Update(
					id,
					model.RevisionNumber,
					model.OrderDate,
					model.DueDate,
					model.ShipDate,
					model.Status,
					model.OnlineOrderFlag,
					model.SalesOrderNumber,
					model.PurchaseOrderNumber,
					model.AccountNumber,
					model.CustomerID,
					model.SalesPersonID,
					model.TerritoryID,
					model.BillToAddressID,
					model.ShipToAddressID,
					model.ShipMethodID,
					model.CreditCardID,
					model.CreditCardApprovalCode,
					model.CurrencyRateID,
					model.SubTotal,
					model.TaxAmt,
					model.Freight,
					model.TotalDue,
					model.Comment,
					model.Rowguid,
					model.ModifiedDate);
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesOrderHeaderRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByCustomerID/{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/Customers/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCustomerID(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetWhere(x => x.CustomerID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySalesPersonID/{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesPersons/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesPersonID(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetWhere(x => x.SalesPersonID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetWhere(x => x.TerritoryID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByBillToAddressID/{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/Addresses/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBillToAddressID(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetWhere(x => x.BillToAddressID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShipToAddressID/{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/Addresses/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByShipToAddressID(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetWhere(x => x.ShipToAddressID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShipMethodID/{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/ShipMethods/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByShipMethodID(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetWhere(x => x.ShipMethodID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCreditCardID/{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/CreditCards/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCreditCardID(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetWhere(x => x.CreditCardID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCurrencyRateID/{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/CurrencyRates/{id}/SalesOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCurrencyRateID(int id)
		{
			Response response = this.salesOrderHeaderRepository.GetWhere(x => x.CurrencyRateID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>ceeaea50f0683f683b9cae76b4dcf516</Hash>
</Codenesium>*/