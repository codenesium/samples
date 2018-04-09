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
	public abstract class AbstractSalesOrderDetailsController: AbstractApiController
	{
		protected ISalesOrderDetailRepository salesOrderDetailRepository;
		protected ISalesOrderDetailModelValidator salesOrderDetailModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesOrderDetailsController(
			ILogger<AbstractSalesOrderDetailsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			ISalesOrderDetailModelValidator salesOrderDetailModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.salesOrderDetailRepository = salesOrderDetailRepository;
			this.salesOrderDetailModelValidator = salesOrderDetailModelValidator;
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
		[SalesOrderDetailFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.salesOrderDetailRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesOrderDetailFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.salesOrderDetailRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesOrderDetailModel model)
		{
			this.salesOrderDetailModelValidator.CreateMode();
			var validationResult = this.salesOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesOrderDetailRepository.Create(model.SalesOrderDetailID,
				                                                model.CarrierTrackingNumber,
				                                                model.OrderQty,
				                                                model.ProductID,
				                                                model.SpecialOfferID,
				                                                model.UnitPrice,
				                                                model.UnitPriceDiscount,
				                                                model.LineTotal,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[SalesOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SalesOrderDetailModel> models)
		{
			this.salesOrderDetailModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.salesOrderDetailModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.salesOrderDetailRepository.Create(model.SalesOrderDetailID,
				                                       model.CarrierTrackingNumber,
				                                       model.OrderQty,
				                                       model.ProductID,
				                                       model.SpecialOfferID,
				                                       model.UnitPrice,
				                                       model.UnitPriceDiscount,
				                                       model.LineTotal,
				                                       model.Rowguid,
				                                       model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,SalesOrderDetailModel model)
		{
			if(this.salesOrderDetailRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.salesOrderDetailModelValidator.UpdateMode();
			var validationResult = this.salesOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesOrderDetailRepository.Update(id,  model.SalesOrderDetailID,
				                                       model.CarrierTrackingNumber,
				                                       model.OrderQty,
				                                       model.ProductID,
				                                       model.SpecialOfferID,
				                                       model.UnitPrice,
				                                       model.UnitPriceDiscount,
				                                       model.LineTotal,
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
		[SalesOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.salesOrderDetailRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("BySalesOrderID/{id}")]
		[SalesOrderDetailFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesOrderHeaders/{id}/SalesOrderDetails")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesOrderID(int id)
		{
			Response response = this.salesOrderDetailRepository.GetWhere(x => x.SalesOrderID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("BySpecialOfferID/{id}")]
		[SalesOrderDetailFilter]
		[ReadOnlyFilter]
		[Route("~/api/SpecialOfferProducts/{id}/SalesOrderDetails")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySpecialOfferID(int id)
		{
			Response response = this.salesOrderDetailRepository.GetWhere(x => x.SpecialOfferID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>04e10250f90d43ba294f9d30826de21b</Hash>
</Codenesium>*/