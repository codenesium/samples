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
        public abstract class AbstractCurrencyRateController: AbstractApiController
        {
                protected ICurrencyRateService CurrencyRateService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractCurrencyRateController(
                        ServiceSettings settings,
                        ILogger<AbstractCurrencyRateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICurrencyRateService currencyRateService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.CurrencyRateService = currencyRateService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCurrencyRateResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiCurrencyRateResponseModel> response = await this.CurrencyRateService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCurrencyRateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiCurrencyRateResponseModel response = await this.CurrencyRateService.Get(id);

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
                [ProducesResponseType(typeof(ApiCurrencyRateResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiCurrencyRateRequestModel model)
                {
                        CreateResponse<ApiCurrencyRateResponseModel> result = await this.CurrencyRateService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.CurrencyRateID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/CurrencyRates/{result.Record.CurrencyRateID.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiCurrencyRateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCurrencyRateRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiCurrencyRateResponseModel> records = new List<ApiCurrencyRateResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiCurrencyRateResponseModel> result = await this.CurrencyRateService.Create(model);

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
                [ProducesResponseType(typeof(ApiCurrencyRateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCurrencyRateRequestModel model)
                {
                        ActionResponse result = await this.CurrencyRateService.Update(id, model);

                        if (result.Success)
                        {
                                ApiCurrencyRateResponseModel response = await this.CurrencyRateService.Get(id);

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
                public virtual async Task<IActionResult> Delete(int id)
                {
                        ActionResponse result = await this.CurrencyRateService.Delete(id);

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
                [Route("getCurrencyRateDateFromCurrencyCodeToCurrencyCode/{currencyRateDate}/{fromCurrencyCode}/{toCurrencyCode}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCurrencyRateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
                {
                        ApiCurrencyRateResponseModel response = await this.CurrencyRateService.GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(currencyRateDate, fromCurrencyCode, toCurrencyCode);

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
                [Route("{currencyRateID}/SalesOrderHeaders")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCurrencyRateResponseModel>), 200)]
                public async virtual Task<IActionResult> SalesOrderHeaders(int currencyRateID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesOrderHeaderResponseModel> response = await this.CurrencyRateService.SalesOrderHeaders(currencyRateID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>ba3e66ef0d990e9abe28f016d0344ba2</Hash>
</Codenesium>*/