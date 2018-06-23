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
        public abstract class AbstractAddressController : AbstractApiController
        {
                protected IAddressService AddressService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractAddressController(
                        ApiSettings settings,
                        ILogger<AbstractAddressController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAddressService addressService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.AddressService = addressService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiAddressResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiAddressResponseModel> response = await this.AddressService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiAddressResponseModel response = await this.AddressService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiAddressResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiAddressRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiAddressResponseModel> records = new List<ApiAddressResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiAddressResponseModel> result = await this.AddressService.Create(model);

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
                [ProducesResponseType(typeof(ApiAddressResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiAddressRequestModel model)
                {
                        CreateResponse<ApiAddressResponseModel> result = await this.AddressService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Addresses/{result.Record.AddressID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiAddressRequestModel> patch)
                {
                        ApiAddressResponseModel record = await this.AddressService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiAddressRequestModel model = new ApiAddressRequestModel();
                                model.SetProperties(model.AddressLine1,
                                                    model.AddressLine2,
                                                    model.City,
                                                    model.ModifiedDate,
                                                    model.PostalCode,
                                                    model.Rowguid,
                                                    model.StateProvinceID);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.AddressService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiAddressResponseModel response = await this.AddressService.Get(id);

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
                [ProducesResponseType(typeof(ApiAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiAddressRequestModel model)
                {
                        ActionResponse result = await this.AddressService.Update(id, model);

                        if (result.Success)
                        {
                                ApiAddressResponseModel response = await this.AddressService.Get(id);

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
                        ActionResponse result = await this.AddressService.Delete(id);

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
                [Route("byAddressLine1AddressLine2CityStateProvinceIDPostalCode/{addressLine1}/{addressLine2}/{city}/{stateProvinceID}/{postalCode}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiAddressResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode)
                {
                        ApiAddressResponseModel response = await this.AddressService.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(addressLine1, addressLine2, city, stateProvinceID, postalCode);

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
                [Route("byStateProvinceID/{stateProvinceID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiAddressResponseModel>), 200)]
                public async virtual Task<IActionResult> ByStateProvinceID(int stateProvinceID)
                {
                        List<ApiAddressResponseModel> response = await this.AddressService.ByStateProvinceID(stateProvinceID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{addressID}/BusinessEntityAddresses")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiAddressResponseModel>), 200)]
                public async virtual Task<IActionResult> BusinessEntityAddresses(int addressID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBusinessEntityAddressResponseModel> response = await this.AddressService.BusinessEntityAddresses(addressID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>f96de67177605a0afe6f40f78f832f75</Hash>
</Codenesium>*/