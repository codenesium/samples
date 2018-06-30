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
        public abstract class AbstractProductInventoryController : AbstractApiController
        {
                protected IProductInventoryService ProductInventoryService { get; private set; }

                protected IApiProductInventoryModelMapper ProductInventoryModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProductInventoryController(
                        ApiSettings settings,
                        ILogger<AbstractProductInventoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductInventoryService productInventoryService,
                        IApiProductInventoryModelMapper productInventoryModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProductInventoryService = productInventoryService;
                        this.ProductInventoryModelMapper = productInventoryModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductInventoryResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductInventoryResponseModel> response = await this.ProductInventoryService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProductInventoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiProductInventoryResponseModel response = await this.ProductInventoryService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiProductInventoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductInventoryRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProductInventoryResponseModel> records = new List<ApiProductInventoryResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProductInventoryResponseModel> result = await this.ProductInventoryService.Create(model);

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
                [ProducesResponseType(typeof(ApiProductInventoryResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProductInventoryRequestModel model)
                {
                        CreateResponse<ApiProductInventoryResponseModel> result = await this.ProductInventoryService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductInventories/{result.Record.ProductID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiProductInventoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductInventoryRequestModel> patch)
                {
                        ApiProductInventoryResponseModel record = await this.ProductInventoryService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiProductInventoryRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ProductInventoryService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiProductInventoryResponseModel response = await this.ProductInventoryService.Get(id);

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
                [ProducesResponseType(typeof(ApiProductInventoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductInventoryRequestModel model)
                {
                        ApiProductInventoryRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ProductInventoryService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiProductInventoryResponseModel response = await this.ProductInventoryService.Get(id);

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
                        ActionResponse result = await this.ProductInventoryService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiProductInventoryRequestModel> CreatePatch(ApiProductInventoryRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductInventoryRequestModel>();
                        patch.Replace(x => x.Bin, model.Bin);
                        patch.Replace(x => x.LocationID, model.LocationID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Quantity, model.Quantity);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.Shelf, model.Shelf);
                        return patch;
                }

                private async Task<ApiProductInventoryRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductInventoryRequestModel> patch)
                {
                        var record = await this.ProductInventoryService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiProductInventoryRequestModel request = this.ProductInventoryModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>45336b6d2e988885ddbf0d521674bede</Hash>
</Codenesium>*/