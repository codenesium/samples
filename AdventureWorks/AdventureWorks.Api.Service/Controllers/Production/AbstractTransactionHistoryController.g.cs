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
	public abstract class AbstractTransactionHistoriesController: AbstractApiController
	{
		protected ITransactionHistoryRepository transactionHistoryRepository;
		protected ITransactionHistoryModelValidator transactionHistoryModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractTransactionHistoriesController(
			ILogger<AbstractTransactionHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryRepository transactionHistoryRepository,
			ITransactionHistoryModelValidator transactionHistoryModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.transactionHistoryRepository = transactionHistoryRepository;
			this.transactionHistoryModelValidator = transactionHistoryModelValidator;
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
			Response response = this.transactionHistoryRepository.GetById(id);
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
			Response response = this.transactionHistoryRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.transactionHistoryModelValidator.CreateMode();
			var validationResult = this.transactionHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.transactionHistoryRepository.Create(model.ProductID,
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
		[TransactionHistoryFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<TransactionHistoryModel> models)
		{
			this.transactionHistoryModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.transactionHistoryModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.transactionHistoryRepository.Create(model.ProductID,
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
		public virtual IActionResult Update(int id,TransactionHistoryModel model)
		{
			if(this.transactionHistoryRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.transactionHistoryModelValidator.UpdateMode();
			var validationResult = this.transactionHistoryModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.transactionHistoryRepository.Update(id,  model.ProductID,
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
			this.transactionHistoryRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductID/{id}")]
		[TransactionHistoryFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/TransactionHistories")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductID(int id)
		{
			Response response = this.transactionHistoryRepository.GetWhere(x => x.ProductID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>f2aed867ca450b92815df37268bb1b90</Hash>
</Codenesium>*/