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
	public abstract class AbstractPeopleController: AbstractEntityFrameworkApiController
	{
		protected IPersonRepository _personRepository;
		protected IPersonModelValidator _personModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPeopleController(
			ILogger<AbstractPeopleController> logger,
			ApplicationContext context,
			IPersonRepository personRepository,
			IPersonModelValidator personModelValidator
			) : base(logger,context)
		{
			this._personRepository = personRepository;
			this._personModelValidator = personModelValidator;
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

			this._personRepository.GetById(id,response);
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

			this._personRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._personModelValidator.CreateMode();
			var validationResult = this._personModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._personRepository.Create(model.PersonType,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[PersonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<PersonModel> models)
		{
			this._personModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._personModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._personRepository.Create(model.PersonType,
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
			this._personModelValidator.UpdateMode();
			var validationResult = this._personModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._personRepository.Update(BusinessEntityID,  model.PersonType,
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
			this._personRepository.Delete(id);
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

			this._personRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>91f5040233ff916e2425a4931f251fd3</Hash>
</Codenesium>*/