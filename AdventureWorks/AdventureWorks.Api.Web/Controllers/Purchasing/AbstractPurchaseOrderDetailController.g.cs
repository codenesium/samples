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
        public abstract class AbstractPurchaseOrderDetailController: AbstractApiController
        {
                protected IPurchaseOrderDetailService PurchaseOrderDetailService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPurchaseOrderDetailController(
                        ServiceSettings settings,
                        ILogger<AbstractPurchaseOrderDetailController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPurchaseOrderDetailService purchaseOrderDetailService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PurchaseOrderDetailService = purchaseOrderDetailService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPurchaseOrderDetailResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPurchaseOrderDetailResponseModel> response = await this.PurchaseOrderDetailService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPurchaseOrderDetailResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPurchaseOrderDetailResponseModel response = await this.PurchaseOrderDetailService.Get(id);

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
                [ProducesResponseType(typeof(ApiPurchaseOrderDetailResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPurchaseOrderDetailRequestModel model)
                {
                        CreateResponse<ApiPurchaseOrderDetailResponseModel> result = await this.PurchaseOrderDetailService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.PurchaseOrderID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/PurchaseOrderDetails/{result.Record.PurchaseOrderID.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiPurchaseOrderDetailResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPurchaseOrderDetailRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPurchaseOrderDetailResponseModel> records = new List<ApiPurchaseOrderDetailResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPurchaseOrderDetailResponseModel> result = await this.PurchaseOrderDetailService.Create(model);

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
                [ProducesResponseType(typeof(ApiPurchaseOrderDetailResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPurchaseOrderDetailRequestModel model)
                {
                        ActionResponse result = await this.PurchaseOrderDetailService.Update(id, model);

                        if (result.Success)
                        {
                                ApiPurchaseOrderDetailResponseModel response = await this.PurchaseOrderDetailService.Get(id);

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
                        ActionResponse result = await this.PurchaseOrderDetailService.Delete(id);

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
                [Route("getProductID/{productID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPurchaseOrderDetailResponseModel>), 200)]
                public async virtual Task<IActionResult> GetProductID(int productID)
                {
                        List<ApiPurchaseOrderDetailResponseModel> response = await this.PurchaseOrderDetailService.GetProductID(productID);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>1b34e72ace93f56f077ea5d42df9e9d7</Hash>
</Codenesium>*/