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

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProductVendorController(
                        ApiSettings settings,
                        ILogger<AbstractProductVendorController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductVendorService productVendorService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProductVendorService = productVendorService;
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
                                ApiProductVendorRequestModel model = new ApiProductVendorRequestModel();
                                model.SetProperties(model.AverageLeadTime,
                                                    model.BusinessEntityID,
                                                    model.LastReceiptCost,
                                                    model.LastReceiptDate,
                                                    model.MaxOrderQty,
                                                    model.MinOrderQty,
                                                    model.ModifiedDate,
                                                    model.OnOrderQty,
                                                    model.StandardPrice,
                                                    model.UnitMeasureCode);
                                patch.ApplyTo(model);
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
        }
}

/*<Codenesium>
    <Hash>56674054a8ca43bec64f15ea7b1251a2</Hash>
</Codenesium>*/