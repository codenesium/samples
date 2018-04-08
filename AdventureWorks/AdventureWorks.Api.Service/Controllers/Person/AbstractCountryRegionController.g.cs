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
	public abstract class AbstractCountryRegionsController: AbstractApiController
	{
		protected ICountryRegionRepository countryRegionRepository;
		protected ICountryRegionModelValidator countryRegionModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCountryRegionsController(
			ILogger<AbstractCountryRegionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionRepository countryRegionRepository,
			ICountryRegionModelValidator countryRegionModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.countryRegionRepository = countryRegionRepository;
			this.countryRegionModelValidator = countryRegionModelValidator;
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
		[CountryRegionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(string id)
		{
			Response response = new Response();

			this.countryRegionRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[CountryRegionFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.countryRegionRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[CountryRegionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(CountryRegionModel model)
		{
			this.countryRegionModelValidator.CreateMode();
			var validationResult = this.countryRegionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.countryRegionRepository.Create(model.Name,
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
		[CountryRegionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<CountryRegionModel> models)
		{
			this.countryRegionModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.countryRegionModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.countryRegionRepository.Create(model.Name,
				                                    model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[CountryRegionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(string CountryRegionCode,CountryRegionModel model)
		{
			this.countryRegionModelValidator.UpdateMode();
			var validationResult = this.countryRegionModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.countryRegionRepository.Update(CountryRegionCode,  model.Name,
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
		[CountryRegionFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(string id)
		{
			this.countryRegionRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>4c442d0d9eea5f5447ce093a37d6f8ac</Hash>
</Codenesium>*/