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
	public abstract class AbstractPersonPhonesController: AbstractEntityFrameworkApiController
	{
		protected IPersonPhoneRepository _personPhoneRepository;
		protected IPersonPhoneModelValidator _personPhoneModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPersonPhonesController(
			ILogger<AbstractPersonPhonesController> logger,
			ApplicationContext context,
			IPersonPhoneRepository personPhoneRepository,
			IPersonPhoneModelValidator personPhoneModelValidator
			) : base(logger,context)
		{
			this._personPhoneRepository = personPhoneRepository;
			this._personPhoneModelValidator = personPhoneModelValidator;
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
		[PersonPhoneFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._personPhoneRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PersonPhoneFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._personPhoneRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PersonPhoneFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(PersonPhoneModel model)
		{
			this._personPhoneModelValidator.CreateMode();
			var validationResult = this._personPhoneModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._personPhoneRepository.Create(model.PhoneNumber,
				                                            model.PhoneNumberTypeID,
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
		[PersonPhoneFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<PersonPhoneModel> models)
		{
			this._personPhoneModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._personPhoneModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._personPhoneRepository.Create(model.PhoneNumber,
				                                   model.PhoneNumberTypeID,
				                                   model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PersonPhoneFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int BusinessEntityID,PersonPhoneModel model)
		{
			this._personPhoneModelValidator.UpdateMode();
			var validationResult = this._personPhoneModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._personPhoneRepository.Update(BusinessEntityID,  model.PhoneNumber,
				                                   model.PhoneNumberTypeID,
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
		[PersonPhoneFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._personPhoneRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[PersonPhoneFilter]
		[ReadOnlyFilter]
		[Route("~/api/People/{id}/PersonPhones")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this._personPhoneRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByPhoneNumberTypeID/{id}")]
		[PersonPhoneFilter]
		[ReadOnlyFilter]
		[Route("~/api/PhoneNumberTypes/{id}/PersonPhones")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByPhoneNumberTypeID(int id)
		{
			var response = new Response();

			this._personPhoneRepository.GetWhere(x => x.PhoneNumberTypeID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>3245a5cc64eb6dddee702273ec8ad8cb</Hash>
</Codenesium>*/