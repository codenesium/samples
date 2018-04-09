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
	public abstract class AbstractPurchaseOrderDetailsController: AbstractApiController
	{
		protected IPurchaseOrderDetailRepository purchaseOrderDetailRepository;
		protected IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPurchaseOrderDetailsController(
			ILogger<AbstractPurchaseOrderDetailsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
			this.purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
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
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.purchaseOrderDetailRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.purchaseOrderDetailRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(PurchaseOrderDetailModel model)
		{
			this.purchaseOrderDetailModelValidator.CreateMode();
			var validationResult = this.purchaseOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.purchaseOrderDetailRepository.Create(model.PurchaseOrderDetailID,
				                                                   model.DueDate,
				                                                   model.OrderQty,
				                                                   model.ProductID,
				                                                   model.UnitPrice,
				                                                   model.LineTotal,
				                                                   model.ReceivedQty,
				                                                   model.RejectedQty,
				                                                   model.StockedQty,
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
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<PurchaseOrderDetailModel> models)
		{
			this.purchaseOrderDetailModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.purchaseOrderDetailModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.purchaseOrderDetailRepository.Create(model.PurchaseOrderDetailID,
				                                          model.DueDate,
				                                          model.OrderQty,
				                                          model.ProductID,
				                                          model.UnitPrice,
				                                          model.LineTotal,
				                                          model.ReceivedQty,
				                                          model.RejectedQty,
				                                          model.StockedQty,
				                                          model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,PurchaseOrderDetailModel model)
		{
			if(this.purchaseOrderDetailRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.purchaseOrderDetailModelValidator.UpdateMode();
			var validationResult = this.purchaseOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.purchaseOrderDetailRepository.Update(id,  model.PurchaseOrderDetailID,
				                                          model.DueDate,
				                                          model.OrderQty,
				                                          model.ProductID,
				                                          model.UnitPrice,
				                                          model.LineTotal,
				                                          model.ReceivedQty,
				                                          model.RejectedQty,
				                                          model.StockedQty,
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
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.purchaseOrderDetailRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByPurchaseOrderID/{id}")]
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[Route("~/api/PurchaseOrderHeaders/{id}/PurchaseOrderDetails")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByPurchaseOrderID(int id)
		{
			Response response = this.purchaseOrderDetailRepository.GetWhere(x => x.PurchaseOrderID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/PurchaseOrderDetails")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			Response response = this.purchaseOrderDetailRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>7b9149a123dfd10e7aaf0642f916dbf9</Hash>
</Codenesium>*/