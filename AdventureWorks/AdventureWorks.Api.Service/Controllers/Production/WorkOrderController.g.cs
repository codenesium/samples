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
	public abstract class AbstractWorkOrdersController: AbstractEntityFrameworkApiController
	{
		protected IWorkOrderRepository _workOrderRepository;
		protected IWorkOrderModelValidator _workOrderModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractWorkOrdersController(
			ILogger<AbstractWorkOrdersController> logger,
			ApplicationContext context,
			IWorkOrderRepository workOrderRepository,
			IWorkOrderModelValidator workOrderModelValidator
			) : base(logger,context)
		{
			this._workOrderRepository = workOrderRepository;
			this._workOrderModelValidator = workOrderModelValidator;
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
			Response response = new Response();

			this._workOrderRepository.GetById(id,response);
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
			Response response = new Response();

			this._workOrderRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._workOrderModelValidator.CreateMode();
			var validationResult = this._workOrderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._workOrderRepository.Create(model.ProductID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[WorkOrderFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<WorkOrderModel> models)
		{
			this._workOrderModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._workOrderModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._workOrderRepository.Create(model.ProductID,
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
		public virtual IActionResult Update(int WorkOrderID,WorkOrderModel model)
		{
			this._workOrderModelValidator.UpdateMode();
			var validationResult = this._workOrderModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._workOrderRepository.Update(WorkOrderID,  model.ProductID,
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
			this._workOrderRepository.Delete(id);
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
			var response = new Response();

			this._workOrderRepository.GetWhere(x => x.ProductID == id, response);
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
			var response = new Response();

			this._workOrderRepository.GetWhere(x => x.ScrapReasonID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>75e2413c6d2447f4ea5fd5132d0ccb43</Hash>
</Codenesium>*/