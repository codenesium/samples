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
        public abstract class AbstractPurchaseOrderHeaderController: AbstractApiController
        {
                protected IPurchaseOrderHeaderService PurchaseOrderHeaderService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPurchaseOrderHeaderController(
                        ServiceSettings settings,
                        ILogger<AbstractPurchaseOrderHeaderController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPurchaseOrderHeaderService purchaseOrderHeaderService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PurchaseOrderHeaderService = purchaseOrderHeaderService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPurchaseOrderHeaderResponseModel> response = await this.PurchaseOrderHeaderService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPurchaseOrderHeaderResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPurchaseOrderHeaderResponseModel response = await this.PurchaseOrderHeaderService.Get(id);

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
                [ProducesResponseType(typeof(ApiPurchaseOrderHeaderResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPurchaseOrderHeaderRequestModel model)
                {
                        CreateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.PurchaseOrderHeaderService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.PurchaseOrderID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/PurchaseOrderHeaders/{result.Record.PurchaseOrderID.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPurchaseOrderHeaderRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPurchaseOrderHeaderResponseModel> records = new List<ApiPurchaseOrderHeaderResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.PurchaseOrderHeaderService.Create(model);

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
                [ProducesResponseType(typeof(ApiPurchaseOrderHeaderResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPurchaseOrderHeaderRequestModel model)
                {
                        ActionResponse result = await this.PurchaseOrderHeaderService.Update(id, model);

                        if (result.Success)
                        {
                                ApiPurchaseOrderHeaderResponseModel response = await this.PurchaseOrderHeaderService.Get(id);

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
                        ActionResponse result = await this.PurchaseOrderHeaderService.Delete(id);

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
                [Route("getEmployeeID/{employeeID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
                public async virtual Task<IActionResult> GetEmployeeID(int employeeID)
                {
                        List<ApiPurchaseOrderHeaderResponseModel> response = await this.PurchaseOrderHeaderService.GetEmployeeID(employeeID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getVendorID/{vendorID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
                public async virtual Task<IActionResult> GetVendorID(int vendorID)
                {
                        List<ApiPurchaseOrderHeaderResponseModel> response = await this.PurchaseOrderHeaderService.GetVendorID(vendorID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{purchaseOrderID}/PurchaseOrderDetails")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPurchaseOrderHeaderResponseModel>), 200)]
                public async virtual Task<IActionResult> PurchaseOrderDetails(int purchaseOrderID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPurchaseOrderDetailResponseModel> response = await this.PurchaseOrderHeaderService.PurchaseOrderDetails(purchaseOrderID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>c2e2c55509ba4dd2a1ac8d9da86dc5a6</Hash>
</Codenesium>*/