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
        public abstract class AbstractProductController : AbstractApiController
        {
                protected IProductService ProductService { get; private set; }

                protected IApiProductModelMapper ProductModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProductController(
                        ApiSettings settings,
                        ILogger<AbstractProductController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductService productService,
                        IApiProductModelMapper productModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProductService = productService;
                        this.ProductModelMapper = productModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductResponseModel> response = await this.ProductService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProductResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiProductResponseModel response = await this.ProductService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProductResponseModel> records = new List<ApiProductResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProductResponseModel> result = await this.ProductService.Create(model);

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
                [ProducesResponseType(typeof(ApiProductResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProductRequestModel model)
                {
                        CreateResponse<ApiProductResponseModel> result = await this.ProductService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Products/{result.Record.ProductID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiProductResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductRequestModel> patch)
                {
                        ApiProductResponseModel record = await this.ProductService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiProductRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ProductService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiProductResponseModel response = await this.ProductService.Get(id);

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
                [ProducesResponseType(typeof(ApiProductResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductRequestModel model)
                {
                        ApiProductRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ProductService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiProductResponseModel response = await this.ProductService.Get(id);

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
                        ActionResponse result = await this.ProductService.Delete(id);

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
                [Route("byName/{name}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProductResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByName(string name)
                {
                        ApiProductResponseModel response = await this.ProductService.ByName(name);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                [HttpGet]
                [Route("byProductNumber/{productNumber}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProductResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByProductNumber(string productNumber)
                {
                        ApiProductResponseModel response = await this.ProductService.ByProductNumber(productNumber);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                [HttpGet]
                [Route("{componentID}/BillOfMaterials")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> BillOfMaterials(int componentID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBillOfMaterialsResponseModel> response = await this.ProductService.BillOfMaterials(componentID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{productID}/ProductCostHistories")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> ProductCostHistories(int productID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductCostHistoryResponseModel> response = await this.ProductService.ProductCostHistories(productID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{productID}/ProductInventories")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> ProductInventories(int productID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductInventoryResponseModel> response = await this.ProductService.ProductInventories(productID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{productID}/ProductListPriceHistories")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> ProductListPriceHistories(int productID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductListPriceHistoryResponseModel> response = await this.ProductService.ProductListPriceHistories(productID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{productID}/ProductProductPhotoes")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> ProductProductPhotoes(int productID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductProductPhotoResponseModel> response = await this.ProductService.ProductProductPhotoes(productID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{productID}/ProductReviews")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> ProductReviews(int productID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductReviewResponseModel> response = await this.ProductService.ProductReviews(productID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{productID}/TransactionHistories")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> TransactionHistories(int productID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiTransactionHistoryResponseModel> response = await this.ProductService.TransactionHistories(productID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{productID}/WorkOrders")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductResponseModel>), 200)]
                public async virtual Task<IActionResult> WorkOrders(int productID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiWorkOrderResponseModel> response = await this.ProductService.WorkOrders(productID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiProductRequestModel> CreatePatch(ApiProductRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductRequestModel>();
                        patch.Replace(x => x.@Class, model.@Class);
                        patch.Replace(x => x.Color, model.Color);
                        patch.Replace(x => x.DaysToManufacture, model.DaysToManufacture);
                        patch.Replace(x => x.DiscontinuedDate, model.DiscontinuedDate);
                        patch.Replace(x => x.FinishedGoodsFlag, model.FinishedGoodsFlag);
                        patch.Replace(x => x.ListPrice, model.ListPrice);
                        patch.Replace(x => x.MakeFlag, model.MakeFlag);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.ProductLine, model.ProductLine);
                        patch.Replace(x => x.ProductModelID, model.ProductModelID);
                        patch.Replace(x => x.ProductNumber, model.ProductNumber);
                        patch.Replace(x => x.ProductSubcategoryID, model.ProductSubcategoryID);
                        patch.Replace(x => x.ReorderPoint, model.ReorderPoint);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.SafetyStockLevel, model.SafetyStockLevel);
                        patch.Replace(x => x.SellEndDate, model.SellEndDate);
                        patch.Replace(x => x.SellStartDate, model.SellStartDate);
                        patch.Replace(x => x.Size, model.Size);
                        patch.Replace(x => x.SizeUnitMeasureCode, model.SizeUnitMeasureCode);
                        patch.Replace(x => x.StandardCost, model.StandardCost);
                        patch.Replace(x => x.Style, model.Style);
                        patch.Replace(x => x.Weight, model.Weight);
                        patch.Replace(x => x.WeightUnitMeasureCode, model.WeightUnitMeasureCode);
                        return patch;
                }

                private async Task<ApiProductRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductRequestModel> patch)
                {
                        var record = await this.ProductService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiProductRequestModel request = this.ProductModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>33e01e83565cbfbf85af58fef75237af</Hash>
</Codenesium>*/