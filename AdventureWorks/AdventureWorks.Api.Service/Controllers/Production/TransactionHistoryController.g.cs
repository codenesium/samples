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
	public abstract class AbstractTransactionHistoriesController: AbstractEntityFrameworkApiController
	{
		protected ITransactionHistoryRepository _transactionHistoryRepository;
		protected ITransactionHistoryModelValidator _transactionHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractTransactionHistoriesController(
			ILogger<AbstractTransactionHistoriesController> logger,
			ApplicationContext context,
			ITransactionHistoryRepository transactionHistoryRepository,
			ITransactionHistoryModelValidator transactionHistoryModelValidator
			) : base(logger,context)
		{
			this._transactionHistoryRepository = transactionHistoryRepository;
			this._transactionHistoryModelValidator = transactionHistoryModelValidator;
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
		[TransactionHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._transactionHistoryRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[TransactionHistoryFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._transactionHistoryRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[TransactionHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(TransactionHistoryModel model)
		{
			this._transactionHistoryModelValidator.CreateMode();
			var validationResult = this._transactionHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._transactionHistoryRepository.Create(model.ProductID,
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
		[TransactionHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<TransactionHistoryModel> models)
		{
			this._transactionHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._transactionHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._transactionHistoryRepository.Create(model.ProductID,
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
		[TransactionHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int transactionID,TransactionHistoryModel model)
		{
			this._transactionHistoryModelValidator.UpdateMode();
			var validationResult = this._transactionHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._transactionHistoryRepository.Update(transactionID,  model.ProductID,
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
		[TransactionHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._transactionHistoryRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>90cedddfdac2513f946e13ebb57aa8d1</Hash>
</Codenesium>*/