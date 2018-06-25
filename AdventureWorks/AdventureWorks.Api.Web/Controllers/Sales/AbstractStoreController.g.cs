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
        public abstract class AbstractStoreController : AbstractApiController
        {
                protected IStoreService StoreService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractStoreController(
                        ApiSettings settings,
                        ILogger<AbstractStoreController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStoreService storeService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.StoreService = storeService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStoreResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiStoreResponseModel> response = await this.StoreService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiStoreResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiStoreResponseModel response = await this.StoreService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiStoreResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiStoreRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiStoreResponseModel> records = new List<ApiStoreResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiStoreResponseModel> result = await this.StoreService.Create(model);

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
                [ProducesResponseType(typeof(ApiStoreResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiStoreRequestModel model)
                {
                        CreateResponse<ApiStoreResponseModel> result = await this.StoreService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Stores/{result.Record.BusinessEntityID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiStoreResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiStoreRequestModel> patch)
                {
                        ApiStoreResponseModel record = await this.StoreService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiStoreRequestModel model = new ApiStoreRequestModel();
                                model.SetProperties(model.Demographics,
                                                    model.ModifiedDate,
                                                    model.Name,
                                                    model.Rowguid,
                                                    model.SalesPersonID);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.StoreService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiStoreResponseModel response = await this.StoreService.Get(id);

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
                [ProducesResponseType(typeof(ApiStoreResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiStoreRequestModel model)
                {
                        ActionResponse result = await this.StoreService.Update(id, model);

                        if (result.Success)
                        {
                                ApiStoreResponseModel response = await this.StoreService.Get(id);

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
                        ActionResponse result = await this.StoreService.Delete(id);

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
                [Route("bySalesPersonID/{salesPersonID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStoreResponseModel>), 200)]
                public async virtual Task<IActionResult> BySalesPersonID(int? salesPersonID)
                {
                        List<ApiStoreResponseModel> response = await this.StoreService.BySalesPersonID(salesPersonID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byDemographics/{demographics}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStoreResponseModel>), 200)]
                public async virtual Task<IActionResult> ByDemographics(string demographics)
                {
                        List<ApiStoreResponseModel> response = await this.StoreService.ByDemographics(demographics);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{storeID}/Customers")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStoreResponseModel>), 200)]
                public async virtual Task<IActionResult> Customers(int storeID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiCustomerResponseModel> response = await this.StoreService.Customers(storeID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>a3d11044c89aaa796b808ee7f548116b</Hash>
</Codenesium>*/