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
        public abstract class AbstractBusinessEntityAddressController : AbstractApiController
        {
                protected IBusinessEntityAddressService BusinessEntityAddressService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractBusinessEntityAddressController(
                        ApiSettings settings,
                        ILogger<AbstractBusinessEntityAddressController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityAddressService businessEntityAddressService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.BusinessEntityAddressService = businessEntityAddressService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBusinessEntityAddressResponseModel> response = await this.BusinessEntityAddressService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiBusinessEntityAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiBusinessEntityAddressResponseModel response = await this.BusinessEntityAddressService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBusinessEntityAddressRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiBusinessEntityAddressResponseModel> records = new List<ApiBusinessEntityAddressResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiBusinessEntityAddressResponseModel> result = await this.BusinessEntityAddressService.Create(model);

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
                [ProducesResponseType(typeof(ApiBusinessEntityAddressResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiBusinessEntityAddressRequestModel model)
                {
                        CreateResponse<ApiBusinessEntityAddressResponseModel> result = await this.BusinessEntityAddressService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/BusinessEntityAddresses/{result.Record.BusinessEntityID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiBusinessEntityAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiBusinessEntityAddressRequestModel> patch)
                {
                        ApiBusinessEntityAddressResponseModel record = await this.BusinessEntityAddressService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiBusinessEntityAddressRequestModel model = new ApiBusinessEntityAddressRequestModel();
                                model.SetProperties(model.AddressID,
                                                    model.AddressTypeID,
                                                    model.ModifiedDate,
                                                    model.Rowguid);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.BusinessEntityAddressService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiBusinessEntityAddressResponseModel response = await this.BusinessEntityAddressService.Get(id);

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
                [ProducesResponseType(typeof(ApiBusinessEntityAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBusinessEntityAddressRequestModel model)
                {
                        ActionResponse result = await this.BusinessEntityAddressService.Update(id, model);

                        if (result.Success)
                        {
                                ApiBusinessEntityAddressResponseModel response = await this.BusinessEntityAddressService.Get(id);

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
                        ActionResponse result = await this.BusinessEntityAddressService.Delete(id);

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
                [Route("byAddressID/{addressID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
                public async virtual Task<IActionResult> ByAddressID(int addressID)
                {
                        List<ApiBusinessEntityAddressResponseModel> response = await this.BusinessEntityAddressService.ByAddressID(addressID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byAddressTypeID/{addressTypeID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityAddressResponseModel>), 200)]
                public async virtual Task<IActionResult> ByAddressTypeID(int addressTypeID)
                {
                        List<ApiBusinessEntityAddressResponseModel> response = await this.BusinessEntityAddressService.ByAddressTypeID(addressTypeID);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>b13a1b3112f64d8e5bf92a8656b4a56b</Hash>
</Codenesium>*/