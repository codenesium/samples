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
        public abstract class AbstractTransactionHistoryArchiveController: AbstractApiController
        {
                protected ITransactionHistoryArchiveService TransactionHistoryArchiveService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTransactionHistoryArchiveController(
                        ServiceSettings settings,
                        ILogger<AbstractTransactionHistoryArchiveController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITransactionHistoryArchiveService transactionHistoryArchiveService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.TransactionHistoryArchiveService = transactionHistoryArchiveService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTransactionHistoryArchiveResponseModel> response = await this.TransactionHistoryArchiveService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiTransactionHistoryArchiveResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiTransactionHistoryArchiveResponseModel response = await this.TransactionHistoryArchiveService.Get(id);

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
                [ProducesResponseType(typeof(ApiTransactionHistoryArchiveResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTransactionHistoryArchiveRequestModel model)
                {
                        CreateResponse<ApiTransactionHistoryArchiveResponseModel> result = await this.TransactionHistoryArchiveService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.TransactionID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/TransactionHistoryArchives/{result.Record.TransactionID.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiTransactionHistoryArchiveRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiTransactionHistoryArchiveResponseModel> records = new List<ApiTransactionHistoryArchiveResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiTransactionHistoryArchiveResponseModel> result = await this.TransactionHistoryArchiveService.Create(model);

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
                [ProducesResponseType(typeof(ApiTransactionHistoryArchiveResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTransactionHistoryArchiveRequestModel model)
                {
                        ActionResponse result = await this.TransactionHistoryArchiveService.Update(id, model);

                        if (result.Success)
                        {
                                ApiTransactionHistoryArchiveResponseModel response = await this.TransactionHistoryArchiveService.Get(id);

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
                        ActionResponse result = await this.TransactionHistoryArchiveService.Delete(id);

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
                [ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveResponseModel>), 200)]
                public async virtual Task<IActionResult> GetProductID(int productID)
                {
                        List<ApiTransactionHistoryArchiveResponseModel> response = await this.TransactionHistoryArchiveService.GetProductID(productID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveResponseModel>), 200)]
                public async virtual Task<IActionResult> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        List<ApiTransactionHistoryArchiveResponseModel> response = await this.TransactionHistoryArchiveService.GetReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>fae2852df832449db89eccfca90df46b</Hash>
</Codenesium>*/