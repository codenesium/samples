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
	public abstract class AbstractSpaceXSpaceFeatureController: AbstractApiController
	{
		protected ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository;

		protected ISpaceXSpaceFeatureModelValidator spaceXSpaceFeatureModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpaceXSpaceFeatureController(
			ILogger<AbstractSpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
			ISpaceXSpaceFeatureModelValidator spaceXSpaceFeatureModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.spaceXSpaceFeatureRepository = spaceXSpaceFeatureRepository;
			this.spaceXSpaceFeatureModelValidator = spaceXSpaceFeatureModelValidator;
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
		[SpaceXSpaceFeatureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.spaceXSpaceFeatureRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SpaceXSpaceFeatureFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.spaceXSpaceFeatureRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SpaceXSpaceFeatureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SpaceXSpaceFeatureModel model)
		{
			this.spaceXSpaceFeatureModelValidator.CreateMode();
			var validationResult = this.spaceXSpaceFeatureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.spaceXSpaceFeatureRepository.Create(
					model.SpaceId,
					model.SpaceFeatureId);
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
		[SpaceXSpaceFeatureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SpaceXSpaceFeatureModel> models)
		{
			this.spaceXSpaceFeatureModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.spaceXSpaceFeatureModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.spaceXSpaceFeatureRepository.Create(
					model.SpaceId,
					model.SpaceFeatureId);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SpaceXSpaceFeatureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, SpaceXSpaceFeatureModel model)
		{
			if (this.spaceXSpaceFeatureRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.spaceXSpaceFeatureModelValidator.UpdateMode();
			var validationResult = this.spaceXSpaceFeatureModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.spaceXSpaceFeatureRepository.Update(
					id,
					model.SpaceId,
					model.SpaceFeatureId);
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
		[SpaceXSpaceFeatureFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.spaceXSpaceFeatureRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("BySpaceId/{id}")]
		[SpaceXSpaceFeatureFilter]
		[ReadOnlyFilter]
		[Route("~/api/Spaces/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySpaceId(int id)
		{
			Response response = this.spaceXSpaceFeatureRepository.GetWhere(x => x.SpaceId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySpaceFeatureId/{id}")]
		[SpaceXSpaceFeatureFilter]
		[ReadOnlyFilter]
		[Route("~/api/SpaceFeatures/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySpaceFeatureId(int id)
		{
			Response response = this.spaceXSpaceFeatureRepository.GetWhere(x => x.SpaceFeatureId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>715cb2677e112524324dd31c6bce9267</Hash>
</Codenesium>*/