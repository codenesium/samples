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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        public abstract class AbstractCountryRegionCurrencyController: AbstractApiController
        {
                protected ICountryRegionCurrencyService CountryRegionCurrencyService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractCountryRegionCurrencyController(
                        ServiceSettings settings,
                        ILogger<AbstractCountryRegionCurrencyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICountryRegionCurrencyService countryRegionCurrencyService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.CountryRegionCurrencyService = countryRegionCurrencyService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCountryRegionCurrencyResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiCountryRegionCurrencyResponseModel> response = await this.CountryRegionCurrencyService.All(query.Offset, query.Limit);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCountryRegionCurrencyResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiCountryRegionCurrencyResponseModel response = await this.CountryRegionCurrencyService.Get(id);

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
                [ProducesResponseType(typeof(ApiCountryRegionCurrencyResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiCountryRegionCurrencyRequestModel model)
                {
                        CreateResponse<ApiCountryRegionCurrencyResponseModel> result = await this.CountryRegionCurrencyService.Create(model);

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
                [ProducesResponseType(typeof(List<ApiCountryRegionCurrencyResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCountryRegionCurrencyRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiCountryRegionCurrencyResponseModel> records = new List<ApiCountryRegionCurrencyResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiCountryRegionCurrencyResponseModel> result = await this.CountryRegionCurrencyService.Create(model);

                                if (result.Success)
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
                [ProducesResponseType(typeof(ApiCountryRegionCurrencyResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiCountryRegionCurrencyRequestModel model)
                {
                        ActionResponse result = await this.CountryRegionCurrencyService.Update(id, model);

                        if (result.Success)
                        {
                                ApiCountryRegionCurrencyResponseModel response = await this.CountryRegionCurrencyService.Get(id);

                                return this.Ok(response);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpDelete]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(void), 204)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.CountryRegionCurrencyService.Delete(id);

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
                [ProducesResponseType(typeof(List<ApiCountryRegionCurrencyResponseModel>), 200)]
                public async virtual Task<IActionResult> GetCurrencyCode(string currencyCode)
                {
                        List<ApiCountryRegionCurrencyResponseModel> response = await this.CountryRegionCurrencyService.GetCurrencyCode(currencyCode);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>8132b1ce0d42d4c219b8d9ed213d36ea</Hash>
</Codenesium>*/