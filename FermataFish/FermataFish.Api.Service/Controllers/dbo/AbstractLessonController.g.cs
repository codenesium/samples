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
	public abstract class AbstractLessonController: AbstractApiController
	{
		protected ILessonRepository lessonRepository;

		protected ILessonModelValidator lessonModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLessonController(
			ILogger<AbstractLessonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonRepository lessonRepository,
			ILessonModelValidator lessonModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.lessonRepository = lessonRepository;
			this.lessonModelValidator = lessonModelValidator;
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
		[LessonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.lessonRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LessonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.lessonRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LessonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LessonModel model)
		{
			this.lessonModelValidator.CreateMode();
			var validationResult = this.lessonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.lessonRepository.Create(
					model.ScheduledStartDate,
					model.ScheduledEndDate,
					model.ActualStartDate,
					model.ActualEndDate,
					model.LessonStatusId,
					model.TeacherNotes,
					model.StudentNotes,
					model.BillAmount,
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
		[LessonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<LessonModel> models)
		{
			this.lessonModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.lessonModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.lessonRepository.Create(
					model.ScheduledStartDate,
					model.ScheduledEndDate,
					model.ActualStartDate,
					model.ActualEndDate,
					model.LessonStatusId,
					model.TeacherNotes,
					model.StudentNotes,
					model.BillAmount,
					model.StudioId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LessonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, LessonModel model)
		{
			if (this.lessonRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.lessonModelValidator.UpdateMode();
			var validationResult = this.lessonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.lessonRepository.Update(
					id,
					model.ScheduledStartDate,
					model.ScheduledEndDate,
					model.ActualStartDate,
					model.ActualEndDate,
					model.LessonStatusId,
					model.TeacherNotes,
					model.StudentNotes,
					model.BillAmount,
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
		[LessonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.lessonRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByLessonStatusId/{id}")]
		[LessonFilter]
		[ReadOnlyFilter]
		[Route("~/api/LessonStatus/{id}/Lessons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByLessonStatusId(int id)
		{
			Response response = this.lessonRepository.GetWhere(x => x.LessonStatusId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[LessonFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/Lessons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			Response response = this.lessonRepository.GetWhere(x => x.StudioId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e65186edc59d657e9401860508666d56</Hash>
</Codenesium>*/