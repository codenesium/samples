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
	public abstract class AbstractEmployeesController: AbstractApiController
	{
		protected IEmployeeRepository employeeRepository;
		protected IEmployeeModelValidator employeeModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractEmployeesController(
			ILogger<AbstractEmployeesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeRepository employeeRepository,
			IEmployeeModelValidator employeeModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.employeeRepository = employeeRepository;
			this.employeeModelValidator = employeeModelValidator;
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
		[EmployeeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.employeeRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[EmployeeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.employeeRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[EmployeeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(EmployeeModel model)
		{
			this.employeeModelValidator.CreateMode();
			var validationResult = this.employeeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.employeeRepository.Create(model.NationalIDNumber,
				                                        model.LoginID,
				                                        model.OrganizationNode,
				                                        model.OrganizationLevel,
				                                        model.JobTitle,
				                                        model.BirthDate,
				                                        model.MaritalStatus,
				                                        model.Gender,
				                                        model.HireDate,
				                                        model.SalariedFlag,
				                                        model.VacationHours,
				                                        model.SickLeaveHours,
				                                        model.CurrentFlag,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[EmployeeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<EmployeeModel> models)
		{
			this.employeeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.employeeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.employeeRepository.Create(model.NationalIDNumber,
				                               model.LoginID,
				                               model.OrganizationNode,
				                               model.OrganizationLevel,
				                               model.JobTitle,
				                               model.BirthDate,
				                               model.MaritalStatus,
				                               model.Gender,
				                               model.HireDate,
				                               model.SalariedFlag,
				                               model.VacationHours,
				                               model.SickLeaveHours,
				                               model.CurrentFlag,
				                               model.Rowguid,
				                               model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[EmployeeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,EmployeeModel model)
		{
			if(this.employeeRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.employeeModelValidator.UpdateMode();
			var validationResult = this.employeeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.employeeRepository.Update(id,  model.NationalIDNumber,
				                               model.LoginID,
				                               model.OrganizationNode,
				                               model.OrganizationLevel,
				                               model.JobTitle,
				                               model.BirthDate,
				                               model.MaritalStatus,
				                               model.Gender,
				                               model.HireDate,
				                               model.SalariedFlag,
				                               model.VacationHours,
				                               model.SickLeaveHours,
				                               model.CurrentFlag,
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
		[EmployeeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.employeeRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[EmployeeFilter]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/Employees")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			Response response = this.employeeRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e52feca0b6f07563713c32c7717052e2</Hash>
</Codenesium>*/