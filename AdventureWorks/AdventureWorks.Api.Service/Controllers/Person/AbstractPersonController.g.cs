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
	public abstract class AbstractPeopleController: AbstractApiController
	{
		protected IPersonRepository personRepository;
		protected IPersonModelValidator personModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPeopleController(
			ILogger<AbstractPeopleController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonRepository personRepository,
			IPersonModelValidator personModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.personRepository = personRepository;
			this.personModelValidator = personModelValidator;
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
		[PersonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.personRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PersonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.personRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(PersonModel model)
		{
			this.personModelValidator.CreateMode();
			var validationResult = this.personModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.personRepository.Create(model.PersonType,
				                                      model.NameStyle,
				                                      model.Title,
				                                      model.FirstName,
				                                      model.MiddleName,
				                                      model.LastName,
				                                      model.Suffix,
				                                      model.EmailPromotion,
				                                      model.AdditionalContactInfo,
				                                      model.Demographics,
				                                      model.Rowguid,
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
		[PersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<PersonModel> models)
		{
			this.personModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.personModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.personRepository.Create(model.PersonType,
				                             model.NameStyle,
				                             model.Title,
				                             model.FirstName,
				                             model.MiddleName,
				                             model.LastName,
				                             model.Suffix,
				                             model.EmailPromotion,
				                             model.AdditionalContactInfo,
				                             model.Demographics,
				                             model.Rowguid,
				                             model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int BusinessEntityID,PersonModel model)
		{
			this.personModelValidator.UpdateMode();
			var validationResult = this.personModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.personRepository.Update(BusinessEntityID,  model.PersonType,
				                             model.NameStyle,
				                             model.Title,
				                             model.FirstName,
				                             model.MiddleName,
				                             model.LastName,
				                             model.Suffix,
				                             model.EmailPromotion,
				                             model.AdditionalContactInfo,
				                             model.Demographics,
				                             model.Rowguid,
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
		[PersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.personRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[PersonFilter]
		[ReadOnlyFilter]
		[Route("~/api/BusinessEntities/{id}/People")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this.personRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>09996c8507e57dcdc78fb30f913cbfc3</Hash>
</Codenesium>*/