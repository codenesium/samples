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
	public abstract class AbstractAddressTypesController: AbstractApiController
	{
		protected IAddressTypeRepository addressTypeRepository;
		protected IAddressTypeModelValidator addressTypeModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractAddressTypesController(
			ILogger<AbstractAddressTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressTypeRepository addressTypeRepository,
			IAddressTypeModelValidator addressTypeModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.addressTypeRepository = addressTypeRepository;
			this.addressTypeModelValidator = addressTypeModelValidator;
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
		[AddressTypeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.addressTypeRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[AddressTypeFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.addressTypeRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[AddressTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(AddressTypeModel model)
		{
			this.addressTypeModelValidator.CreateMode();
			var validationResult = this.addressTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.addressTypeRepository.Create(model.Name,
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
		[AddressTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<AddressTypeModel> models)
		{
			this.addressTypeModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.addressTypeModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.addressTypeRepository.Create(model.Name,
				                                  model.Rowguid,
				                                  model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[AddressTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int AddressTypeID,AddressTypeModel model)
		{
			this.addressTypeModelValidator.UpdateMode();
			var validationResult = this.addressTypeModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.addressTypeRepository.Update(AddressTypeID,  model.Name,
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
		[AddressTypeFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.addressTypeRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>9ee5cb22d12bedce6b07d0ae284a3d46</Hash>
</Codenesium>*/