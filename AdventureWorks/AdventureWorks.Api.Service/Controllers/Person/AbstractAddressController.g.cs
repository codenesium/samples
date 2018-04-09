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
	public abstract class AbstractAddressesController: AbstractApiController
	{
		protected IAddressRepository addressRepository;
		protected IAddressModelValidator addressModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractAddressesController(
			ILogger<AbstractAddressesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressRepository addressRepository,
			IAddressModelValidator addressModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.addressRepository = addressRepository;
			this.addressModelValidator = addressModelValidator;
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
			Response response = this.addressRepository.GetById(id);
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
			Response response = this.addressRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.addressModelValidator.CreateMode();
			var validationResult = this.addressModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.addressRepository.Create(model.AddressLine1,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[AddressFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<AddressModel> models)
		{
			this.addressModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.addressModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.addressRepository.Create(model.AddressLine1,
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
		public virtual IActionResult Update(int id,AddressModel model)
		{
			if(this.addressRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.addressModelValidator.UpdateMode();
			var validationResult = this.addressModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.addressRepository.Update(id,  model.AddressLine1,
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
			this.addressRepository.Delete(id);
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
			Response response = this.addressRepository.GetWhere(x => x.StateProvinceID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e4a05cf0c9cd34ed5b6dcbca8102132f</Hash>
</Codenesium>*/