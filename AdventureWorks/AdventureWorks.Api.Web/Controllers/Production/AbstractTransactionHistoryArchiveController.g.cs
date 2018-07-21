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
        public abstract class AbstractTransactionHistoryArchiveController : AbstractApiController
        {
                protected ITransactionHistoryArchiveService TransactionHistoryArchiveService { get; private set; }

                protected IApiTransactionHistoryArchiveModelMapper TransactionHistoryArchiveModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractTransactionHistoryArchiveController(
                        ApiSettings settings,
                        ILogger<AbstractTransactionHistoryArchiveController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITransactionHistoryArchiveService transactionHistoryArchiveService,
                        IApiTransactionHistoryArchiveModelMapper transactionHistoryArchiveModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.TransactionHistoryArchiveService = transactionHistoryArchiveService;
                        this.TransactionHistoryArchiveModelMapper = transactionHistoryArchiveModelMapper;
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

                [HttpPost]
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(CreateResponse<ApiTransactionHistoryArchiveResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiTransactionHistoryArchiveRequestModel model)
                {
                        CreateResponse<ApiTransactionHistoryArchiveResponseModel> result = await this.TransactionHistoryArchiveService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/TransactionHistoryArchives/{result.Record.TransactionID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiTransactionHistoryArchiveResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiTransactionHistoryArchiveRequestModel> patch)
                {
                        ApiTransactionHistoryArchiveResponseModel record = await this.TransactionHistoryArchiveService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiTransactionHistoryArchiveRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiTransactionHistoryArchiveResponseModel> result = await this.TransactionHistoryArchiveService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiTransactionHistoryArchiveResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiTransactionHistoryArchiveRequestModel model)
                {
                        ApiTransactionHistoryArchiveRequestModel request = await this.PatchModel(id, this.TransactionHistoryArchiveModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiTransactionHistoryArchiveResponseModel> result = await this.TransactionHistoryArchiveService.Update(id, request);

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
                [Route("byProductID/{productID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveResponseModel>), 200)]
                public async virtual Task<IActionResult> ByProductID(int productID)
                {
                        List<ApiTransactionHistoryArchiveResponseModel> response = await this.TransactionHistoryArchiveService.ByProductID(productID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byReferenceOrderIDReferenceOrderLineID/{referenceOrderID}/{referenceOrderLineID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiTransactionHistoryArchiveResponseModel>), 200)]
                public async virtual Task<IActionResult> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        List<ApiTransactionHistoryArchiveResponseModel> response = await this.TransactionHistoryArchiveService.ByReferenceOrderIDReferenceOrderLineID(referenceOrderID, referenceOrderLineID);

                        return this.Ok(response);
                }

                private async Task<ApiTransactionHistoryArchiveRequestModel> PatchModel(int id, JsonPatchDocument<ApiTransactionHistoryArchiveRequestModel> patch)
                {
                        var record = await this.TransactionHistoryArchiveService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiTransactionHistoryArchiveRequestModel request = this.TransactionHistoryArchiveModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>065642080d969dc653b24c11c5d8a91d</Hash>
</Codenesium>*/