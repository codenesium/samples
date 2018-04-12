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
	public abstract class AbstractPurchaseOrderHeaderController: AbstractApiController
	{
		protected IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;

		protected IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractPurchaseOrderHeaderController(
			ILogger<AbstractPurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
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
		[PurchaseOrderHeaderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.purchaseOrderHeaderRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PurchaseOrderHeaderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.purchaseOrderHeaderRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] PurchaseOrderHeaderModel model)
		{
			this.purchaseOrderHeaderModelValidator.CreateMode();
			var validationResult = this.purchaseOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.purchaseOrderHeaderRepository.Create(
					model.RevisionNumber,
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
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<PurchaseOrderHeaderModel> models)
		{
			this.purchaseOrderHeaderModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.purchaseOrderHeaderModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.purchaseOrderHeaderRepository.Create(
					model.RevisionNumber,
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

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] PurchaseOrderHeaderModel model)
		{
			if (this.purchaseOrderHeaderRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.purchaseOrderHeaderModelValidator.UpdateMode();
			var validationResult = this.purchaseOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.purchaseOrderHeaderRepository.Update(
					id,
					model.RevisionNumber,
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
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.purchaseOrderHeaderRepository.Delete(id);
			return this.Ok();
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
			return this.Ok(response);
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
			return this.Ok(response);
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
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>f38231dfb087e2ed6ffb7329b37f3a2b</Hash>
</Codenesium>*/