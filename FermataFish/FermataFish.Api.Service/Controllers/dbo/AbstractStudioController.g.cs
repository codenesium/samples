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
	public abstract class AbstractStudioController: AbstractApiController
	{
		protected IStudioRepository studioRepository;

		protected IStudioModelValidator studioModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractStudioController(
			ILogger<AbstractStudioController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudioRepository studioRepository,
			IStudioModelValidator studioModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.studioRepository = studioRepository;
			this.studioModelValidator = studioModelValidator;
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
		[StudioFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.studioRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[StudioFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.studioRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[StudioFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(StudioModel model)
		{
			this.studioModelValidator.CreateMode();
			var validationResult = this.studioModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.studioRepository.Create(
					model.Name,
					model.Website,
					model.Address1,
					model.Address2,
					model.City,
					model.StateId,
					model.Zip);
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
		[StudioFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<StudioModel> models)
		{
			this.studioModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.studioModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.studioRepository.Create(
					model.Name,
					model.Website,
					model.Address1,
					model.Address2,
					model.City,
					model.StateId,
					model.Zip);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[StudioFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, StudioModel model)
		{
			if (this.studioRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.studioModelValidator.UpdateMode();
			var validationResult = this.studioModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.studioRepository.Update(
					id,
					model.Name,
					model.Website,
					model.Address1,
					model.Address2,
					model.City,
					model.StateId,
					model.Zip);
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
		[StudioFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.studioRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByStateId/{id}")]
		[StudioFilter]
		[ReadOnlyFilter]
		[Route("~/api/States/{id}/Studios")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStateId(int id)
		{
			Response response = this.studioRepository.GetWhere(x => x.StateId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>ec026be0f1fe189e5b9979602d8431b5</Hash>
</Codenesium>*/