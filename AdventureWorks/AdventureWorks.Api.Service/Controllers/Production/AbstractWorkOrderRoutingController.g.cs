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
	public abstract class AbstractWorkOrderRoutingController: AbstractApiController
	{
		protected IWorkOrderRoutingRepository workOrderRoutingRepository;

		protected IWorkOrderRoutingModelValidator workOrderRoutingModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractWorkOrderRoutingController(
			ILogger<AbstractWorkOrderRoutingController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IWorkOrderRoutingModelValidator workOrderRoutingModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
			this.workOrderRoutingModelValidator = workOrderRoutingModelValidator;
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
		[WorkOrderRoutingFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.workOrderRoutingRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[WorkOrderRoutingFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.workOrderRoutingRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
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
				var id = this.workOrderRoutingRepository.Create(
					model.ProductID,
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
		[WorkOrderRoutingFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<WorkOrderRoutingModel> models)
		{
			this.workOrderRoutingModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.workOrderRoutingModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.workOrderRoutingRepository.Create(
					model.ProductID,
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

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[WorkOrderRoutingFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, WorkOrderRoutingModel model)
		{
			if (this.workOrderRoutingRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.workOrderRoutingModelValidator.UpdateMode();
			var validationResult = this.workOrderRoutingModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.workOrderRoutingRepository.Update(
					id,
					model.ProductID,
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
		[WorkOrderRoutingFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.workOrderRoutingRepository.Delete(id);
			return this.Ok();
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
			return this.Ok(response);
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
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>656fbc0b3f9ff3a28748bb0634bf19cf</Hash>
</Codenesium>*/