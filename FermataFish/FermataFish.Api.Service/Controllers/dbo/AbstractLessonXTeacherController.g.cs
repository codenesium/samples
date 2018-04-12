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
	public abstract class AbstractLessonXTeacherController: AbstractApiController
	{
		protected ILessonXTeacherRepository lessonXTeacherRepository;

		protected ILessonXTeacherModelValidator lessonXTeacherModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLessonXTeacherController(
			ILogger<AbstractLessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXTeacherRepository lessonXTeacherRepository,
			ILessonXTeacherModelValidator lessonXTeacherModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.lessonXTeacherRepository = lessonXTeacherRepository;
			this.lessonXTeacherModelValidator = lessonXTeacherModelValidator;
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
		[LessonXTeacherFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.lessonXTeacherRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LessonXTeacherFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.lessonXTeacherRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LessonXTeacherFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LessonXTeacherModel model)
		{
			this.lessonXTeacherModelValidator.CreateMode();
			var validationResult = this.lessonXTeacherModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.lessonXTeacherRepository.Create(
					model.LessonId,
					model.StudentId);
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
		[LessonXTeacherFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<LessonXTeacherModel> models)
		{
			this.lessonXTeacherModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.lessonXTeacherModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.lessonXTeacherRepository.Create(
					model.LessonId,
					model.StudentId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LessonXTeacherFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, LessonXTeacherModel model)
		{
			if (this.lessonXTeacherRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.lessonXTeacherModelValidator.UpdateMode();
			var validationResult = this.lessonXTeacherModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.lessonXTeacherRepository.Update(
					id,
					model.LessonId,
					model.StudentId);
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
		[LessonXTeacherFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.lessonXTeacherRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByLessonId/{id}")]
		[LessonXTeacherFilter]
		[ReadOnlyFilter]
		[Route("~/api/Lessons/{id}/LessonXTeachers")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLessonId(int id)
		{
			Response response = this.lessonXTeacherRepository.GetWhere(x => x.LessonId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudentId/{id}")]
		[LessonXTeacherFilter]
		[ReadOnlyFilter]
		[Route("~/api/Students/{id}/LessonXTeachers")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudentId(int id)
		{
			Response response = this.lessonXTeacherRepository.GetWhere(x => x.StudentId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>869c19ba989409c6c2ff7dbaaa3a289b</Hash>
</Codenesium>*/