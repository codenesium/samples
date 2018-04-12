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
	public abstract class AbstractErrorLogController: AbstractApiController
	{
		protected IErrorLogRepository errorLogRepository;

		protected IErrorLogModelValidator errorLogModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractErrorLogController(
			ILogger<AbstractErrorLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IErrorLogRepository errorLogRepository,
			IErrorLogModelValidator errorLogModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.errorLogRepository = errorLogRepository;
			this.errorLogModelValidator = errorLogModelValidator;
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
		[ErrorLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.errorLogRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ErrorLogFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.errorLogRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
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
				var id = this.errorLogRepository.Create(
					model.ErrorTime,
					model.UserName,
					model.ErrorNumber,
					model.ErrorSeverity,
					model.ErrorState,
					model.ErrorProcedure,
					model.ErrorLine,
					model.ErrorMessage);
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
		[ErrorLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ErrorLogModel> models)
		{
			this.errorLogModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.errorLogModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.errorLogRepository.Create(
					model.ErrorTime,
					model.UserName,
					model.ErrorNumber,
					model.ErrorSeverity,
					model.ErrorState,
					model.ErrorProcedure,
					model.ErrorLine,
					model.ErrorMessage);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ErrorLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, ErrorLogModel model)
		{
			if (this.errorLogRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.errorLogModelValidator.UpdateMode();
			var validationResult = this.errorLogModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.errorLogRepository.Update(
					id,
					model.ErrorTime,
					model.UserName,
					model.ErrorNumber,
					model.ErrorSeverity,
					model.ErrorState,
					model.ErrorProcedure,
					model.ErrorLine,
					model.ErrorMessage);
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
		[ErrorLogFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.errorLogRepository.Delete(id);
			return this.Ok();
		}
	}
}

/*<Codenesium>
    <Hash>12df1af80961ec2c0cbe8e4caf57274f</Hash>
</Codenesium>*/