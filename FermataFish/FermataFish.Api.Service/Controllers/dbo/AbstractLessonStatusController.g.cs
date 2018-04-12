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
	public abstract class AbstractLessonStatusController: AbstractApiController
	{
		protected ILessonStatusRepository lessonStatusRepository;

		protected ILessonStatusModelValidator lessonStatusModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractLessonStatusController(
			ILogger<AbstractLessonStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonStatusRepository lessonStatusRepository,
			ILessonStatusModelValidator lessonStatusModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.lessonStatusRepository = lessonStatusRepository;
			this.lessonStatusModelValidator = lessonStatusModelValidator;
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
		[LessonStatusFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.lessonStatusRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LessonStatusFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.lessonStatusRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LessonStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LessonStatusModel model)
		{
			this.lessonStatusModelValidator.CreateMode();
			var validationResult = this.lessonStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.lessonStatusRepository.Create(
					model.Name,
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
		[LessonStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<LessonStatusModel> models)
		{
			this.lessonStatusModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.lessonStatusModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.lessonStatusRepository.Create(
					model.Name,
					model.StudioId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LessonStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, LessonStatusModel model)
		{
			if (this.lessonStatusRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.lessonStatusModelValidator.UpdateMode();
			var validationResult = this.lessonStatusModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.lessonStatusRepository.Update(
					id,
					model.Name,
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
		[LessonStatusFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.lessonStatusRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ById/{id}")]
		[LessonStatusFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/LessonStatus")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ById(int id)
		{
			Response response = this.lessonStatusRepository.GetWhere(x => x.Id == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[LessonStatusFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/LessonStatus")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			Response response = this.lessonStatusRepository.GetWhere(x => x.StudioId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>9254644a54c20453b7e5bdeb278af011</Hash>
</Codenesium>*/