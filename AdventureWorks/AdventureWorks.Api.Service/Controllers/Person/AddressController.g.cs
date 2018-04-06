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
	public abstract class AbstractAddressesController: AbstractEntityFrameworkApiController
	{
		protected IAddressRepository _addressRepository;
		protected IAddressModelValidator _addressModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractAddressesController(
			ILogger<AbstractAddressesController> logger,
			ApplicationContext context,
			IAddressRepository addressRepository,
			IAddressModelValidator addressModelValidator
			) : base(logger,context)
		{
			this._addressRepository = addressRepository;
			this._addressModelValidator = addressModelValidator;
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
		[AddressFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._addressRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[AddressFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._addressRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[AddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(AddressModel model)
		{
			this._addressModelValidator.CreateMode();
			var validationResult = this._addressModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._addressRepository.Create(model.AddressLine1,
				                                        model.AddressLine2,
				                                        model.City,
				                                        model.StateProvinceID,
				                                        model.PostalCode,
				                                        model.SpatialLocation,
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
		[AddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<AddressModel> models)
		{
			this._addressModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._addressModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._addressRepository.Create(model.AddressLine1,
				                               model.AddressLine2,
				                               model.City,
				                               model.StateProvinceID,
				                               model.PostalCode,
				                               model.SpatialLocation,
				                               model.Rowguid,
				                               model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[AddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int AddressID,AddressModel model)
		{
			this._addressModelValidator.UpdateMode();
			var validationResult = this._addressModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._addressRepository.Update(AddressID,  model.AddressLine1,
				                               model.AddressLine2,
				                               model.City,
				                               model.StateProvinceID,
				                               model.PostalCode,
				                               model.SpatialLocation,
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
		[AddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._addressRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByStateProvinceID/{id}")]
		[AddressFilter]
		[ReadOnlyFilter]
		[Route("~/api/StateProvinces/{id}/Addresses")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStateProvinceID(int id)
		{
			var response = new Response();

			this._addressRepository.GetWhere(x => x.StateProvinceID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>b29bc65864cc742293c9cad941d79239</Hash>
</Codenesium>*/