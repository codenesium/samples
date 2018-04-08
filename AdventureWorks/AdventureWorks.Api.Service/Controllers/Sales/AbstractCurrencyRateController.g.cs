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
	public abstract class AbstractCurrencyRatesController: AbstractApiController
	{
		protected ICurrencyRateRepository currencyRateRepository;
		protected ICurrencyRateModelValidator currencyRateModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCurrencyRatesController(
			ILogger<AbstractCurrencyRatesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateRepository currencyRateRepository,
			ICurrencyRateModelValidator currencyRateModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.currencyRateRepository = currencyRateRepository;
			this.currencyRateModelValidator = currencyRateModelValidator;
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
		[CurrencyRateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.currencyRateRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[CurrencyRateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.currencyRateRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(CurrencyRateModel model)
		{
			this.currencyRateModelValidator.CreateMode();
			var validationResult = this.currencyRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.currencyRateRepository.Create(model.CurrencyRateDate,
				                                            model.FromCurrencyCode,
				                                            model.ToCurrencyCode,
				                                            model.AverageRate,
				                                            model.EndOfDayRate,
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
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<CurrencyRateModel> models)
		{
			this.currencyRateModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.currencyRateModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.currencyRateRepository.Create(model.CurrencyRateDate,
				                                   model.FromCurrencyCode,
				                                   model.ToCurrencyCode,
				                                   model.AverageRate,
				                                   model.EndOfDayRate,
				                                   model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int CurrencyRateID,CurrencyRateModel model)
		{
			this.currencyRateModelValidator.UpdateMode();
			var validationResult = this.currencyRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.currencyRateRepository.Update(CurrencyRateID,  model.CurrencyRateDate,
				                                   model.FromCurrencyCode,
				                                   model.ToCurrencyCode,
				                                   model.AverageRate,
				                                   model.EndOfDayRate,
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
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.currencyRateRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByFromCurrencyCode/{id}")]
		[CurrencyRateFilter]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CurrencyRates")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByFromCurrencyCode(string id)
		{
			var response = new Response();

			this.currencyRateRepository.GetWhere(x => x.FromCurrencyCode == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByToCurrencyCode/{id}")]
		[CurrencyRateFilter]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CurrencyRates")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByToCurrencyCode(string id)
		{
			var response = new Response();

			this.currencyRateRepository.GetWhere(x => x.ToCurrencyCode == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>22b80c0654986cd866676943bc6af132</Hash>
</Codenesium>*/