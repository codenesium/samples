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
        public abstract class AbstractTransactionHistoryController: AbstractApiController
        {
                protected ITransactionHistoryService TransactionHistoryService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTransactionHistoryController(
                        ServiceSettings settings,
                        ILogger<AbstractTransactionHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITransactionHistoryService transactionHistoryService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.TransactionHistoryService = transactionHistoryService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTransactionHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTransactionHistoryResponseModel> response = await this.TransactionHistoryService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiTransactionHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiTransactionHistoryResponseModel response = await this.TransactionHistoryService.Get(id);

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
                [ProducesResponseType(typeof(ApiTransactionHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTransactionHistoryRequestModel model)
                {
                        CreateResponse<ApiTransactionHistoryResponseModel> result = await this.TransactionHistoryService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.TransactionID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/TransactionHistories/{result.Record.TransactionID.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiTransactionHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTransactionHistoryRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiTransactionHistoryResponseModel> records = new List<ApiTransactionHistoryResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiTransactionHistoryResponseModel> result = await this.TransactionHistoryService.Create(model);

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
                [ProducesResponseType(typeof(ApiTransactionHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTransactionHistoryRequestModel model)
                {
                        ActionResponse result = await this.TransactionHistoryService.Update(id, model);

                        if (result.Success)
                        {
                                ApiTransactionHistoryResponseModel response = await this.TransactionHistoryService.Get(id);

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
                        ActionResponse result = await this.TransactionHistoryService.Delete(id);

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
                [ProducesResponseType(typeof(List<ApiTransactionHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> GetProductID(int productID)
                {
                        List<ApiTransactionHistoryResponseModel> response = await this.TransactionHistoryService.GetProductID(productID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTransactionHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        List<ApiTransactionHistoryResponseModel> response = await this.TransactionHistoryService.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>260c42ff3b9381a984e3d1a24744ac47</Hash>
</Codenesium>*/