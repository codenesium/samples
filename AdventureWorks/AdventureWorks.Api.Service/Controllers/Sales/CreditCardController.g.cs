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
	public abstract class AbstractCreditCardsController: AbstractEntityFrameworkApiController
	{
		protected ICreditCardRepository _creditCardRepository;
		protected ICreditCardModelValidator _creditCardModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCreditCardsController(
			ILogger<AbstractCreditCardsController> logger,
			ApplicationContext context,
			ICreditCardRepository creditCardRepository,
			ICreditCardModelValidator creditCardModelValidator
			) : base(logger,context)
		{
			this._creditCardRepository = creditCardRepository;
			this._creditCardModelValidator = creditCardModelValidator;
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
			Response response = new Response();

			this._creditCardRepository.GetById(id,response);
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
			Response response = new Response();

			this._creditCardRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._creditCardModelValidator.CreateMode();
			var validationResult = this._creditCardModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._creditCardRepository.Create(model.CardType,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[CreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<CreditCardModel> models)
		{
			this._creditCardModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._creditCardModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._creditCardRepository.Create(model.CardType,
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
		public virtual IActionResult Update(int CreditCardID,CreditCardModel model)
		{
			this._creditCardModelValidator.UpdateMode();
			var validationResult = this._creditCardModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._creditCardRepository.Update(CreditCardID,  model.CardType,
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
			this._creditCardRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>5ece3749e7703b0b9a22f8e4c14796bc</Hash>
</Codenesium>*/