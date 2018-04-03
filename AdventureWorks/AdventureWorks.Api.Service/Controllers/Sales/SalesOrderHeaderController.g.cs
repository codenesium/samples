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
	public abstract class AbstractSalesOrderHeadersController: AbstractEntityFrameworkApiController
	{
		protected ISalesOrderHeaderRepository _salesOrderHeaderRepository;
		protected ISalesOrderHeaderModelValidator _salesOrderHeaderModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesOrderHeadersController(
			ILogger<AbstractSalesOrderHeadersController> logger,
			ApplicationContext context,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator
			) : base(logger,context)
		{
			this._salesOrderHeaderRepository = salesOrderHeaderRepository;
			this._salesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._salesOrderHeaderRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesOrderHeaderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._salesOrderHeaderRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesOrderHeaderModel model)
		{
			this._salesOrderHeaderModelValidator.CreateMode();
			var validationResult = this._salesOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._salesOrderHeaderRepository.Create(model.RevisionNumber,
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
				return Ok(id);
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("CreateMany")]
		[ModelValidateFilter]
		[SalesOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SalesOrderHeaderModel> models)
		{
			this._salesOrderHeaderModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._salesOrderHeaderModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._salesOrderHeaderRepository.Create(model.RevisionNumber,
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
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int salesOrderID,SalesOrderHeaderModel model)
		{
			this._salesOrderHeaderModelValidator.UpdateMode();
			var validationResult = this._salesOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesOrderHeaderRepository.Update(salesOrderID,  model.RevisionNumber,
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
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
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
			this._salesOrderHeaderRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>97ea224a6c0998cbb4c0235a6bbc244e</Hash>
</Codenesium>*/