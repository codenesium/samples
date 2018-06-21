using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
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
        public abstract class AbstractTransactionHistoryController : AbstractApiController
        {
                protected ITransactionHistoryService TransactionHistoryService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTransactionHistoryController(
                        ApiSettings settings,
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
                [ProducesResponseType(typeof(ApiTransactionHistoryResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTransactionHistoryRequestModel model)
                {
                        CreateResponse<ApiTransactionHistoryResponseModel> result = await this.TransactionHistoryService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/TransactionHistories/{result.Record.TransactionID}", result.Record);
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
                [Route("byProductID/{productID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTransactionHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> ByProductID(int productID)
                {
                        List<ApiTransactionHistoryResponseModel> response = await this.TransactionHistoryService.ByProductID(productID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTransactionHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        List<ApiTransactionHistoryResponseModel> response = await this.TransactionHistoryService.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>84e69d78d5124d3abc0c9e7069c3811c</Hash>
</Codenesium>*/