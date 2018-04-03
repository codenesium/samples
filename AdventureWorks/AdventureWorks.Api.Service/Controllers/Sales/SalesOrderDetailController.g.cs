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
	public abstract class AbstractSalesOrderDetailsController: AbstractEntityFrameworkApiController
	{
		protected ISalesOrderDetailRepository _salesOrderDetailRepository;
		protected ISalesOrderDetailModelValidator _salesOrderDetailModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesOrderDetailsController(
			ILogger<AbstractSalesOrderDetailsController> logger,
			ApplicationContext context,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			ISalesOrderDetailModelValidator salesOrderDetailModelValidator
			) : base(logger,context)
		{
			this._salesOrderDetailRepository = salesOrderDetailRepository;
			this._salesOrderDetailModelValidator = salesOrderDetailModelValidator;
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
			Response response = new Response();

			this._salesOrderDetailRepository.GetById(id,response);
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
			Response response = new Response();

			this._salesOrderDetailRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._salesOrderDetailModelValidator.CreateMode();
			var validationResult = this._salesOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._salesOrderDetailRepository.Create(model.SalesOrderDetailID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[SalesOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SalesOrderDetailModel> models)
		{
			this._salesOrderDetailModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._salesOrderDetailModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._salesOrderDetailRepository.Create(model.SalesOrderDetailID,
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
		public virtual IActionResult Update(int salesOrderID,SalesOrderDetailModel model)
		{
			this._salesOrderDetailModelValidator.UpdateMode();
			var validationResult = this._salesOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesOrderDetailRepository.Update(salesOrderID,  model.SalesOrderDetailID,
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
			this._salesOrderDetailRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>d0c2f6679ddf2a26a41e6b4d61dfa034</Hash>
</Codenesium>*/