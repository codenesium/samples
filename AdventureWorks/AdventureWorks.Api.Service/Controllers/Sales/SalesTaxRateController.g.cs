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
	public abstract class AbstractSalesTaxRatesController: AbstractEntityFrameworkApiController
	{
		protected ISalesTaxRateRepository _salesTaxRateRepository;
		protected ISalesTaxRateModelValidator _salesTaxRateModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesTaxRatesController(
			ILogger<AbstractSalesTaxRatesController> logger,
			ApplicationContext context,
			ISalesTaxRateRepository salesTaxRateRepository,
			ISalesTaxRateModelValidator salesTaxRateModelValidator
			) : base(logger,context)
		{
			this._salesTaxRateRepository = salesTaxRateRepository;
			this._salesTaxRateModelValidator = salesTaxRateModelValidator;
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
		[SalesTaxRateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._salesTaxRateRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesTaxRateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._salesTaxRateRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesTaxRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesTaxRateModel model)
		{
			this._salesTaxRateModelValidator.CreateMode();
			var validationResult = this._salesTaxRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._salesTaxRateRepository.Create(model.StateProvinceID,
				                                             model.TaxType,
				                                             model.TaxRate,
				                                             model.Name,
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
		[SalesTaxRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SalesTaxRateModel> models)
		{
			this._salesTaxRateModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._salesTaxRateModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._salesTaxRateRepository.Create(model.StateProvinceID,
				                                    model.TaxType,
				                                    model.TaxRate,
				                                    model.Name,
				                                    model.Rowguid,
				                                    model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesTaxRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int salesTaxRateID,SalesTaxRateModel model)
		{
			this._salesTaxRateModelValidator.UpdateMode();
			var validationResult = this._salesTaxRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesTaxRateRepository.Update(salesTaxRateID,  model.StateProvinceID,
				                                    model.TaxType,
				                                    model.TaxRate,
				                                    model.Name,
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
		[SalesTaxRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._salesTaxRateRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>95a2756e6e08e0751940849e9caa199d</Hash>
</Codenesium>*/