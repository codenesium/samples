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
	public abstract class AbstractEmployeePayHistoryController: AbstractApiController
	{
		protected IEmployeePayHistoryRepository employeePayHistoryRepository;

		protected IEmployeePayHistoryModelValidator employeePayHistoryModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractEmployeePayHistoryController(
			ILogger<AbstractEmployeePayHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IEmployeePayHistoryModelValidator employeePayHistoryModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.employeePayHistoryRepository = employeePayHistoryRepository;
			this.employeePayHistoryModelValidator = employeePayHistoryModelValidator;
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
		[EmployeePayHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.employeePayHistoryRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[EmployeePayHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.employeePayHistoryRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[EmployeePayHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(EmployeePayHistoryModel model)
		{
			this.employeePayHistoryModelValidator.CreateMode();
			var validationResult = this.employeePayHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.employeePayHistoryRepository.Create(
					model.RateChangeDate,
					model.Rate,
					model.PayFrequency,
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
		[EmployeePayHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<EmployeePayHistoryModel> models)
		{
			this.employeePayHistoryModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.employeePayHistoryModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.employeePayHistoryRepository.Create(
					model.RateChangeDate,
					model.Rate,
					model.PayFrequency,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[EmployeePayHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, EmployeePayHistoryModel model)
		{
			if (this.employeePayHistoryRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.employeePayHistoryModelValidator.UpdateMode();
			var validationResult = this.employeePayHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.employeePayHistoryRepository.Update(
					id,
					model.RateChangeDate,
					model.Rate,
					model.PayFrequency,
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
		[EmployeePayHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.employeePayHistoryRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[EmployeePayHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Employees/{id}/EmployeePayHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			Response response = this.employeePayHistoryRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>87612129bb6b7215968900691f5938a4</Hash>
</Codenesium>*/