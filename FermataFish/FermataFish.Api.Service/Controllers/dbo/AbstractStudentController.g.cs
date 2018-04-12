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
	public abstract class AbstractStudentController: AbstractApiController
	{
		protected IStudentRepository studentRepository;

		protected IStudentModelValidator studentModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractStudentController(
			ILogger<AbstractStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentRepository studentRepository,
			IStudentModelValidator studentModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.studentRepository = studentRepository;
			this.studentModelValidator = studentModelValidator;
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
		[StudentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.studentRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[StudentFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.studentRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[StudentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(StudentModel model)
		{
			this.studentModelValidator.CreateMode();
			var validationResult = this.studentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.studentRepository.Create(
					model.Email,
					model.FirstName,
					model.LastName,
					model.Phone,
					model.IsAdult,
					model.Birthday,
					model.FamilyId,
					model.StudioId,
					model.SmsRemindersEnabled,
					model.EmailRemindersEnabled);
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
		[StudentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<StudentModel> models)
		{
			this.studentModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.studentModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.studentRepository.Create(
					model.Email,
					model.FirstName,
					model.LastName,
					model.Phone,
					model.IsAdult,
					model.Birthday,
					model.FamilyId,
					model.StudioId,
					model.SmsRemindersEnabled,
					model.EmailRemindersEnabled);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[StudentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, StudentModel model)
		{
			if (this.studentRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.studentModelValidator.UpdateMode();
			var validationResult = this.studentModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.studentRepository.Update(
					id,
					model.Email,
					model.FirstName,
					model.LastName,
					model.Phone,
					model.IsAdult,
					model.Birthday,
					model.FamilyId,
					model.StudioId,
					model.SmsRemindersEnabled,
					model.EmailRemindersEnabled);
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
		[StudentFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.studentRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByFamilyId/{id}")]
		[StudentFilter]
		[ReadOnlyFilter]
		[Route("~/api/Families/{id}/Students")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByFamilyId(int id)
		{
			Response response = this.studentRepository.GetWhere(x => x.FamilyId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[StudentFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/Students")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			Response response = this.studentRepository.GetWhere(x => x.StudioId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>c62d87dfbe7b4d8b076fef8aa7be4aa4</Hash>
</Codenesium>*/