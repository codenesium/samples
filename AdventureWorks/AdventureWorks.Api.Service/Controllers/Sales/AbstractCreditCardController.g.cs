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
	public abstract class AbstractCreditCardsController: AbstractApiController
	{
		protected ICreditCardRepository creditCardRepository;
		protected ICreditCardModelValidator creditCardModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCreditCardsController(
			ILogger<AbstractCreditCardsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICreditCardRepository creditCardRepository,
			ICreditCardModelValidator creditCardModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.creditCardRepository = creditCardRepository;
			this.creditCardModelValidator = creditCardModelValidator;
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
		[CreditCardFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.creditCardRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[CreditCardFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.creditCardRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[CreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(CreditCardModel model)
		{
			this.creditCardModelValidator.CreateMode();
			var validationResult = this.creditCardModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.creditCardRepository.Create(model.CardType,
				                                          model.CardNumber,
				                                          model.ExpMonth,
				                                          model.ExpYear,
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
		[CreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<CreditCardModel> models)
		{
			this.creditCardModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.creditCardModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.creditCardRepository.Create(model.CardType,
				                                 model.CardNumber,
				                                 model.ExpMonth,
				                                 model.ExpYear,
				                                 model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[CreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,CreditCardModel model)
		{
			if(this.creditCardRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.creditCardModelValidator.UpdateMode();
			var validationResult = this.creditCardModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.creditCardRepository.Update(id,  model.CardType,
				                                 model.CardNumber,
				                                 model.ExpMonth,
				                                 model.ExpYear,
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
		[CreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.creditCardRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>cf8317fcf892da869affb34b795377fd</Hash>
</Codenesium>*/