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
	public abstract class AbstractPurchaseOrderHeadersController: AbstractApiController
	{
		protected IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;
		protected IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPurchaseOrderHeadersController(
			ILogger<AbstractPurchaseOrderHeadersController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
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
		[PurchaseOrderHeaderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.purchaseOrderHeaderRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PurchaseOrderHeaderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.purchaseOrderHeaderRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(PurchaseOrderHeaderModel model)
		{
			this.purchaseOrderHeaderModelValidator.CreateMode();
			var validationResult = this.purchaseOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.purchaseOrderHeaderRepository.Create(model.RevisionNumber,
				                                                   model.Status,
				                                                   model.EmployeeID,
				                                                   model.VendorID,
				                                                   model.ShipMethodID,
				                                                   model.OrderDate,
				                                                   model.ShipDate,
				                                                   model.SubTotal,
				                                                   model.TaxAmt,
				                                                   model.Freight,
				                                                   model.TotalDue,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<PurchaseOrderHeaderModel> models)
		{
			this.purchaseOrderHeaderModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.purchaseOrderHeaderModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.purchaseOrderHeaderRepository.Create(model.RevisionNumber,
				                                          model.Status,
				                                          model.EmployeeID,
				                                          model.VendorID,
				                                          model.ShipMethodID,
				                                          model.OrderDate,
				                                          model.ShipDate,
				                                          model.SubTotal,
				                                          model.TaxAmt,
				                                          model.Freight,
				                                          model.TotalDue,
				                                          model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,PurchaseOrderHeaderModel model)
		{
			if(this.purchaseOrderHeaderRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.purchaseOrderHeaderModelValidator.UpdateMode();
			var validationResult = this.purchaseOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.purchaseOrderHeaderRepository.Update(id,  model.RevisionNumber,
				                                          model.Status,
				                                          model.EmployeeID,
				                                          model.VendorID,
				                                          model.ShipMethodID,
				                                          model.OrderDate,
				                                          model.ShipDate,
				                                          model.SubTotal,
				                                          model.TaxAmt,
				                                          model.Freight,
				                                          model.TotalDue,
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
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.purchaseOrderHeaderRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByEmployeeID/{id}")]
		[PurchaseOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByEmployeeID(int id)
		{
			Response response = this.purchaseOrderHeaderRepository.GetWhere(x => x.EmployeeID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByVendorID/{id}")]
		[PurchaseOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/Vendors/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByVendorID(int id)
		{
			Response response = this.purchaseOrderHeaderRepository.GetWhere(x => x.VendorID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByShipMethodID/{id}")]
		[PurchaseOrderHeaderFilter]
		[ReadOnlyFilter]
		[Route("~/api/ShipMethods/{id}/PurchaseOrderHeaders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByShipMethodID(int id)
		{
			Response response = this.purchaseOrderHeaderRepository.GetWhere(x => x.ShipMethodID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a4131b877216db2f6ecdb7e1be25c521</Hash>
</Codenesium>*/