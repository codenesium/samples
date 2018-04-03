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
	public abstract class AbstractBusinessEntityAddressesController: AbstractEntityFrameworkApiController
	{
		protected IBusinessEntityAddressRepository _businessEntityAddressRepository;
		protected IBusinessEntityAddressModelValidator _businessEntityAddressModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractBusinessEntityAddressesController(
			ILogger<AbstractBusinessEntityAddressesController> logger,
			ApplicationContext context,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IBusinessEntityAddressModelValidator businessEntityAddressModelValidator
			) : base(logger,context)
		{
			this._businessEntityAddressRepository = businessEntityAddressRepository;
			this._businessEntityAddressModelValidator = businessEntityAddressModelValidator;
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
		[BusinessEntityAddressFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._businessEntityAddressRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[BusinessEntityAddressFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._businessEntityAddressRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[BusinessEntityAddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(BusinessEntityAddressModel model)
		{
			this._businessEntityAddressModelValidator.CreateMode();
			var validationResult = this._businessEntityAddressModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._businessEntityAddressRepository.Create(model.AddressID,
				                                                      model.AddressTypeID,
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
		[BusinessEntityAddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<BusinessEntityAddressModel> models)
		{
			this._businessEntityAddressModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._businessEntityAddressModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._businessEntityAddressRepository.Create(model.AddressID,
				                                             model.AddressTypeID,
				                                             model.Rowguid,
				                                             model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[BusinessEntityAddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int businessEntityID,BusinessEntityAddressModel model)
		{
			this._businessEntityAddressModelValidator.UpdateMode();
			var validationResult = this._businessEntityAddressModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._businessEntityAddressRepository.Update(businessEntityID,  model.AddressID,
				                                             model.AddressTypeID,
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
		[BusinessEntityAddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._businessEntityAddressRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>499dc6bd1ad5df2d2c64535fa20dbf72</Hash>
</Codenesium>*/