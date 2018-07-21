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
        public abstract class AbstractSpecialOfferProductController : AbstractApiController
        {
                protected ISpecialOfferProductService SpecialOfferProductService { get; private set; }

                protected IApiSpecialOfferProductModelMapper SpecialOfferProductModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSpecialOfferProductController(
                        ApiSettings settings,
                        ILogger<AbstractSpecialOfferProductController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpecialOfferProductService specialOfferProductService,
                        IApiSpecialOfferProductModelMapper specialOfferProductModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SpecialOfferProductService = specialOfferProductService;
                        this.SpecialOfferProductModelMapper = specialOfferProductModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSpecialOfferProductResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSpecialOfferProductResponseModel> response = await this.SpecialOfferProductService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSpecialOfferProductResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSpecialOfferProductResponseModel response = await this.SpecialOfferProductService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiSpecialOfferProductResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpecialOfferProductRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSpecialOfferProductResponseModel> records = new List<ApiSpecialOfferProductResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSpecialOfferProductResponseModel> result = await this.SpecialOfferProductService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiSpecialOfferProductResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSpecialOfferProductRequestModel model)
                {
                        CreateResponse<ApiSpecialOfferProductResponseModel> result = await this.SpecialOfferProductService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/SpecialOfferProducts/{result.Record.SpecialOfferID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiSpecialOfferProductResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSpecialOfferProductRequestModel> patch)
                {
                        ApiSpecialOfferProductResponseModel record = await this.SpecialOfferProductService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiSpecialOfferProductRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiSpecialOfferProductResponseModel> result = await this.SpecialOfferProductService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiSpecialOfferProductResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpecialOfferProductRequestModel model)
                {
                        ApiSpecialOfferProductRequestModel request = await this.PatchModel(id, this.SpecialOfferProductModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiSpecialOfferProductResponseModel> result = await this.SpecialOfferProductService.Update(id, request);

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
                        ActionResponse result = await this.SpecialOfferProductService.Delete(id);

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
                [ProducesResponseType(typeof(List<ApiSpecialOfferProductResponseModel>), 200)]
                public async virtual Task<IActionResult> ByProductID(int productID)
                {
                        List<ApiSpecialOfferProductResponseModel> response = await this.SpecialOfferProductService.ByProductID(productID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{specialOfferID}/SalesOrderDetails")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSpecialOfferProductResponseModel>), 200)]
                public async virtual Task<IActionResult> SalesOrderDetails(int specialOfferID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesOrderDetailResponseModel> response = await this.SpecialOfferProductService.SalesOrderDetails(specialOfferID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private async Task<ApiSpecialOfferProductRequestModel> PatchModel(int id, JsonPatchDocument<ApiSpecialOfferProductRequestModel> patch)
                {
                        var record = await this.SpecialOfferProductService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiSpecialOfferProductRequestModel request = this.SpecialOfferProductModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a5e5203b065666cbb2ef73af902ed553</Hash>
</Codenesium>*/