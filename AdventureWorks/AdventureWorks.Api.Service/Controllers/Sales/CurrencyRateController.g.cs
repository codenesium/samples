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
	public abstract class AbstractCurrencyRatesController: AbstractEntityFrameworkApiController
	{
		protected ICurrencyRateRepository _currencyRateRepository;
		protected ICurrencyRateModelValidator _currencyRateModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractCurrencyRatesController(
			ILogger<AbstractCurrencyRatesController> logger,
			ApplicationContext context,
			ICurrencyRateRepository currencyRateRepository,
			ICurrencyRateModelValidator currencyRateModelValidator
			) : base(logger,context)
		{
			this._currencyRateRepository = currencyRateRepository;
			this._currencyRateModelValidator = currencyRateModelValidator;
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

			this._currencyRateRepository.GetById(id,response);
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

			this._currencyRateRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._currencyRateModelValidator.CreateMode();
			var validationResult = this._currencyRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._currencyRateRepository.Create(model.CurrencyRateDate,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<CurrencyRateModel> models)
		{
			this._currencyRateModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._currencyRateModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._currencyRateRepository.Create(model.CurrencyRateDate,
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
		public virtual IActionResult Update(int currencyRateID,CurrencyRateModel model)
		{
			this._currencyRateModelValidator.UpdateMode();
			var validationResult = this._currencyRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._currencyRateRepository.Update(currencyRateID,  model.CurrencyRateDate,
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
			this._currencyRateRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>6174a177e86c07aaba763967cc65de41</Hash>
</Codenesium>*/