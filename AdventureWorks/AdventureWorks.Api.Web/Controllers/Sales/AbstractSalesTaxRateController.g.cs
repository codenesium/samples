using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
        public abstract class AbstractSalesTaxRateController : AbstractApiController
        {
                protected ISalesTaxRateService SalesTaxRateService { get; private set; }

                protected IApiSalesTaxRateModelMapper SalesTaxRateModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSalesTaxRateController(
                        ApiSettings settings,
                        ILogger<AbstractSalesTaxRateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesTaxRateService salesTaxRateService,
                        IApiSalesTaxRateModelMapper salesTaxRateModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SalesTaxRateService = salesTaxRateService;
                        this.SalesTaxRateModelMapper = salesTaxRateModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesTaxRateResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesTaxRateResponseModel> response = await this.SalesTaxRateService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesTaxRateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSalesTaxRateResponseModel response = await this.SalesTaxRateService.Get(id);

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
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiSalesTaxRateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesTaxRateRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSalesTaxRateResponseModel> records = new List<ApiSalesTaxRateResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSalesTaxRateResponseModel> result = await this.SalesTaxRateService.Create(model);

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

                [HttpPost]
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(CreateResponse<ApiSalesTaxRateResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSalesTaxRateRequestModel model)
                {
                        CreateResponse<ApiSalesTaxRateResponseModel> result = await this.SalesTaxRateService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesTaxRates/{result.Record.SalesTaxRateID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiSalesTaxRateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesTaxRateRequestModel> patch)
                {
                        ApiSalesTaxRateResponseModel record = await this.SalesTaxRateService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiSalesTaxRateRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiSalesTaxRateResponseModel> result = await this.SalesTaxRateService.Update(id, model);

                                if (result.Success)
                                {
                                        return this.Ok(result);
                                }
                                else
                                {
                                        return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                                }
                        }
                }

                [HttpPut]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiSalesTaxRateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesTaxRateRequestModel model)
                {
                        ApiSalesTaxRateRequestModel request = await this.PatchModel(id, this.SalesTaxRateModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiSalesTaxRateResponseModel> result = await this.SalesTaxRateService.Update(id, request);

                                if (result.Success)
                                {
                                        return this.Ok(result);
                                }
                                else
                                {
                                        return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                                }
                        }
                }

                [HttpDelete]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(void), 204)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Delete(int id)
                {
                        ActionResponse result = await this.SalesTaxRateService.Delete(id);

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
                [Route("byStateProvinceIDTaxType/{stateProvinceID}/{taxType}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesTaxRateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByStateProvinceIDTaxType(int stateProvinceID, int taxType)
                {
                        ApiSalesTaxRateResponseModel response = await this.SalesTaxRateService.ByStateProvinceIDTaxType(stateProvinceID, taxType);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                private async Task<ApiSalesTaxRateRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesTaxRateRequestModel> patch)
                {
                        var record = await this.SalesTaxRateService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiSalesTaxRateRequestModel request = this.SalesTaxRateModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>17b5635ab33a076bf4ecfef6d5b6cb4a</Hash>
</Codenesium>*/