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
        public abstract class AbstractSalesPersonQuotaHistoryController : AbstractApiController
        {
                protected ISalesPersonQuotaHistoryService SalesPersonQuotaHistoryService { get; private set; }

                protected IApiSalesPersonQuotaHistoryModelMapper SalesPersonQuotaHistoryModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSalesPersonQuotaHistoryController(
                        ApiSettings settings,
                        ILogger<AbstractSalesPersonQuotaHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesPersonQuotaHistoryService salesPersonQuotaHistoryService,
                        IApiSalesPersonQuotaHistoryModelMapper salesPersonQuotaHistoryModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SalesPersonQuotaHistoryService = salesPersonQuotaHistoryService;
                        this.SalesPersonQuotaHistoryModelMapper = salesPersonQuotaHistoryModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesPersonQuotaHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesPersonQuotaHistoryResponseModel> response = await this.SalesPersonQuotaHistoryService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesPersonQuotaHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSalesPersonQuotaHistoryResponseModel response = await this.SalesPersonQuotaHistoryService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiSalesPersonQuotaHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesPersonQuotaHistoryRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSalesPersonQuotaHistoryResponseModel> records = new List<ApiSalesPersonQuotaHistoryResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> result = await this.SalesPersonQuotaHistoryService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSalesPersonQuotaHistoryRequestModel model)
                {
                        CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> result = await this.SalesPersonQuotaHistoryService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesPersonQuotaHistories/{result.Record.BusinessEntityID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel> patch)
                {
                        ApiSalesPersonQuotaHistoryResponseModel record = await this.SalesPersonQuotaHistoryService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiSalesPersonQuotaHistoryRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel> result = await this.SalesPersonQuotaHistoryService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesPersonQuotaHistoryRequestModel model)
                {
                        ApiSalesPersonQuotaHistoryRequestModel request = await this.PatchModel(id, this.SalesPersonQuotaHistoryModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel> result = await this.SalesPersonQuotaHistoryService.Update(id, request);

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
                        ActionResponse result = await this.SalesPersonQuotaHistoryService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private async Task<ApiSalesPersonQuotaHistoryRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel> patch)
                {
                        var record = await this.SalesPersonQuotaHistoryService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiSalesPersonQuotaHistoryRequestModel request = this.SalesPersonQuotaHistoryModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>caf08f29051454619093241d9166550a</Hash>
</Codenesium>*/