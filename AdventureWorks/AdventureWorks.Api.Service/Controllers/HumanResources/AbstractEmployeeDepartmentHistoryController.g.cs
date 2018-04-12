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
	public abstract class AbstractEmployeeDepartmentHistoryController: AbstractApiController
	{
		protected IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;

		protected IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractEmployeeDepartmentHistoryController(
			ILogger<AbstractEmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
			this.employeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
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
		[EmployeeDepartmentHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.employeeDepartmentHistoryRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[EmployeeDepartmentHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.employeeDepartmentHistoryRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[EmployeeDepartmentHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] EmployeeDepartmentHistoryModel model)
		{
			this.employeeDepartmentHistoryModelValidator.CreateMode();
			var validationResult = this.employeeDepartmentHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.employeeDepartmentHistoryRepository.Create(
					model.DepartmentID,
					model.ShiftID,
					model.StartDate,
					model.EndDate,
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
		[EmployeeDepartmentHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<EmployeeDepartmentHistoryModel> models)
		{
			this.employeeDepartmentHistoryModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.employeeDepartmentHistoryModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.employeeDepartmentHistoryRepository.Create(
					model.DepartmentID,
					model.ShiftID,
					model.StartDate,
					model.EndDate,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[EmployeeDepartmentHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] EmployeeDepartmentHistoryModel model)
		{
			if (this.employeeDepartmentHistoryRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.employeeDepartmentHistoryModelValidator.UpdateMode();
			var validationResult = this.employeeDepartmentHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.employeeDepartmentHistoryRepository.Update(
					id,
					model.DepartmentID,
					model.ShiftID,
					model.StartDate,
					model.EndDate,
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
		[EmployeeDepartmentHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.employeeDepartmentHistoryRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[EmployeeDepartmentHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			Response response = this.employeeDepartmentHistoryRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByDepartmentID/{id}")]
		[EmployeeDepartmentHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Departments/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByDepartmentID(short id)
		{
			Response response = this.employeeDepartmentHistoryRepository.GetWhere(x => x.DepartmentID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByShiftID/{id}")]
		[EmployeeDepartmentHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Shifts/{id}/EmployeeDepartmentHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByShiftID(int id)
		{
			Response response = this.employeeDepartmentHistoryRepository.GetWhere(x => x.ShiftID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>be3c497899c1781ba2ae95205f643881</Hash>
</Codenesium>*/