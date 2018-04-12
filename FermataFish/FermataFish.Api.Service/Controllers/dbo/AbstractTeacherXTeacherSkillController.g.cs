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
	public abstract class AbstractTeacherXTeacherSkillController: AbstractApiController
	{
		protected ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;

		protected ITeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractTeacherXTeacherSkillController(
			ILogger<AbstractTeacherXTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			ITeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
			this.teacherXTeacherSkillModelValidator = teacherXTeacherSkillModelValidator;
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
		[TeacherXTeacherSkillFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.teacherXTeacherSkillRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[TeacherXTeacherSkillFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.teacherXTeacherSkillRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[TeacherXTeacherSkillFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(TeacherXTeacherSkillModel model)
		{
			this.teacherXTeacherSkillModelValidator.CreateMode();
			var validationResult = this.teacherXTeacherSkillModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.teacherXTeacherSkillRepository.Create(
					model.TeacherId,
					model.TeacherSkillId);
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
		[TeacherXTeacherSkillFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<TeacherXTeacherSkillModel> models)
		{
			this.teacherXTeacherSkillModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.teacherXTeacherSkillModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.teacherXTeacherSkillRepository.Create(
					model.TeacherId,
					model.TeacherSkillId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[TeacherXTeacherSkillFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, TeacherXTeacherSkillModel model)
		{
			if (this.teacherXTeacherSkillRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.teacherXTeacherSkillModelValidator.UpdateMode();
			var validationResult = this.teacherXTeacherSkillModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.teacherXTeacherSkillRepository.Update(
					id,
					model.TeacherId,
					model.TeacherSkillId);
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
		[TeacherXTeacherSkillFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.teacherXTeacherSkillRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByTeacherId/{id}")]
		[TeacherXTeacherSkillFilter]
		[ReadOnlyFilter]
		[Route("~/api/Teachers/{id}/TeacherXTeacherSkills")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTeacherId(int id)
		{
			Response response = this.teacherXTeacherSkillRepository.GetWhere(x => x.TeacherId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTeacherSkillId/{id}")]
		[TeacherXTeacherSkillFilter]
		[ReadOnlyFilter]
		[Route("~/api/TeacherSkills/{id}/TeacherXTeacherSkills")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByTeacherSkillId(int id)
		{
			Response response = this.teacherXTeacherSkillRepository.GetWhere(x => x.TeacherSkillId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>0424eae0099924e062dd7f280fe8c042</Hash>
</Codenesium>*/