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
	public abstract class AbstractErrorLogsController: AbstractEntityFrameworkApiController
	{
		protected IErrorLogRepository _errorLogRepository;
		protected IErrorLogModelValidator _errorLogModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractErrorLogsController(
			ILogger<AbstractErrorLogsController> logger,
			ApplicationContext context,
			IErrorLogRepository errorLogRepository,
			IErrorLogModelValidator errorLogModelValidator
			) : base(logger,context)
		{
			this._errorLogRepository = errorLogRepository;
			this._errorLogModelValidator = errorLogModelValidator;
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
		[ErrorLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._errorLogRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ErrorLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._errorLogRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ErrorLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ErrorLogModel model)
		{
			this._errorLogModelValidator.CreateMode();
			var validationResult = this._errorLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._errorLogRepository.Create(model.ErrorTime,
				                                         model.UserName,
				                                         model.ErrorNumber,
				                                         model.ErrorSeverity,
				                                         model.ErrorState,
				                                         model.ErrorProcedure,
				                                         model.ErrorLine,
				                                         model.ErrorMessage);
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
		[ErrorLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ErrorLogModel> models)
		{
			this._errorLogModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._errorLogModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._errorLogRepository.Create(model.ErrorTime,
				                                model.UserName,
				                                model.ErrorNumber,
				                                model.ErrorSeverity,
				                                model.ErrorState,
				                                model.ErrorProcedure,
				                                model.ErrorLine,
				                                model.ErrorMessage);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ErrorLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int errorLogID,ErrorLogModel model)
		{
			this._errorLogModelValidator.UpdateMode();
			var validationResult = this._errorLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._errorLogRepository.Update(errorLogID,  model.ErrorTime,
				                                model.UserName,
				                                model.ErrorNumber,
				                                model.ErrorSeverity,
				                                model.ErrorState,
				                                model.ErrorProcedure,
				                                model.ErrorLine,
				                                model.ErrorMessage);
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
		[ErrorLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._errorLogRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>3a76dfeba7864b24a00cb1c357b0fe83</Hash>
</Codenesium>*/