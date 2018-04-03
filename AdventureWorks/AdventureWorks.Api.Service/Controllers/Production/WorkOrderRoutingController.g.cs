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
	public abstract class AbstractWorkOrderRoutingsController: AbstractEntityFrameworkApiController
	{
		protected IWorkOrderRoutingRepository _workOrderRoutingRepository;
		protected IWorkOrderRoutingModelValidator _workOrderRoutingModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractWorkOrderRoutingsController(
			ILogger<AbstractWorkOrderRoutingsController> logger,
			ApplicationContext context,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IWorkOrderRoutingModelValidator workOrderRoutingModelValidator
			) : base(logger,context)
		{
			this._workOrderRoutingRepository = workOrderRoutingRepository;
			this._workOrderRoutingModelValidator = workOrderRoutingModelValidator;
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
			Response response = new Response();

			this._workOrderRoutingRepository.GetById(id,response);
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
			Response response = new Response();

			this._workOrderRoutingRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._workOrderRoutingModelValidator.CreateMode();
			var validationResult = this._workOrderRoutingModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._workOrderRoutingRepository.Create(model.ProductID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[WorkOrderRoutingFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<WorkOrderRoutingModel> models)
		{
			this._workOrderRoutingModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._workOrderRoutingModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._workOrderRoutingRepository.Create(model.ProductID,
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
		public virtual IActionResult Update(int workOrderID,WorkOrderRoutingModel model)
		{
			this._workOrderRoutingModelValidator.UpdateMode();
			var validationResult = this._workOrderRoutingModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._workOrderRoutingRepository.Update(workOrderID,  model.ProductID,
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
			this._workOrderRoutingRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>866f7c9e03ba760031cfe6375464e735</Hash>
</Codenesium>*/