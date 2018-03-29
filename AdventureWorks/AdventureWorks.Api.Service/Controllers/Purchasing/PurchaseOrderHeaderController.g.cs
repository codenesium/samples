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
	public abstract class AbstractPurchaseOrderHeadersController: AbstractEntityFrameworkApiController
	{
		protected IPurchaseOrderHeaderRepository _purchaseOrderHeaderRepository;
		protected IPurchaseOrderHeaderModelValidator _purchaseOrderHeaderModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPurchaseOrderHeadersController(
			ILogger<AbstractPurchaseOrderHeadersController> logger,
			ApplicationContext context,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator
			) : base(logger,context)
		{
			this._purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this._purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
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
			Response response = new Response();

			this._purchaseOrderHeaderRepository.GetById(id,response);
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
			Response response = new Response();

			this._purchaseOrderHeaderRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._purchaseOrderHeaderModelValidator.CreateMode();
			var validationResult = this._purchaseOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._purchaseOrderHeaderRepository.Create(model.RevisionNumber,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[PurchaseOrderHeaderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<PurchaseOrderHeaderModel> models)
		{
			this._purchaseOrderHeaderModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._purchaseOrderHeaderModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._purchaseOrderHeaderRepository.Create(model.RevisionNumber,
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
		public virtual IActionResult Update(int PurchaseOrderID,PurchaseOrderHeaderModel model)
		{
			this._purchaseOrderHeaderModelValidator.UpdateMode();
			var validationResult = this._purchaseOrderHeaderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._purchaseOrderHeaderRepository.Update(PurchaseOrderID,  model.RevisionNumber,
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
			this._purchaseOrderHeaderRepository.Delete(id);
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
			var response = new Response();

			this._purchaseOrderHeaderRepository.GetWhere(x => x.EmployeeID == id, response);
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
			var response = new Response();

			this._purchaseOrderHeaderRepository.GetWhere(x => x.VendorID == id, response);
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
			var response = new Response();

			this._purchaseOrderHeaderRepository.GetWhere(x => x.ShipMethodID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>638b20e9cdc9478158b5fd4810c5ed99</Hash>
</Codenesium>*/