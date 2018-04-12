using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractAWBuildVersionController: AbstractApiController
	{
		protected IAWBuildVersionRepository aWBuildVersionRepository;

		protected IAWBuildVersionModelValidator aWBuildVersionModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractAWBuildVersionController(
			ILogger<AbstractAWBuildVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IAWBuildVersionModelValidator aWBuildVersionModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.aWBuildVersionRepository = aWBuildVersionRepository;
			this.aWBuildVersionModelValidator = aWBuildVersionModelValidator;
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
		[AWBuildVersionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.aWBuildVersionRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[AWBuildVersionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.aWBuildVersionRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] AWBuildVersionModel model)
		{
			this.aWBuildVersionModelValidator.CreateMode();
			var validationResult = this.aWBuildVersionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.aWBuildVersionRepository.Create(
					model.Database_Version,
					model.VersionDate,
					model.ModifiedDate);
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
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<AWBuildVersionModel> models)
		{
			this.aWBuildVersionModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.aWBuildVersionModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.aWBuildVersionRepository.Create(
					model.Database_Version,
					model.VersionDate,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] AWBuildVersionModel model)
		{
			if (this.aWBuildVersionRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.aWBuildVersionModelValidator.UpdateMode();
			var validationResult = this.aWBuildVersionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.aWBuildVersionRepository.Update(
					id,
					model.Database_Version,
					model.VersionDate,
					model.ModifiedDate);
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
		[AWBuildVersionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.aWBuildVersionRepository.Delete(id);
			return this.Ok();
		}
	}
}

/*<Codenesium>
    <Hash>6f27652c47543f74cfe98c005f1e014e</Hash>
</Codenesium>*/