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
	public abstract class AbstractPersonPhonesController: AbstractApiController
	{
		protected IPersonPhoneRepository personPhoneRepository;
		protected IPersonPhoneModelValidator personPhoneModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPersonPhonesController(
			ILogger<AbstractPersonPhonesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonPhoneRepository personPhoneRepository,
			IPersonPhoneModelValidator personPhoneModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.personPhoneRepository = personPhoneRepository;
			this.personPhoneModelValidator = personPhoneModelValidator;
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
			Response response = this.personPhoneRepository.GetById(id);
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
			Response response = this.personPhoneRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.personPhoneModelValidator.CreateMode();
			var validationResult = this.personPhoneModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.personPhoneRepository.Create(model.PhoneNumber,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[PersonPhoneFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<PersonPhoneModel> models)
		{
			this.personPhoneModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.personPhoneModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.personPhoneRepository.Create(model.PhoneNumber,
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
		public virtual IActionResult Update(int id,PersonPhoneModel model)
		{
			if(this.personPhoneRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.personPhoneModelValidator.UpdateMode();
			var validationResult = this.personPhoneModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.personPhoneRepository.Update(id,  model.PhoneNumber,
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
			this.personPhoneRepository.Delete(id);
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
			Response response = this.personPhoneRepository.GetWhere(x => x.BusinessEntityID == id);
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
			Response response = this.personPhoneRepository.GetWhere(x => x.PhoneNumberTypeID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>30225b75e6fd4d5ec84ac65305c84c3c</Hash>
</Codenesium>*/