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
	public abstract class AbstractDatabaseLogController: AbstractApiController
	{
		protected IDatabaseLogRepository databaseLogRepository;

		protected IDatabaseLogModelValidator databaseLogModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractDatabaseLogController(
			ILogger<AbstractDatabaseLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDatabaseLogRepository databaseLogRepository,
			IDatabaseLogModelValidator databaseLogModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.databaseLogRepository = databaseLogRepository;
			this.databaseLogModelValidator = databaseLogModelValidator;
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
		[DatabaseLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.databaseLogRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[DatabaseLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.databaseLogRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[DatabaseLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(DatabaseLogModel model)
		{
			this.databaseLogModelValidator.CreateMode();
			var validationResult = this.databaseLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.databaseLogRepository.Create(
					model.PostTime,
					model.DatabaseUser,
					model.@Event,
					model.Schema,
					model.@Object,
					model.TSQL,
					model.XmlEvent);
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
		[DatabaseLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<DatabaseLogModel> models)
		{
			this.databaseLogModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.databaseLogModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.databaseLogRepository.Create(
					model.PostTime,
					model.DatabaseUser,
					model.@Event,
					model.Schema,
					model.@Object,
					model.TSQL,
					model.XmlEvent);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[DatabaseLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, DatabaseLogModel model)
		{
			if (this.databaseLogRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.databaseLogModelValidator.UpdateMode();
			var validationResult = this.databaseLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.databaseLogRepository.Update(
					id,
					model.PostTime,
					model.DatabaseUser,
					model.@Event,
					model.Schema,
					model.@Object,
					model.TSQL,
					model.XmlEvent);
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
		[DatabaseLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.databaseLogRepository.Delete(id);
			return this.Ok();
		}
	}
}

/*<Codenesium>
    <Hash>b204e59049545a75589fb28dcffae5a8</Hash>
</Codenesium>*/