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
	public abstract class AbstractContactTypesController: AbstractApiController
	{
		protected IContactTypeRepository contactTypeRepository;
		protected IContactTypeModelValidator contactTypeModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractContactTypesController(
			ILogger<AbstractContactTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IContactTypeRepository contactTypeRepository,
			IContactTypeModelValidator contactTypeModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.contactTypeRepository = contactTypeRepository;
			this.contactTypeModelValidator = contactTypeModelValidator;
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
		[ContactTypeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.contactTypeRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ContactTypeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.contactTypeRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ContactTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ContactTypeModel model)
		{
			this.contactTypeModelValidator.CreateMode();
			var validationResult = this.contactTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.contactTypeRepository.Create(model.Name,
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
		[ContactTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ContactTypeModel> models)
		{
			this.contactTypeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.contactTypeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.contactTypeRepository.Create(model.Name,
				                                  model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ContactTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ContactTypeID,ContactTypeModel model)
		{
			this.contactTypeModelValidator.UpdateMode();
			var validationResult = this.contactTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.contactTypeRepository.Update(ContactTypeID,  model.Name,
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
		[ContactTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.contactTypeRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>24da2c7f5293cfafe2f713fc05c9b321</Hash>
</Codenesium>*/