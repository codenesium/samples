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
	public abstract class AbstractPhoneNumberTypesController: AbstractApiController
	{
		protected IPhoneNumberTypeRepository phoneNumberTypeRepository;
		protected IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractPhoneNumberTypesController(
			ILogger<AbstractPhoneNumberTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.phoneNumberTypeRepository = phoneNumberTypeRepository;
			this.phoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
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
		[PhoneNumberTypeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.phoneNumberTypeRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[PhoneNumberTypeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.phoneNumberTypeRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[PhoneNumberTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(PhoneNumberTypeModel model)
		{
			this.phoneNumberTypeModelValidator.CreateMode();
			var validationResult = this.phoneNumberTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.phoneNumberTypeRepository.Create(model.Name,
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
		[PhoneNumberTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<PhoneNumberTypeModel> models)
		{
			this.phoneNumberTypeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.phoneNumberTypeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.phoneNumberTypeRepository.Create(model.Name,
				                                      model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[PhoneNumberTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int PhoneNumberTypeID,PhoneNumberTypeModel model)
		{
			this.phoneNumberTypeModelValidator.UpdateMode();
			var validationResult = this.phoneNumberTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.phoneNumberTypeRepository.Update(PhoneNumberTypeID,  model.Name,
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
		[PhoneNumberTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.phoneNumberTypeRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>5d7aaf1c80b4e70869c1d5be37fe4c77</Hash>
</Codenesium>*/