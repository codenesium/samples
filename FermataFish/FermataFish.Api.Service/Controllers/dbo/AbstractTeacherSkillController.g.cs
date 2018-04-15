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
	public abstract class AbstractTeacherSkillController: AbstractApiController
	{
		protected ITeacherSkillRepository teacherSkillRepository;

		protected ITeacherSkillModelValidator teacherSkillModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractTeacherSkillController(
			ILogger<AbstractTeacherSkillController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherSkillRepository teacherSkillRepository,
			ITeacherSkillModelValidator teacherSkillModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.teacherSkillRepository = teacherSkillRepository;
			this.teacherSkillModelValidator = teacherSkillModelValidator;
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
		[TeacherSkillFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.teacherSkillRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[TeacherSkillFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.teacherSkillRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[TeacherSkillFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] TeacherSkillModel model)
		{
			this.teacherSkillModelValidator.CreateMode();
			var validationResult = this.teacherSkillModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.teacherSkillRepository.Create(model);
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
		[TeacherSkillFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<TeacherSkillModel> models)
		{
			this.teacherSkillModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.teacherSkillModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.teacherSkillRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[TeacherSkillFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] TeacherSkillModel model)
		{
			if (this.teacherSkillRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.teacherSkillModelValidator.UpdateMode();
			var validationResult = this.teacherSkillModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.teacherSkillRepository.Update(id, model);
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
		[TeacherSkillFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.teacherSkillRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[TeacherSkillFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/TeacherSkills")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			ApiResponse response = this.teacherSkillRepository.GetWhere(x => x.StudioId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e28f69be0615299ffebfa3f0968f5f1b</Hash>
</Codenesium>*/