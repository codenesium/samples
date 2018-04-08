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
	public abstract class AbstractDatabaseLogsController: AbstractApiController
	{
		protected IDatabaseLogRepository databaseLogRepository;
		protected IDatabaseLogModelValidator databaseLogModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDatabaseLogsController(
			ILogger<AbstractDatabaseLogsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDatabaseLogRepository databaseLogRepository,
			IDatabaseLogModelValidator databaseLogModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.databaseLogRepository = databaseLogRepository;
			this.databaseLogModelValidator = databaseLogModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[DatabaseLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.databaseLogRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[DatabaseLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.databaseLogRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
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
				var id = this.databaseLogRepository.Create(model.PostTime,
				                                           model.DatabaseUser,
				                                           model.@Event,
				                                           model.Schema,
				                                           model.@Object,
				                                           model.TSQL,
				                                           model.XmlEvent);
				return Ok(id);
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
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
			foreach(var model in models)
			{
				var validationResult = this.databaseLogModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.databaseLogRepository.Create(model.PostTime,
				                                  model.DatabaseUser,
				                                  model.@Event,
				                                  model.Schema,
				                                  model.@Object,
				                                  model.TSQL,
				                                  model.XmlEvent);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[DatabaseLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int DatabaseLogID,DatabaseLogModel model)
		{
			this.databaseLogModelValidator.UpdateMode();
			var validationResult = this.databaseLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.databaseLogRepository.Update(DatabaseLogID,  model.PostTime,
				                                  model.DatabaseUser,
				                                  model.@Event,
				                                  model.Schema,
				                                  model.@Object,
				                                  model.TSQL,
				                                  model.XmlEvent);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
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
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>df6d4dd210dd737995295a8657ce378f</Hash>
</Codenesium>*/