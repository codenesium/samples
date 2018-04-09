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
	public abstract class AbstractVendorsController: AbstractApiController
	{
		protected IVendorRepository vendorRepository;
		protected IVendorModelValidator vendorModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractVendorsController(
			ILogger<AbstractVendorsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVendorRepository vendorRepository,
			IVendorModelValidator vendorModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.vendorRepository = vendorRepository;
			this.vendorModelValidator = vendorModelValidator;
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
		[VendorFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.vendorRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[VendorFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.vendorRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[VendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(VendorModel model)
		{
			this.vendorModelValidator.CreateMode();
			var validationResult = this.vendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.vendorRepository.Create(model.AccountNumber,
				                                      model.Name,
				                                      model.CreditRating,
				                                      model.PreferredVendorStatus,
				                                      model.ActiveFlag,
				                                      model.PurchasingWebServiceURL,
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
		[VendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<VendorModel> models)
		{
			this.vendorModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.vendorModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.vendorRepository.Create(model.AccountNumber,
				                             model.Name,
				                             model.CreditRating,
				                             model.PreferredVendorStatus,
				                             model.ActiveFlag,
				                             model.PurchasingWebServiceURL,
				                             model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[VendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id,VendorModel model)
		{
			if(this.vendorRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.vendorModelValidator.UpdateMode();
			var validationResult = this.vendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.vendorRepository.Update(id,  model.AccountNumber,
				                             model.Name,
				                             model.CreditRating,
				                             model.PreferredVendorStatus,
				                             model.ActiveFlag,
				                             model.PurchasingWebServiceURL,
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
		[VendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.vendorRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByBusinessEntityID/{id}")]
		[VendorFilter]
		[ReadOnlyFilter]
		[Route("~/api/BusinessEntities/{id}/Vendors")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			Response response = this.vendorRepository.GetWhere(x => x.BusinessEntityID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>3abc986ed61d4475aa96fc9e8351b63f</Hash>
</Codenesium>*/