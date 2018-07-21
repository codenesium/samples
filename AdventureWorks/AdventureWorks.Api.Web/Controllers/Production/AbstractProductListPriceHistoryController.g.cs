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
        public abstract class AbstractProductListPriceHistoryController : AbstractApiController
        {
                protected IProductListPriceHistoryService ProductListPriceHistoryService { get; private set; }

                protected IApiProductListPriceHistoryModelMapper ProductListPriceHistoryModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProductListPriceHistoryController(
                        ApiSettings settings,
                        ILogger<AbstractProductListPriceHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductListPriceHistoryService productListPriceHistoryService,
                        IApiProductListPriceHistoryModelMapper productListPriceHistoryModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProductListPriceHistoryService = productListPriceHistoryService;
                        this.ProductListPriceHistoryModelMapper = productListPriceHistoryModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductListPriceHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductListPriceHistoryResponseModel> response = await this.ProductListPriceHistoryService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProductListPriceHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiProductListPriceHistoryResponseModel response = await this.ProductListPriceHistoryService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiProductListPriceHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductListPriceHistoryRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProductListPriceHistoryResponseModel> records = new List<ApiProductListPriceHistoryResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProductListPriceHistoryResponseModel> result = await this.ProductListPriceHistoryService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiProductListPriceHistoryResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProductListPriceHistoryRequestModel model)
                {
                        CreateResponse<ApiProductListPriceHistoryResponseModel> result = await this.ProductListPriceHistoryService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductListPriceHistories/{result.Record.ProductID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiProductListPriceHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductListPriceHistoryRequestModel> patch)
                {
                        ApiProductListPriceHistoryResponseModel record = await this.ProductListPriceHistoryService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiProductListPriceHistoryRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiProductListPriceHistoryResponseModel> result = await this.ProductListPriceHistoryService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiProductListPriceHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductListPriceHistoryRequestModel model)
                {
                        ApiProductListPriceHistoryRequestModel request = await this.PatchModel(id, this.ProductListPriceHistoryModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiProductListPriceHistoryResponseModel> result = await this.ProductListPriceHistoryService.Update(id, request);

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
                        ActionResponse result = await this.ProductListPriceHistoryService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private async Task<ApiProductListPriceHistoryRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductListPriceHistoryRequestModel> patch)
                {
                        var record = await this.ProductListPriceHistoryService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiProductListPriceHistoryRequestModel request = this.ProductListPriceHistoryModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>14c90b00e53cdd4c1a5de91ef28fb086</Hash>
</Codenesium>*/