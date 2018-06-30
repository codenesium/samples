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
        public abstract class AbstractSalesOrderDetailController : AbstractApiController
        {
                protected ISalesOrderDetailService SalesOrderDetailService { get; private set; }

                protected IApiSalesOrderDetailModelMapper SalesOrderDetailModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSalesOrderDetailController(
                        ApiSettings settings,
                        ILogger<AbstractSalesOrderDetailController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesOrderDetailService salesOrderDetailService,
                        IApiSalesOrderDetailModelMapper salesOrderDetailModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SalesOrderDetailService = salesOrderDetailService;
                        this.SalesOrderDetailModelMapper = salesOrderDetailModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesOrderDetailResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesOrderDetailResponseModel> response = await this.SalesOrderDetailService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesOrderDetailResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSalesOrderDetailResponseModel response = await this.SalesOrderDetailService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiSalesOrderDetailResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesOrderDetailRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSalesOrderDetailResponseModel> records = new List<ApiSalesOrderDetailResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSalesOrderDetailResponseModel> result = await this.SalesOrderDetailService.Create(model);

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
                [ProducesResponseType(typeof(ApiSalesOrderDetailResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSalesOrderDetailRequestModel model)
                {
                        CreateResponse<ApiSalesOrderDetailResponseModel> result = await this.SalesOrderDetailService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesOrderDetails/{result.Record.SalesOrderID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiSalesOrderDetailResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesOrderDetailRequestModel> patch)
                {
                        ApiSalesOrderDetailResponseModel record = await this.SalesOrderDetailService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiSalesOrderDetailRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.SalesOrderDetailService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiSalesOrderDetailResponseModel response = await this.SalesOrderDetailService.Get(id);

                                        return this.Ok(response);
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
                [ProducesResponseType(typeof(ApiSalesOrderDetailResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesOrderDetailRequestModel model)
                {
                        ApiSalesOrderDetailRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.SalesOrderDetailService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiSalesOrderDetailResponseModel response = await this.SalesOrderDetailService.Get(id);

                                        return this.Ok(response);
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
                        ActionResponse result = await this.SalesOrderDetailService.Delete(id);

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
                [Route("byProductID/{productID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesOrderDetailResponseModel>), 200)]
                public async virtual Task<IActionResult> ByProductID(int productID)
                {
                        List<ApiSalesOrderDetailResponseModel> response = await this.SalesOrderDetailService.ByProductID(productID);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiSalesOrderDetailRequestModel> CreatePatch(ApiSalesOrderDetailRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSalesOrderDetailRequestModel>();
                        patch.Replace(x => x.CarrierTrackingNumber, model.CarrierTrackingNumber);
                        patch.Replace(x => x.LineTotal, model.LineTotal);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.OrderQty, model.OrderQty);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.SalesOrderDetailID, model.SalesOrderDetailID);
                        patch.Replace(x => x.SpecialOfferID, model.SpecialOfferID);
                        patch.Replace(x => x.UnitPrice, model.UnitPrice);
                        patch.Replace(x => x.UnitPriceDiscount, model.UnitPriceDiscount);
                        return patch;
                }

                private async Task<ApiSalesOrderDetailRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesOrderDetailRequestModel> patch)
                {
                        var record = await this.SalesOrderDetailService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiSalesOrderDetailRequestModel request = this.SalesOrderDetailModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>7c214c74f0da2392c53130518dc45094</Hash>
</Codenesium>*/