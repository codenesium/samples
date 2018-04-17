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

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractCurrencyRateController(
			ILogger<AbstractCurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateRepository currencyRateRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.currencyRateRepository = currencyRateRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.currencyRateRepository.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.currencyRateRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] CurrencyRateModel model)
		{
			var id = this.currencyRateRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<CurrencyRateModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.currencyRateRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] CurrencyRateModel model)
		{
			this.currencyRateRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.currencyRateRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByFromCurrencyCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CurrencyRates")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByFromCurrencyCode(string id)
		{
			ApiResponse response = this.currencyRateRepository.GetWhere(x => x.FromCurrencyCode == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByToCurrencyCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CurrencyRates")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByToCurrencyCode(string id)
		{
			ApiResponse response = this.currencyRateRepository.GetWhere(x => x.ToCurrencyCode == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>7a81754b5f28c2c587bbee83035ad7c0</Hash>
</Codenesium>*/