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
	public abstract class AbstractWorkOrderRoutingsController: AbstractApiController
	{
		protected IWorkOrderRoutingRepository workOrderRoutingRepository;
		protected IWorkOrderRoutingModelValidator workOrderRoutingModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractWorkOrderRoutingsController(
			ILogger<AbstractWorkOrderRoutingsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IWorkOrderRoutingModelValidator workOrderRoutingModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
			this.workOrderRoutingModelValidator = workOrderRoutingModelValidator;
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
		[WorkOrderRoutingFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.workOrderRoutingRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[WorkOrderRoutingFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.workOrderRoutingRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[WorkOrderRoutingFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(WorkOrderRoutingModel model)
		{
			this.workOrderRoutingModelValidator.CreateMode();
			var validationResult = this.workOrderRoutingModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.workOrderRoutingRepository.Create(model.ProductID,
				                                                model.OperationSequence,
				                                                model.LocationID,
				                                                model.ScheduledStartDate,
				                                                model.ScheduledEndDate,
				                                                model.ActualStartDate,
				                                                model.ActualEndDate,
				                                                model.ActualResourceHrs,
				                                                model.PlannedCost,
				                                                model.ActualCost,
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
		[WorkOrderRoutingFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<WorkOrderRoutingModel> models)
		{
			this.workOrderRoutingModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.workOrderRoutingModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.workOrderRoutingRepository.Create(model.ProductID,
				                                       model.OperationSequence,
				                                       model.LocationID,
				                                       model.ScheduledStartDate,
				                                       model.ScheduledEndDate,
				                                       model.ActualStartDate,
				                                       model.ActualEndDate,
				                                       model.ActualResourceHrs,
				                                       model.PlannedCost,
				                                       model.ActualCost,
				                                       model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[WorkOrderRoutingFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,WorkOrderRoutingModel model)
		{
			if(this.workOrderRoutingRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.workOrderRoutingModelValidator.UpdateMode();
			var validationResult = this.workOrderRoutingModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.workOrderRoutingRepository.Update(id,  model.ProductID,
				                                       model.OperationSequence,
				                                       model.LocationID,
				                                       model.ScheduledStartDate,
				                                       model.ScheduledEndDate,
				                                       model.ActualStartDate,
				                                       model.ActualEndDate,
				                                       model.ActualResourceHrs,
				                                       model.PlannedCost,
				                                       model.ActualCost,
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
		[WorkOrderRoutingFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.workOrderRoutingRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByWorkOrderID/{id}")]
		[WorkOrderRoutingFilter]
		[ReadOnlyFilter]
		[Route("~/api/WorkOrders/{id}/WorkOrderRoutings")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByWorkOrderID(int id)
		{
			Response response = this.workOrderRoutingRepository.GetWhere(x => x.WorkOrderID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByLocationID/{id}")]
		[WorkOrderRoutingFilter]
		[ReadOnlyFilter]
		[Route("~/api/Locations/{id}/WorkOrderRoutings")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLocationID(short id)
		{
			Response response = this.workOrderRoutingRepository.GetWhere(x => x.LocationID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>f5e5df586421eeec27777be0a43b5610</Hash>
</Codenesium>*/