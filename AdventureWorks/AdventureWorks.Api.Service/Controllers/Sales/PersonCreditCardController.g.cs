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
	public abstract class AbstractPersonCreditCardsController: AbstractEntityFrameworkApiController
	{
		protected IPersonCreditCardRepository _personCreditCardRepository;
		protected IPersonCreditCardModelValidator _personCreditCardModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPersonCreditCardsController(
			ILogger<AbstractPersonCreditCardsController> logger,
			ApplicationContext context,
			IPersonCreditCardRepository personCreditCardRepository,
			IPersonCreditCardModelValidator personCreditCardModelValidator
			) : base(logger,context)
		{
			this._personCreditCardRepository = personCreditCardRepository;
			this._personCreditCardModelValidator = personCreditCardModelValidator;
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
		[PersonCreditCardFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._personCreditCardRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PersonCreditCardFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._personCreditCardRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PersonCreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(PersonCreditCardModel model)
		{
			this._personCreditCardModelValidator.CreateMode();
			var validationResult = this._personCreditCardModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._personCreditCardRepository.Create(model.CreditCardID,
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
		[PersonCreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<PersonCreditCardModel> models)
		{
			this._personCreditCardModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._personCreditCardModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._personCreditCardRepository.Create(model.CreditCardID,
				                                        model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PersonCreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int businessEntityID,PersonCreditCardModel model)
		{
			this._personCreditCardModelValidator.UpdateMode();
			var validationResult = this._personCreditCardModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._personCreditCardRepository.Update(businessEntityID,  model.CreditCardID,
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
		[PersonCreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._personCreditCardRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>404c526a27281703f3b0129d8a0d7039</Hash>
</Codenesium>*/