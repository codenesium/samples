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
	public abstract class AbstractErrorLogsController: AbstractApiController
	{
		protected IErrorLogRepository errorLogRepository;
		protected IErrorLogModelValidator errorLogModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractErrorLogsController(
			ILogger<AbstractErrorLogsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IErrorLogRepository errorLogRepository,
			IErrorLogModelValidator errorLogModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.errorLogRepository = errorLogRepository;
			this.errorLogModelValidator = errorLogModelValidator;
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

			this.errorLogRepository.GetById(id,response);
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

			this.errorLogRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this.errorLogModelValidator.CreateMode();
			var validationResult = this.errorLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.errorLogRepository.Create(model.ErrorTime,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ErrorLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ErrorLogModel> models)
		{
			this.errorLogModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.errorLogModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.errorLogRepository.Create(model.ErrorTime,
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
		public virtual IActionResult Update(int ErrorLogID,ErrorLogModel model)
		{
			this.errorLogModelValidator.UpdateMode();
			var validationResult = this.errorLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.errorLogRepository.Update(ErrorLogID,  model.ErrorTime,
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
			this.errorLogRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>c08cf9b76a23c46199b0e859e98de4ce</Hash>
</Codenesium>*/