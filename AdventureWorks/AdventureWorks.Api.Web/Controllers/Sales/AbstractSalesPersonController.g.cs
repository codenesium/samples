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
        public abstract class AbstractSalesPersonController : AbstractApiController
        {
                protected ISalesPersonService SalesPersonService { get; private set; }

                protected IApiSalesPersonModelMapper SalesPersonModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSalesPersonController(
                        ApiSettings settings,
                        ILogger<AbstractSalesPersonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesPersonService salesPersonService,
                        IApiSalesPersonModelMapper salesPersonModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SalesPersonService = salesPersonService;
                        this.SalesPersonModelMapper = salesPersonModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesPersonResponseModel> response = await this.SalesPersonService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesPersonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSalesPersonResponseModel response = await this.SalesPersonService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesPersonRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSalesPersonResponseModel> records = new List<ApiSalesPersonResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSalesPersonResponseModel> result = await this.SalesPersonService.Create(model);

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
                [ProducesResponseType(typeof(ApiSalesPersonResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSalesPersonRequestModel model)
                {
                        CreateResponse<ApiSalesPersonResponseModel> result = await this.SalesPersonService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/SalesPersons/{result.Record.BusinessEntityID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiSalesPersonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSalesPersonRequestModel> patch)
                {
                        ApiSalesPersonResponseModel record = await this.SalesPersonService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiSalesPersonRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.SalesPersonService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiSalesPersonResponseModel response = await this.SalesPersonService.Get(id);

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
                [ProducesResponseType(typeof(ApiSalesPersonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesPersonRequestModel model)
                {
                        ApiSalesPersonRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.SalesPersonService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiSalesPersonResponseModel response = await this.SalesPersonService.Get(id);

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
                        ActionResponse result = await this.SalesPersonService.Delete(id);

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
                [Route("{salesPersonID}/SalesOrderHeaders")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
                public async virtual Task<IActionResult> SalesOrderHeaders(int salesPersonID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesOrderHeaderResponseModel> response = await this.SalesPersonService.SalesOrderHeaders(salesPersonID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{businessEntityID}/SalesPersonQuotaHistories")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
                public async virtual Task<IActionResult> SalesPersonQuotaHistories(int businessEntityID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesPersonQuotaHistoryResponseModel> response = await this.SalesPersonService.SalesPersonQuotaHistories(businessEntityID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{businessEntityID}/SalesTerritoryHistories")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
                public async virtual Task<IActionResult> SalesTerritoryHistories(int businessEntityID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesTerritoryHistoryResponseModel> response = await this.SalesPersonService.SalesTerritoryHistories(businessEntityID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{salesPersonID}/Stores")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesPersonResponseModel>), 200)]
                public async virtual Task<IActionResult> Stores(int salesPersonID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiStoreResponseModel> response = await this.SalesPersonService.Stores(salesPersonID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiSalesPersonRequestModel> CreatePatch(ApiSalesPersonRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSalesPersonRequestModel>();
                        patch.Replace(x => x.Bonus, model.Bonus);
                        patch.Replace(x => x.CommissionPct, model.CommissionPct);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.SalesLastYear, model.SalesLastYear);
                        patch.Replace(x => x.SalesQuota, model.SalesQuota);
                        patch.Replace(x => x.SalesYTD, model.SalesYTD);
                        patch.Replace(x => x.TerritoryID, model.TerritoryID);
                        return patch;
                }

                private async Task<ApiSalesPersonRequestModel> PatchModel(int id, JsonPatchDocument<ApiSalesPersonRequestModel> patch)
                {
                        var record = await this.SalesPersonService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiSalesPersonRequestModel request = this.SalesPersonModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>577080d02400975077562832813a535d</Hash>
</Codenesium>*/