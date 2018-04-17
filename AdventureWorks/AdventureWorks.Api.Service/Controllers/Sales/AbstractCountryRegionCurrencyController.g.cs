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

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractCountryRegionCurrencyController(
			ILogger<AbstractCountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.countryRegionCurrencyRepository = countryRegionCurrencyRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(string id)
		{
			ApiResponse response = this.countryRegionCurrencyRepository.GetById(id);
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
			ApiResponse response = this.countryRegionCurrencyRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] CountryRegionCurrencyModel model)
		{
			var id = this.countryRegionCurrencyRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<CountryRegionCurrencyModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.countryRegionCurrencyRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(string id, [FromBody] CountryRegionCurrencyModel model)
		{
			this.countryRegionCurrencyRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(string id)
		{
			this.countryRegionCurrencyRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByCountryRegionCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/CountryRegions/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCountryRegionCode(string id)
		{
			ApiResponse response = this.countryRegionCurrencyRepository.GetWhere(x => x.CountryRegionCode == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCurrencyCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCurrencyCode(string id)
		{
			ApiResponse response = this.countryRegionCurrencyRepository.GetWhere(x => x.CurrencyCode == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>c081aff67ee4f913fc7220f63f176995</Hash>
</Codenesium>*/