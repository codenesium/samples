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
	public abstract class AbstractCountryRegionCurrenciesController: AbstractApiController
	{
		protected ICountryRegionCurrencyRepository countryRegionCurrencyRepository;
		protected ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCountryRegionCurrenciesController(
			ILogger<AbstractCountryRegionCurrenciesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.countryRegionCurrencyRepository = countryRegionCurrencyRepository;
			this.countryRegionCurrencyModelValidator = countryRegionCurrencyModelValidator;
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
		[CountryRegionCurrencyFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(string id)
		{
			Response response = new Response();

			this.countryRegionCurrencyRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[CountryRegionCurrencyFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.countryRegionCurrencyRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[CountryRegionCurrencyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(CountryRegionCurrencyModel model)
		{
			this.countryRegionCurrencyModelValidator.CreateMode();
			var validationResult = this.countryRegionCurrencyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.countryRegionCurrencyRepository.Create(model.CurrencyCode,
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
		[CountryRegionCurrencyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<CountryRegionCurrencyModel> models)
		{
			this.countryRegionCurrencyModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.countryRegionCurrencyModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.countryRegionCurrencyRepository.Create(model.CurrencyCode,
				                                            model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[CountryRegionCurrencyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(string CountryRegionCode,CountryRegionCurrencyModel model)
		{
			this.countryRegionCurrencyModelValidator.UpdateMode();
			var validationResult = this.countryRegionCurrencyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.countryRegionCurrencyRepository.Update(CountryRegionCode,  model.CurrencyCode,
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
		[CountryRegionCurrencyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(string id)
		{
			this.countryRegionCurrencyRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByCountryRegionCode/{id}")]
		[CountryRegionCurrencyFilter]
		[ReadOnlyFilter]
		[Route("~/api/CountryRegions/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCountryRegionCode(string id)
		{
			var response = new Response();

			this.countryRegionCurrencyRepository.GetWhere(x => x.CountryRegionCode == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByCurrencyCode/{id}")]
		[CountryRegionCurrencyFilter]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCurrencyCode(string id)
		{
			var response = new Response();

			this.countryRegionCurrencyRepository.GetWhere(x => x.CurrencyCode == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>7e86f9aa23b923b5e36232ea806bf8cd</Hash>
</Codenesium>*/