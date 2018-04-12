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
	public abstract class AbstractPurchaseOrderDetailController: AbstractApiController
	{
		protected IPurchaseOrderDetailRepository purchaseOrderDetailRepository;

		protected IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractPurchaseOrderDetailController(
			ILogger<AbstractPurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
			this.purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
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
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.purchaseOrderDetailRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PurchaseOrderDetailFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.purchaseOrderDetailRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
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
				var id = this.purchaseOrderDetailRepository.Create(
					model.PurchaseOrderDetailID,
					model.DueDate,
					model.OrderQty,
					model.ProductID,
					model.UnitPrice,
					model.LineTotal,
					model.ReceivedQty,
					model.RejectedQty,
					model.StockedQty,
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
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<PurchaseOrderDetailModel> models)
		{
			this.purchaseOrderDetailModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.purchaseOrderDetailModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.purchaseOrderDetailRepository.Create(
					model.PurchaseOrderDetailID,
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

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, PurchaseOrderDetailModel model)
		{
			if (this.purchaseOrderDetailRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.purchaseOrderDetailModelValidator.UpdateMode();
			var validationResult = this.purchaseOrderDetailModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.purchaseOrderDetailRepository.Update(
					id,
					model.PurchaseOrderDetailID,
					model.DueDate,
					model.OrderQty,
					model.ProductID,
					model.UnitPrice,
					model.LineTotal,
					model.ReceivedQty,
					model.RejectedQty,
					model.StockedQty,
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
		[PurchaseOrderDetailFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.purchaseOrderDetailRepository.Delete(id);
			return this.Ok();
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
			return this.Ok(response);
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
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>0cf316108463c206ab466f23924934cc</Hash>
</Codenesium>*/