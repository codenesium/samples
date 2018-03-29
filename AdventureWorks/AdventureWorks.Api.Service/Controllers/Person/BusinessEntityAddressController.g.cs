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
		public virtual IActionResult Update(int BusinessEntityID,BusinessEntityAddressModel model)
		{
			this._businessEntityAddressModelValidator.UpdateMode();
			var validationResult = this._businessEntityAddressModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._businessEntityAddressRepository.Update(BusinessEntityID,  model.AddressID,
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

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[BusinessEntityAddressFilter]
		[ReadOnlyFilter]
		[Route("~/api/BusinessEntities/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			var response = new Response();

			this._businessEntityAddressRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByAddressID/{id}")]
		[BusinessEntityAddressFilter]
		[ReadOnlyFilter]
		[Route("~/api/Addresses/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByAddressID(int id)
		{
			var response = new Response();

			this._businessEntityAddressRepository.GetWhere(x => x.AddressID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByAddressTypeID/{id}")]
		[BusinessEntityAddressFilter]
		[ReadOnlyFilter]
		[Route("~/api/AddressTypes/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByAddressTypeID(int id)
		{
			var response = new Response();

			this._businessEntityAddressRepository.GetWhere(x => x.AddressTypeID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>14e0f531f4f3a64784570de37a183266</Hash>
</Codenesium>*/