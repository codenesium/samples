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
	public abstract class AbstractStudentXFamilyController: AbstractApiController
	{
		protected IStudentXFamilyRepository studentXFamilyRepository;

		protected IStudentXFamilyModelValidator studentXFamilyModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractStudentXFamilyController(
			ILogger<AbstractStudentXFamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentXFamilyRepository studentXFamilyRepository,
			IStudentXFamilyModelValidator studentXFamilyModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.studentXFamilyRepository = studentXFamilyRepository;
			this.studentXFamilyModelValidator = studentXFamilyModelValidator;
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
		[StudentXFamilyFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.studentXFamilyRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[StudentXFamilyFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.studentXFamilyRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[StudentXFamilyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] StudentXFamilyModel model)
		{
			this.studentXFamilyModelValidator.CreateMode();
			var validationResult = this.studentXFamilyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.studentXFamilyRepository.Create(
					model.StudentId,
					model.FamilyId);
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
		[StudentXFamilyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<StudentXFamilyModel> models)
		{
			this.studentXFamilyModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.studentXFamilyModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.studentXFamilyRepository.Create(
					model.StudentId,
					model.FamilyId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[StudentXFamilyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] StudentXFamilyModel model)
		{
			if (this.studentXFamilyRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.studentXFamilyModelValidator.UpdateMode();
			var validationResult = this.studentXFamilyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.studentXFamilyRepository.Update(
					id,
					model.StudentId,
					model.FamilyId);
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
		[StudentXFamilyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.studentXFamilyRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByStudentId/{id}")]
		[StudentXFamilyFilter]
		[ReadOnlyFilter]
		[Route("~/api/Students/{id}/StudentXFamilies")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudentId(int id)
		{
			Response response = this.studentXFamilyRepository.GetWhere(x => x.StudentId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByFamilyId/{id}")]
		[StudentXFamilyFilter]
		[ReadOnlyFilter]
		[Route("~/api/Families/{id}/StudentXFamilies")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByFamilyId(int id)
		{
			Response response = this.studentXFamilyRepository.GetWhere(x => x.FamilyId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>b001ba9501a4044dd4153cba7b6aaeed</Hash>
</Codenesium>*/