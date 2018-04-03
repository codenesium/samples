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
	public abstract class AbstractEmployeeDepartmentHistoriesController: AbstractEntityFrameworkApiController
	{
		protected IEmployeeDepartmentHistoryRepository _employeeDepartmentHistoryRepository;
		protected IEmployeeDepartmentHistoryModelValidator _employeeDepartmentHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractEmployeeDepartmentHistoriesController(
			ILogger<AbstractEmployeeDepartmentHistoriesController> logger,
			ApplicationContext context,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator
			) : base(logger,context)
		{
			this._employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
			this._employeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
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
		[EmployeeDepartmentHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._employeeDepartmentHistoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[EmployeeDepartmentHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._employeeDepartmentHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[EmployeeDepartmentHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(EmployeeDepartmentHistoryModel model)
		{
			this._employeeDepartmentHistoryModelValidator.CreateMode();
			var validationResult = this._employeeDepartmentHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._employeeDepartmentHistoryRepository.Create(model.DepartmentID,
				                                                          model.ShiftID,
				                                                          model.StartDate,
				                                                          model.EndDate,
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
		[EmployeeDepartmentHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<EmployeeDepartmentHistoryModel> models)
		{
			this._employeeDepartmentHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._employeeDepartmentHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._employeeDepartmentHistoryRepository.Create(model.DepartmentID,
				                                                 model.ShiftID,
				                                                 model.StartDate,
				                                                 model.EndDate,
				                                                 model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[EmployeeDepartmentHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int businessEntityID,EmployeeDepartmentHistoryModel model)
		{
			this._employeeDepartmentHistoryModelValidator.UpdateMode();
			var validationResult = this._employeeDepartmentHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._employeeDepartmentHistoryRepository.Update(businessEntityID,  model.DepartmentID,
				                                                 model.ShiftID,
				                                                 model.StartDate,
				                                                 model.EndDate,
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
		[EmployeeDepartmentHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._employeeDepartmentHistoryRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>592f22a6e6c65e58259c6be803a8cf73</Hash>
</Codenesium>*/