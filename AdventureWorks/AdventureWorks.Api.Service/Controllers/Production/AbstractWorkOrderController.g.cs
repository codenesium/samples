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
	public abstract class AbstractWorkOrdersController: AbstractApiController
	{
		protected IWorkOrderRepository workOrderRepository;
		protected IWorkOrderModelValidator workOrderModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractWorkOrdersController(
			ILogger<AbstractWorkOrdersController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRepository workOrderRepository,
			IWorkOrderModelValidator workOrderModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.workOrderRepository = workOrderRepository;
			this.workOrderModelValidator = workOrderModelValidator;
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
		[WorkOrderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.workOrderRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[WorkOrderFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.workOrderRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[WorkOrderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(WorkOrderModel model)
		{
			this.workOrderModelValidator.CreateMode();
			var validationResult = this.workOrderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.workOrderRepository.Create(model.ProductID,
				                                         model.OrderQty,
				                                         model.StockedQty,
				                                         model.ScrappedQty,
				                                         model.StartDate,
				                                         model.EndDate,
				                                         model.DueDate,
				                                         model.ScrapReasonID,
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
		[WorkOrderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<WorkOrderModel> models)
		{
			this.workOrderModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.workOrderModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.workOrderRepository.Create(model.ProductID,
				                                model.OrderQty,
				                                model.StockedQty,
				                                model.ScrappedQty,
				                                model.StartDate,
				                                model.EndDate,
				                                model.DueDate,
				                                model.ScrapReasonID,
				                                model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[WorkOrderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,WorkOrderModel model)
		{
			if(this.workOrderRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.workOrderModelValidator.UpdateMode();
			var validationResult = this.workOrderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.workOrderRepository.Update(id,  model.ProductID,
				                                model.OrderQty,
				                                model.StockedQty,
				                                model.ScrappedQty,
				                                model.StartDate,
				                                model.EndDate,
				                                model.DueDate,
				                                model.ScrapReasonID,
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
		[WorkOrderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.workOrderRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[WorkOrderFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/WorkOrders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			Response response = this.workOrderRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByScrapReasonID/{id}")]
		[WorkOrderFilter]
		[ReadOnlyFilter]
		[Route("~/api/ScrapReasons/{id}/WorkOrders")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByScrapReasonID(short id)
		{
			Response response = this.workOrderRepository.GetWhere(x => x.ScrapReasonID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>3ff980f1ad25f30001e4db7c07d3d46a</Hash>
</Codenesium>*/