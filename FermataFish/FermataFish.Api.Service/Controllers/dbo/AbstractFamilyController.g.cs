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
	public abstract class AbstractFamilyController: AbstractApiController
	{
		protected IFamilyRepository familyRepository;

		protected IFamilyModelValidator familyModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractFamilyController(
			ILogger<AbstractFamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFamilyRepository familyRepository,
			IFamilyModelValidator familyModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.familyRepository = familyRepository;
			this.familyModelValidator = familyModelValidator;
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
		[FamilyFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.familyRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[FamilyFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.familyRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[FamilyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] FamilyModel model)
		{
			this.familyModelValidator.CreateMode();
			var validationResult = this.familyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.familyRepository.Create(
					model.PcFirstName,
					model.PcLastName,
					model.PcPhone,
					model.PcEmail,
					model.Notes,
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
		[FamilyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<FamilyModel> models)
		{
			this.familyModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.familyModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.familyRepository.Create(
					model.PcFirstName,
					model.PcLastName,
					model.PcPhone,
					model.PcEmail,
					model.Notes,
					model.StudioId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[FamilyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] FamilyModel model)
		{
			if (this.familyRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.familyModelValidator.UpdateMode();
			var validationResult = this.familyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.familyRepository.Update(
					id,
					model.PcFirstName,
					model.PcLastName,
					model.PcPhone,
					model.PcEmail,
					model.Notes,
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
		[FamilyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.familyRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ById/{id}")]
		[FamilyFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/Families")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ById(int id)
		{
			Response response = this.familyRepository.GetWhere(x => x.Id == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[FamilyFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/Families")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			Response response = this.familyRepository.GetWhere(x => x.StudioId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>00ea225a437c14a19cfceb09f09558f3</Hash>
</Codenesium>*/