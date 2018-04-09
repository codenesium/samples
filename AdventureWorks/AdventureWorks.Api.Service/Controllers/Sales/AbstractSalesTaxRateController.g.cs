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
	public abstract class AbstractSalesTaxRatesController: AbstractApiController
	{
		protected ISalesTaxRateRepository salesTaxRateRepository;
		protected ISalesTaxRateModelValidator salesTaxRateModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesTaxRatesController(
			ILogger<AbstractSalesTaxRatesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTaxRateRepository salesTaxRateRepository,
			ISalesTaxRateModelValidator salesTaxRateModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.salesTaxRateRepository = salesTaxRateRepository;
			this.salesTaxRateModelValidator = salesTaxRateModelValidator;
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
			Response response = this.salesTaxRateRepository.GetById(id);
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
			Response response = this.salesTaxRateRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
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
			this.salesTaxRateModelValidator.CreateMode();
			var validationResult = this.salesTaxRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.salesTaxRateRepository.Create(model.StateProvinceID,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[SalesTaxRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<SalesTaxRateModel> models)
		{
			this.salesTaxRateModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.salesTaxRateModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.salesTaxRateRepository.Create(model.StateProvinceID,
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
		public virtual IActionResult Update(int id,SalesTaxRateModel model)
		{
			if(this.salesTaxRateRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.salesTaxRateModelValidator.UpdateMode();
			var validationResult = this.salesTaxRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.salesTaxRateRepository.Update(id,  model.StateProvinceID,
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
			this.salesTaxRateRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByStateProvinceID/{id}")]
		[SalesTaxRateFilter]
		[ReadOnlyFilter]
		[Route("~/api/StateProvinces/{id}/SalesTaxRates")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByStateProvinceID(int id)
		{
			Response response = this.salesTaxRateRepository.GetWhere(x => x.StateProvinceID == id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>1456dc8210b603516939c8d8288a5a54</Hash>
</Codenesium>*/