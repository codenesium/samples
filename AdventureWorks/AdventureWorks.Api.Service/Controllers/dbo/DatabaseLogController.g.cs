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
	public abstract class AbstractDatabaseLogsController: AbstractEntityFrameworkApiController
	{
		protected IDatabaseLogRepository _databaseLogRepository;
		protected IDatabaseLogModelValidator _databaseLogModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractDatabaseLogsController(
			ILogger<AbstractDatabaseLogsController> logger,
			ApplicationContext context,
			IDatabaseLogRepository databaseLogRepository,
			IDatabaseLogModelValidator databaseLogModelValidator
			) : base(logger,context)
		{
			this._databaseLogRepository = databaseLogRepository;
			this._databaseLogModelValidator = databaseLogModelValidator;
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

			this._databaseLogRepository.GetById(id,response);
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

			this._databaseLogRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._databaseLogModelValidator.CreateMode();
			var validationResult = this._databaseLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._databaseLogRepository.Create(model.PostTime,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[DatabaseLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<DatabaseLogModel> models)
		{
			this._databaseLogModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._databaseLogModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._databaseLogRepository.Create(model.PostTime,
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
		public virtual IActionResult Update(int databaseLogID,DatabaseLogModel model)
		{
			this._databaseLogModelValidator.UpdateMode();
			var validationResult = this._databaseLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._databaseLogRepository.Update(databaseLogID,  model.PostTime,
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
			this._databaseLogRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>1f669989483319956dd51eeac01ac992</Hash>
</Codenesium>*/