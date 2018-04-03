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
	public abstract class AbstractDepartmentsController: AbstractEntityFrameworkApiController
	{
		protected IDepartmentRepository _departmentRepository;
		protected IDepartmentModelValidator _departmentModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDepartmentsController(
			ILogger<AbstractDepartmentsController> logger,
			ApplicationContext context,
			IDepartmentRepository departmentRepository,
			IDepartmentModelValidator departmentModelValidator
			) : base(logger,context)
		{
			this._departmentRepository = departmentRepository;
			this._departmentModelValidator = departmentModelValidator;
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
			Response response = new Response();

			this._departmentRepository.GetById(id,response);
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
			Response response = new Response();

			this._departmentRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._departmentModelValidator.CreateMode();
			var validationResult = this._departmentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._departmentRepository.Create(model.Name,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[DepartmentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<DepartmentModel> models)
		{
			this._departmentModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._departmentModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._departmentRepository.Create(model.Name,
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
		public virtual IActionResult Update(short departmentID,DepartmentModel model)
		{
			this._departmentModelValidator.UpdateMode();
			var validationResult = this._departmentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._departmentRepository.Update(departmentID,  model.Name,
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
			this._departmentRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>32b893ba2ee9b9c96bdd884a240f7597</Hash>
</Codenesium>*/