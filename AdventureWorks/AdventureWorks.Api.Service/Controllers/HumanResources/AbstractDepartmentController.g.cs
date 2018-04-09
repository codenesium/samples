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
	public abstract class AbstractDepartmentsController: AbstractApiController
	{
		protected IDepartmentRepository departmentRepository;
		protected IDepartmentModelValidator departmentModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDepartmentsController(
			ILogger<AbstractDepartmentsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDepartmentRepository departmentRepository,
			IDepartmentModelValidator departmentModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.departmentRepository = departmentRepository;
			this.departmentModelValidator = departmentModelValidator;
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
		[DepartmentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(short id)
		{
			Response response = this.departmentRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[DepartmentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.departmentRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[DepartmentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(DepartmentModel model)
		{
			this.departmentModelValidator.CreateMode();
			var validationResult = this.departmentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.departmentRepository.Create(model.Name,
				                                          model.GroupName,
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
		[DepartmentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<DepartmentModel> models)
		{
			this.departmentModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.departmentModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.departmentRepository.Create(model.Name,
				                                 model.GroupName,
				                                 model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[DepartmentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(short id,DepartmentModel model)
		{
			if(this.departmentRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.departmentModelValidator.UpdateMode();
			var validationResult = this.departmentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.departmentRepository.Update(id,  model.Name,
				                                 model.GroupName,
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
		[DepartmentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(short id)
		{
			this.departmentRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>a8bb8b223e3e7a319e66aed9be7303e4</Hash>
</Codenesium>*/