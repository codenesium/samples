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
	public abstract class AbstractCountryRegionCurrenciesController: AbstractEntityFrameworkApiController
	{
		protected ICountryRegionCurrencyRepository _countryRegionCurrencyRepository;
		protected ICountryRegionCurrencyModelValidator _countryRegionCurrencyModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCountryRegionCurrenciesController(
			ILogger<AbstractCountryRegionCurrenciesController> logger,
			ApplicationContext context,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator
			) : base(logger,context)
		{
			this._countryRegionCurrencyRepository = countryRegionCurrencyRepository;
			this._countryRegionCurrencyModelValidator = countryRegionCurrencyModelValidator;
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

			this._countryRegionCurrencyRepository.GetById(id,response);
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

			this._countryRegionCurrencyRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._countryRegionCurrencyModelValidator.CreateMode();
			var validationResult = this._countryRegionCurrencyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._countryRegionCurrencyRepository.Create(model.CurrencyCode,
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
		[CountryRegionCurrencyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<CountryRegionCurrencyModel> models)
		{
			this._countryRegionCurrencyModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._countryRegionCurrencyModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._countryRegionCurrencyRepository.Create(model.CurrencyCode,
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
		public virtual IActionResult Update(string countryRegionCode,CountryRegionCurrencyModel model)
		{
			this._countryRegionCurrencyModelValidator.UpdateMode();
			var validationResult = this._countryRegionCurrencyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._countryRegionCurrencyRepository.Update(countryRegionCode,  model.CurrencyCode,
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
			this._countryRegionCurrencyRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>e277eada074f9f2b17e0f151d30eb4cc</Hash>
</Codenesium>*/