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
	public abstract class AbstractPersonCreditCardsController: AbstractApiController
	{
		protected IPersonCreditCardRepository personCreditCardRepository;
		protected IPersonCreditCardModelValidator personCreditCardModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPersonCreditCardsController(
			ILogger<AbstractPersonCreditCardsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonCreditCardRepository personCreditCardRepository,
			IPersonCreditCardModelValidator personCreditCardModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.personCreditCardRepository = personCreditCardRepository;
			this.personCreditCardModelValidator = personCreditCardModelValidator;
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

			this.personCreditCardRepository.GetById(id,response);
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

			this.personCreditCardRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this.personCreditCardModelValidator.CreateMode();
			var validationResult = this.personCreditCardModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.personCreditCardRepository.Create(model.CreditCardID,
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
		[PersonCreditCardFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<PersonCreditCardModel> models)
		{
			this.personCreditCardModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.personCreditCardModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.personCreditCardRepository.Create(model.CreditCardID,
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
		public virtual IActionResult Update(int BusinessEntityID,PersonCreditCardModel model)
		{
			this.personCreditCardModelValidator.UpdateMode();
			var validationResult = this.personCreditCardModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.personCreditCardRepository.Update(BusinessEntityID,  model.CreditCardID,
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
			this.personCreditCardRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[PersonCreditCardFilter]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/PersonCreditCards")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this.personCreditCardRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByCreditCardID/{id}")]
		[PersonCreditCardFilter]
		[ReadOnlyFilter]
		[Route("~/api/CreditCards/{id}/PersonCreditCards")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCreditCardID(int id)
		{
			var response = new Response();

			this.personCreditCardRepository.GetWhere(x => x.CreditCardID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>112dc38c24a8aee219bb6dda7f3b5b87</Hash>
</Codenesium>*/