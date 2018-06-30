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
        public abstract class AbstractProductVendorController : AbstractApiController
        {
                protected IProductVendorService ProductVendorService { get; private set; }

                protected IApiProductVendorModelMapper ProductVendorModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProductVendorController(
                        ApiSettings settings,
                        ILogger<AbstractProductVendorController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductVendorService productVendorService,
                        IApiProductVendorModelMapper productVendorModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProductVendorService = productVendorService;
                        this.ProductVendorModelMapper = productVendorModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductVendorResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductVendorResponseModel> response = await this.ProductVendorService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProductVendorResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiProductVendorResponseModel response = await this.ProductVendorService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiProductVendorResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductVendorRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProductVendorResponseModel> records = new List<ApiProductVendorResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProductVendorResponseModel> result = await this.ProductVendorService.Create(model);

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
                [ProducesResponseType(typeof(ApiProductVendorResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProductVendorRequestModel model)
                {
                        CreateResponse<ApiProductVendorResponseModel> result = await this.ProductVendorService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductVendors/{result.Record.ProductID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiProductVendorResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductVendorRequestModel> patch)
                {
                        ApiProductVendorResponseModel record = await this.ProductVendorService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiProductVendorRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ProductVendorService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiProductVendorResponseModel response = await this.ProductVendorService.Get(id);

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
                [ProducesResponseType(typeof(ApiProductVendorResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductVendorRequestModel model)
                {
                        ApiProductVendorRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ProductVendorService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiProductVendorResponseModel response = await this.ProductVendorService.Get(id);

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
                        ActionResponse result = await this.ProductVendorService.Delete(id);

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
                [Route("byBusinessEntityID/{businessEntityID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductVendorResponseModel>), 200)]
                public async virtual Task<IActionResult> ByBusinessEntityID(int businessEntityID)
                {
                        List<ApiProductVendorResponseModel> response = await this.ProductVendorService.ByBusinessEntityID(businessEntityID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byUnitMeasureCode/{unitMeasureCode}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductVendorResponseModel>), 200)]
                public async virtual Task<IActionResult> ByUnitMeasureCode(string unitMeasureCode)
                {
                        List<ApiProductVendorResponseModel> response = await this.ProductVendorService.ByUnitMeasureCode(unitMeasureCode);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiProductVendorRequestModel> CreatePatch(ApiProductVendorRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductVendorRequestModel>();
                        patch.Replace(x => x.AverageLeadTime, model.AverageLeadTime);
                        patch.Replace(x => x.BusinessEntityID, model.BusinessEntityID);
                        patch.Replace(x => x.LastReceiptCost, model.LastReceiptCost);
                        patch.Replace(x => x.LastReceiptDate, model.LastReceiptDate);
                        patch.Replace(x => x.MaxOrderQty, model.MaxOrderQty);
                        patch.Replace(x => x.MinOrderQty, model.MinOrderQty);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.OnOrderQty, model.OnOrderQty);
                        patch.Replace(x => x.StandardPrice, model.StandardPrice);
                        patch.Replace(x => x.UnitMeasureCode, model.UnitMeasureCode);
                        return patch;
                }

                private async Task<ApiProductVendorRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductVendorRequestModel> patch)
                {
                        var record = await this.ProductVendorService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiProductVendorRequestModel request = this.ProductVendorModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>4bb59cad1642d6b808713e96834daddd</Hash>
</Codenesium>*/