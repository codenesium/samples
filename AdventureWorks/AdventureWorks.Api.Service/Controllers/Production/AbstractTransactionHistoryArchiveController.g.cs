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
	public abstract class AbstractTransactionHistoryArchivesController: AbstractApiController
	{
		protected ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository;
		protected ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractTransactionHistoryArchivesController(
			ILogger<AbstractTransactionHistoryArchivesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this.transactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
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
		[TransactionHistoryArchiveFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.transactionHistoryArchiveRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[TransactionHistoryArchiveFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.transactionHistoryArchiveRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[TransactionHistoryArchiveFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(TransactionHistoryArchiveModel model)
		{
			this.transactionHistoryArchiveModelValidator.CreateMode();
			var validationResult = this.transactionHistoryArchiveModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.transactionHistoryArchiveRepository.Create(model.ProductID,
				                                                         model.ReferenceOrderID,
				                                                         model.ReferenceOrderLineID,
				                                                         model.TransactionDate,
				                                                         model.TransactionType,
				                                                         model.Quantity,
				                                                         model.ActualCost,
				                                                         model.ModifiedDate);
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
		[TransactionHistoryArchiveFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<TransactionHistoryArchiveModel> models)
		{
			this.transactionHistoryArchiveModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.transactionHistoryArchiveModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.transactionHistoryArchiveRepository.Create(model.ProductID,
				                                                model.ReferenceOrderID,
				                                                model.ReferenceOrderLineID,
				                                                model.TransactionDate,
				                                                model.TransactionType,
				                                                model.Quantity,
				                                                model.ActualCost,
				                                                model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[TransactionHistoryArchiveFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,TransactionHistoryArchiveModel model)
		{
			if(this.transactionHistoryArchiveRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.transactionHistoryArchiveModelValidator.UpdateMode();
			var validationResult = this.transactionHistoryArchiveModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.transactionHistoryArchiveRepository.Update(id,  model.ProductID,
				                                                model.ReferenceOrderID,
				                                                model.ReferenceOrderLineID,
				                                                model.TransactionDate,
				                                                model.TransactionType,
				                                                model.Quantity,
				                                                model.ActualCost,
				                                                model.ModifiedDate);
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
		[TransactionHistoryArchiveFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.transactionHistoryArchiveRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>6e122ccbd8476ebc90932461d47c17e4</Hash>
</Codenesium>*/