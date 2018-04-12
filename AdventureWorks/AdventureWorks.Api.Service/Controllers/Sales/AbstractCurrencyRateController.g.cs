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
	public abstract class AbstractCurrencyRateController: AbstractApiController
	{
		protected ICurrencyRateRepository currencyRateRepository;

		protected ICurrencyRateModelValidator currencyRateModelValidator;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractCurrencyRateController(
			ILogger<AbstractCurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateRepository currencyRateRepository,
			ICurrencyRateModelValidator currencyRateModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.currencyRateRepository = currencyRateRepository;
			this.currencyRateModelValidator = currencyRateModelValidator;
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
		[CurrencyRateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.currencyRateRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[CurrencyRateFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.currencyRateRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] CurrencyRateModel model)
		{
			this.currencyRateModelValidator.CreateMode();
			var validationResult = this.currencyRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.currencyRateRepository.Create(
					model.CurrencyRateDate,
					model.FromCurrencyCode,
					model.ToCurrencyCode,
					model.AverageRate,
					model.EndOfDayRate,
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
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<CurrencyRateModel> models)
		{
			this.currencyRateModelValidator.CreateMode();

			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var validationResult = this.currencyRateModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.currencyRateRepository.Create(
					model.CurrencyRateDate,
					model.FromCurrencyCode,
					model.ToCurrencyCode,
					model.AverageRate,
					model.EndOfDayRate,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] CurrencyRateModel model)
		{
			if (this.currencyRateRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.currencyRateModelValidator.UpdateMode();
			var validationResult = this.currencyRateModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.currencyRateRepository.Update(
					id,
					model.CurrencyRateDate,
					model.FromCurrencyCode,
					model.ToCurrencyCode,
					model.AverageRate,
					model.EndOfDayRate,
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
		[CurrencyRateFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.currencyRateRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByFromCurrencyCode/{id}")]
		[CurrencyRateFilter]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CurrencyRates")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByFromCurrencyCode(string id)
		{
			Response response = this.currencyRateRepository.GetWhere(x => x.FromCurrencyCode == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByToCurrencyCode/{id}")]
		[CurrencyRateFilter]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CurrencyRates")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByToCurrencyCode(string id)
		{
			Response response = this.currencyRateRepository.GetWhere(x => x.ToCurrencyCode == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>29b06104ca07d6c2b6d94e1e1d7895b0</Hash>
</Codenesium>*/