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
        public abstract class AbstractPurchaseOrderDetailController : AbstractApiController
        {
                protected IPurchaseOrderDetailService PurchaseOrderDetailService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPurchaseOrderDetailController(
                        ApiSettings settings,
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

                [HttpPost]
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiPurchaseOrderDetailResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPurchaseOrderDetailRequestModel model)
                {
                        CreateResponse<ApiPurchaseOrderDetailResponseModel> result = await this.PurchaseOrderDetailService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/PurchaseOrderDetails/{result.Record.PurchaseOrderID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiPurchaseOrderDetailResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPurchaseOrderDetailRequestModel> patch)
                {
                        ApiPurchaseOrderDetailResponseModel record = await this.PurchaseOrderDetailService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiPurchaseOrderDetailRequestModel model = new ApiPurchaseOrderDetailRequestModel();
                                model.SetProperties(model.DueDate,
                                                    model.LineTotal,
                                                    model.ModifiedDate,
                                                    model.OrderQty,
                                                    model.ProductID,
                                                    model.PurchaseOrderDetailID,
                                                    model.ReceivedQty,
                                                    model.RejectedQty,
                                                    model.StockedQty,
                                                    model.UnitPrice);
                                patch.ApplyTo(model);
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
                [Route("byProductID/{productID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPurchaseOrderDetailResponseModel>), 200)]
                public async virtual Task<IActionResult> ByProductID(int productID)
                {
                        List<ApiPurchaseOrderDetailResponseModel> response = await this.PurchaseOrderDetailService.ByProductID(productID);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>6486fcebec74a4585731c710be7a0d13</Hash>
</Codenesium>*/