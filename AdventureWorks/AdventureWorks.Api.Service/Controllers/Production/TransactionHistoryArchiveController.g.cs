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
	public abstract class AbstractTransactionHistoryArchivesController: AbstractEntityFrameworkApiController
	{
		protected ITransactionHistoryArchiveRepository _transactionHistoryArchiveRepository;
		protected ITransactionHistoryArchiveModelValidator _transactionHistoryArchiveModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractTransactionHistoryArchivesController(
			ILogger<AbstractTransactionHistoryArchivesController> logger,
			ApplicationContext context,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator
			) : base(logger,context)
		{
			this._transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
			this._transactionHistoryArchiveModelValidator = transactionHistoryArchiveModelValidator;
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
			Response response = new Response();

			this._transactionHistoryArchiveRepository.GetById(id,response);
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
			Response response = new Response();

			this._transactionHistoryArchiveRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._transactionHistoryArchiveModelValidator.CreateMode();
			var validationResult = this._transactionHistoryArchiveModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._transactionHistoryArchiveRepository.Create(model.ProductID,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[TransactionHistoryArchiveFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<TransactionHistoryArchiveModel> models)
		{
			this._transactionHistoryArchiveModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._transactionHistoryArchiveModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._transactionHistoryArchiveRepository.Create(model.ProductID,
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
		public virtual IActionResult Update(int transactionID,TransactionHistoryArchiveModel model)
		{
			this._transactionHistoryArchiveModelValidator.UpdateMode();
			var validationResult = this._transactionHistoryArchiveModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._transactionHistoryArchiveRepository.Update(transactionID,  model.ProductID,
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
			this._transactionHistoryArchiveRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>cd0e93db787b3bf99fde65ecca2f7094</Hash>
</Codenesium>*/