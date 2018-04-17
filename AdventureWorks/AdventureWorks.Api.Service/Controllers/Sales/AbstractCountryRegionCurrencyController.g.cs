using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractCountryRegionCurrencyController: AbstractApiController
	{
		protected IBOCountryRegionCurrency countryRegionCurrencyManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractCountryRegionCurrencyController(
			ILogger<AbstractCountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCountryRegionCurrency countryRegionCurrencyManager
			)
			: base(logger, transactionCoordinator)
		{
			this.countryRegionCurrencyManager = countryRegionCurrencyManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(string id)
		{
			ApiResponse response = this.countryRegionCurrencyManager.GetById(id);
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
			ApiResponse response = this.countryRegionCurrencyManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<string>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] CountryRegionCurrencyModel model)
		{
			var result = await this.countryRegionCurrencyManager.Create(model);

			if(result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<CountryRegionCurrencyModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.countryRegionCurrencyManager.Create(model);

				if(!result.Success)
				{
					return this.BadRequest(result);
				}
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] CountryRegionCurrencyModel model)
		{
			var result = await this.countryRegionCurrencyManager.Update(id, model);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Delete(string id)
		{
			var result = await this.countryRegionCurrencyManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpGet]
		[Route("ByCountryRegionCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/CountryRegions/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCountryRegionCode(string id)
		{
			ApiResponse response = this.countryRegionCurrencyManager.GetWhere(x => x.CountryRegionCode == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByCurrencyCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Currencies/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCurrencyCode(string id)
		{
			ApiResponse response = this.countryRegionCurrencyManager.GetWhere(x => x.CurrencyCode == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>dd9fc1cf6cfa62511f7f7825d88b2430</Hash>
</Codenesium>*/