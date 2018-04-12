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
	public abstract class AbstractCountryRegionCurrencyController: AbstractApiController
	{
		protected ICountryRegionCurrencyRepository countryRegionCurrencyRepository;

		protected ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractCountryRegionCurrencyController(
			ILogger<AbstractCountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.countryRegionCurrencyRepository = countryRegionCurrencyRepository;
			this.countryRegionCurrencyModelValidator = countryRegionCurrencyModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[CountryRegionCurrencyFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(string id)
		{
			Response response = this.countryRegionCurrencyRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[CountryRegionCurrencyFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.countryRegionCurrencyRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[CountryRegionCurrencyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] CountryRegionCurrencyModel model)
		{
			this.countryRegionCurrencyModelValidator.CreateMode();
			var validationResult = this.countryRegionCurrencyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.countryRegionCurrencyRepository.Create(
					model.CurrencyCode,
					model.ModifiedDate);
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[CountryRegionCurrencyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<CountryRegionCurrencyModel> models)
		{
			this.countryRegionCurrencyModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.countryRegionCurrencyModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.countryRegionCurrencyRepository.Create(
					model.CurrencyCode,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[CountryRegionCurrencyFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(string id, [FromBody] CountryRegionCurrencyModel model)
		{
			if (this.countryRegionCurrencyRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.countryRegionCurrencyModelValidator.UpdateMode();
			var validationResult = this.countryRegionCurrencyModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.countryRegionCurrencyRepository.Update(
					id,
					model.CurrencyCode,
					model.ModifiedDate);
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
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
			return this.Ok();
		}

		[HttpGet]
		[Route("ByCountryRegionCode/{id}")]
		[CountryRegionCurrencyFilter]
		[ReadOnlyFilter]
		[Route("~/api/CountryRegions/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCountryRegionCode(string id)
		{
			Response response = this.countryRegionCurrencyRepository.GetWhere(x => x.CountryRegionCode == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCurrencyCode/{id}")]
		[CountryRegionCurrencyFilter]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByCurrencyCode(string id)
		{
			Response response = this.countryRegionCurrencyRepository.GetWhere(x => x.CurrencyCode == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>1ee2a7088821f6111b727cce62dc8e36</Hash>
</Codenesium>*/