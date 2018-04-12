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
	public abstract class AbstractSpaceFeatureController: AbstractApiController
	{
		protected ISpaceFeatureRepository spaceFeatureRepository;

		protected ISpaceFeatureModelValidator spaceFeatureModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpaceFeatureController(
			ILogger<AbstractSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceFeatureRepository spaceFeatureRepository,
			ISpaceFeatureModelValidator spaceFeatureModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.spaceFeatureRepository = spaceFeatureRepository;
			this.spaceFeatureModelValidator = spaceFeatureModelValidator;
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
		[SpaceFeatureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.spaceFeatureRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SpaceFeatureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.spaceFeatureRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SpaceFeatureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SpaceFeatureModel model)
		{
			this.spaceFeatureModelValidator.CreateMode();
			var validationResult = this.spaceFeatureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.spaceFeatureRepository.Create(
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
		[SpaceFeatureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SpaceFeatureModel> models)
		{
			this.spaceFeatureModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.spaceFeatureModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.spaceFeatureRepository.Create(
					model.Name,
					model.StudioId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SpaceFeatureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SpaceFeatureModel model)
		{
			if (this.spaceFeatureRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.spaceFeatureModelValidator.UpdateMode();
			var validationResult = this.spaceFeatureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.spaceFeatureRepository.Update(
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
		[SpaceFeatureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.spaceFeatureRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByStudioId/{id}")]
		[SpaceFeatureFilter]
		[ReadOnlyFilter]
		[Route("~/api/Studios/{id}/SpaceFeatures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStudioId(int id)
		{
			Response response = this.spaceFeatureRepository.GetWhere(x => x.StudioId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>a74c61ab7dcd010713a3fcf1ecf82eb5</Hash>
</Codenesium>*/