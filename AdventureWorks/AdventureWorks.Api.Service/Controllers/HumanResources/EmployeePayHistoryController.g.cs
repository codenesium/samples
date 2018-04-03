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
	public abstract class AbstractEmployeePayHistoriesController: AbstractEntityFrameworkApiController
	{
		protected IEmployeePayHistoryRepository _employeePayHistoryRepository;
		protected IEmployeePayHistoryModelValidator _employeePayHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractEmployeePayHistoriesController(
			ILogger<AbstractEmployeePayHistoriesController> logger,
			ApplicationContext context,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IEmployeePayHistoryModelValidator employeePayHistoryModelValidator
			) : base(logger,context)
		{
			this._employeePayHistoryRepository = employeePayHistoryRepository;
			this._employeePayHistoryModelValidator = employeePayHistoryModelValidator;
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
		[EmployeePayHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._employeePayHistoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[EmployeePayHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._employeePayHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
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
			this._employeePayHistoryModelValidator.CreateMode();
			var validationResult = this._employeePayHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._employeePayHistoryRepository.Create(model.RateChangeDate,
				                                                   model.Rate,
				                                                   model.PayFrequency,
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
		[EmployeePayHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<EmployeePayHistoryModel> models)
		{
			this._employeePayHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._employeePayHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._employeePayHistoryRepository.Create(model.RateChangeDate,
				                                          model.Rate,
				                                          model.PayFrequency,
				                                          model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[EmployeePayHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int businessEntityID,EmployeePayHistoryModel model)
		{
			this._employeePayHistoryModelValidator.UpdateMode();
			var validationResult = this._employeePayHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._employeePayHistoryRepository.Update(businessEntityID,  model.RateChangeDate,
				                                          model.Rate,
				                                          model.PayFrequency,
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
		[EmployeePayHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._employeePayHistoryRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>bf5f6646f39c014d69642f5de04cd19c</Hash>
</Codenesium>*/