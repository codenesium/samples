using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
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
			ServiceSettings settings,
			ILogger<AbstractCountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCountryRegionCurrency countryRegionCurrencyManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.countryRegionCurrencyManager = countryRegionCurrencyManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOCountryRegionCurrency), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(string id)
		{
			POCOCountryRegionCurrency response = this.countryRegionCurrencyManager.GetById(id).CountryRegionCurrencies.FirstOrDefault();
			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOCountryRegionCurrency>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.countryRegionCurrencyManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.CountryRegionCurrencies);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOCountryRegionCurrency), 200)]
		[ProducesResponseType(typeof(CreateResponse<string>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] CountryRegionCurrencyModel model)
		{
			CreateResponse<string> result = await this.countryRegionCurrencyManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/countryRegionCurrencies/{result.Id.ToString()}");
				POCOCountryRegionCurrency response = this.countryRegionCurrencyManager.GetById(result.Id).CountryRegionCurrencies.First();
				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<string>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<CountryRegionCurrencyModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<string> ids = new List<string>();
			foreach (var model in models)
			{
				CreateResponse<string> result = await this.countryRegionCurrencyManager.Create(model);

				if(result.Success)
				{
					ids.Add(result.Id);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(ids);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOCountryRegionCurrency), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] CountryRegionCurrencyModel model)
		{
			try
			{
				ActionResponse result = await this.countryRegionCurrencyManager.Update(id, model);

				if (result.Success)
				{
					POCOCountryRegionCurrency response = this.countryRegionCurrencyManager.GetById(id).CountryRegionCurrencies.First();
					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(string id)
		{
			ActionResponse result = await this.countryRegionCurrencyManager.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("ByCountryRegionCode/{id}")]
		[ReadOnly]
		[Route("~/api/CountryRegions/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOCountryRegionCurrency>), 200)]
		public virtual IActionResult ByCountryRegionCode(string id)
		{
			ApiResponse response = this.countryRegionCurrencyManager.GetWhere(x => x.CountryRegionCode == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.CountryRegionCurrencies);
			}
		}

		[HttpGet]
		[Route("ByCurrencyCode/{id}")]
		[ReadOnly]
		[Route("~/api/Currencies/{id}/CountryRegionCurrencies")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOCountryRegionCurrency>), 200)]
		public virtual IActionResult ByCurrencyCode(string id)
		{
			ApiResponse response = this.countryRegionCurrencyManager.GetWhere(x => x.CurrencyCode == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.CountryRegionCurrencies);
			}
		}
	}
}

/*<Codenesium>
    <Hash>9e1136b2759308c94d415c2a0f0cee0d</Hash>
</Codenesium>*/