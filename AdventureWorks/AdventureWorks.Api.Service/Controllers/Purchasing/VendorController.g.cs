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
	public abstract class AbstractVendorsController: AbstractEntityFrameworkApiController
	{
		protected IVendorRepository _vendorRepository;
		protected IVendorModelValidator _vendorModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractVendorsController(
			ILogger<AbstractVendorsController> logger,
			ApplicationContext context,
			IVendorRepository vendorRepository,
			IVendorModelValidator vendorModelValidator
			) : base(logger,context)
		{
			this._vendorRepository = vendorRepository;
			this._vendorModelValidator = vendorModelValidator;
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
			Response response = new Response();

			this._vendorRepository.GetById(id,response);
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
			Response response = new Response();

			this._vendorRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._vendorModelValidator.CreateMode();
			var validationResult = this._vendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._vendorRepository.Create(model.AccountNumber,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[VendorFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<VendorModel> models)
		{
			this._vendorModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._vendorModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._vendorRepository.Create(model.AccountNumber,
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
		public virtual IActionResult Update(int BusinessEntityID,VendorModel model)
		{
			this._vendorModelValidator.UpdateMode();
			var validationResult = this._vendorModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._vendorRepository.Update(BusinessEntityID,  model.AccountNumber,
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
			this._vendorRepository.Delete(id);
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
			var response = new Response();

			this._vendorRepository.GetWhere(x => x.BusinessEntityID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>0f7d01f22b4bc687d0aea4214348a758</Hash>
</Codenesium>*/