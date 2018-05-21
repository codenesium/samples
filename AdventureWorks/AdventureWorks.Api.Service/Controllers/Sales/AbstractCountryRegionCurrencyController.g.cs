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
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOCountryRegionCurrency>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOCountryRegionCurrency> response = await this.countryRegionCurrencyManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOCountryRegionCurrency), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			POCOCountryRegionCurrency response = await this.countryRegionCurrencyManager.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOCountryRegionCurrency), 200)]
		[ProducesResponseType(typeof(CreateResponse<string>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiCountryRegionCurrencyModel model)
		{
			CreateResponse<POCOCountryRegionCurrency> result = await this.countryRegionCurrencyManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.CountryRegionCode.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/CountryRegionCurrencies/{result.Record.CountryRegionCode.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<POCOCountryRegionCurrency>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCountryRegionCurrencyModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOCountryRegionCurrency> records = new List<POCOCountryRegionCurrency>();
			foreach (var model in models)
			{
				CreateResponse<POCOCountryRegionCurrency> result = await this.countryRegionCurrencyManager.Create(model);

				if(result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(records);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOCountryRegionCurrency), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiCountryRegionCurrencyModel model)
		{
			try
			{
				ActionResponse result = await this.countryRegionCurrencyManager.Update(id, model);

				if (result.Success)
				{
					POCOCountryRegionCurrency response = await this.countryRegionCurrencyManager.Get(id);

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
		[Route("getCurrencyCode/{currencyCode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOCountryRegionCurrency>), 200)]
		public async virtual Task<IActionResult> GetCurrencyCode(string currencyCode)
		{
			List<POCOCountryRegionCurrency> response = await this.countryRegionCurrencyManager.GetCurrencyCode(currencyCode);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>011994c345ab244b9ca1cae4e3e29372</Hash>
</Codenesium>*/