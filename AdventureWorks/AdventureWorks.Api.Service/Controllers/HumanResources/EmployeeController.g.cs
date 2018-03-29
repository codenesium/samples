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
	public abstract class AbstractEmployeesController: AbstractEntityFrameworkApiController
	{
		protected IEmployeeRepository _employeeRepository;
		protected IEmployeeModelValidator _employeeModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractEmployeesController(
			ILogger<AbstractEmployeesController> logger,
			ApplicationContext context,
			IEmployeeRepository employeeRepository,
			IEmployeeModelValidator employeeModelValidator
			) : base(logger,context)
		{
			this._employeeRepository = employeeRepository;
			this._employeeModelValidator = employeeModelValidator;
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
			Response response = new Response();

			this._employeeRepository.GetById(id,response);
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
			Response response = new Response();

			this._employeeRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._employeeModelValidator.CreateMode();
			var validationResult = this._employeeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._employeeRepository.Create(model.NationalIDNumber,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[EmployeeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<EmployeeModel> models)
		{
			this._employeeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._employeeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._employeeRepository.Create(model.NationalIDNumber,
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
		public virtual IActionResult Update(int BusinessEntityID,EmployeeModel model)
		{
			this._employeeModelValidator.UpdateMode();
			var validationResult = this._employeeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._employeeRepository.Update(BusinessEntityID,  model.NationalIDNumber,
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
			this._employeeRepository.Delete(id);
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
			var response = new Response();

			this._employeeRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>29e3eb1db335418b2d06e3b4bd6781cb</Hash>
</Codenesium>*/