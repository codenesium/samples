using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public abstract class AbstractTeacherController: AbstractApiController
	{
		protected ITeacherRepository teacherRepository;

		protected ITeacherModelValidator teacherModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractTeacherController(
			ILogger<AbstractTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherRepository teacherRepository,
			ITeacherModelValidator teacherModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.teacherRepository = teacherRepository;
			this.teacherModelValidator = teacherModelValidator;
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
		[TeacherFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.teacherRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[TeacherFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.teacherRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[TeacherFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(TeacherModel model)
		{
			this.teacherModelValidator.CreateMode();
			var validationResult = this.teacherModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.teacherRepository.Create(
					model.FirstName,
					model.LastName,
					model.Email,
					model.Phone,
					model.Birthday,
					model.StudioId);
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
		[TeacherFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<TeacherModel> models)
		{
			this.teacherModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.teacherModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.teacherRepository.Create(
					model.FirstName,
					model.LastName,
					model.Email,
					model.Phone,
					model.Birthday,
					model.StudioId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[TeacherFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, TeacherModel model)
		{
			if (this.teacherRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.teacherModelValidator.UpdateMode();
			var validationResult = this.teacherModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.teacherRepository.Update(
					id,
					model.FirstName,
					model.LastName,
					model.Email,
					model.Phone,
					model.Birthday,
					model.StudioId);
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
		[TeacherFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.teacherRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[TeacherFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/Teachers")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			Response response = this.teacherRepository.GetWhere(x => x.StudioId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>7d3a6283e90405d1dcefd0b06c416ae4</Hash>
</Codenesium>*/