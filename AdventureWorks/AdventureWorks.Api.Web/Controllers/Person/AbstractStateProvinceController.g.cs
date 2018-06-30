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
        public abstract class AbstractStateProvinceController : AbstractApiController
        {
                protected IStateProvinceService StateProvinceService { get; private set; }

                protected IApiStateProvinceModelMapper StateProvinceModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractStateProvinceController(
                        ApiSettings settings,
                        ILogger<AbstractStateProvinceController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStateProvinceService stateProvinceService,
                        IApiStateProvinceModelMapper stateProvinceModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.StateProvinceService = stateProvinceService;
                        this.StateProvinceModelMapper = stateProvinceModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStateProvinceResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiStateProvinceResponseModel> response = await this.StateProvinceService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiStateProvinceResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiStateProvinceResponseModel response = await this.StateProvinceService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiStateProvinceResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiStateProvinceRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiStateProvinceResponseModel> records = new List<ApiStateProvinceResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiStateProvinceResponseModel> result = await this.StateProvinceService.Create(model);

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
                [ProducesResponseType(typeof(ApiStateProvinceResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiStateProvinceRequestModel model)
                {
                        CreateResponse<ApiStateProvinceResponseModel> result = await this.StateProvinceService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/StateProvinces/{result.Record.StateProvinceID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiStateProvinceResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiStateProvinceRequestModel> patch)
                {
                        ApiStateProvinceResponseModel record = await this.StateProvinceService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiStateProvinceRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.StateProvinceService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiStateProvinceResponseModel response = await this.StateProvinceService.Get(id);

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
                [ProducesResponseType(typeof(ApiStateProvinceResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiStateProvinceRequestModel model)
                {
                        ApiStateProvinceRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.StateProvinceService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiStateProvinceResponseModel response = await this.StateProvinceService.Get(id);

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
                        ActionResponse result = await this.StateProvinceService.Delete(id);

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
                [ProducesResponseType(typeof(ApiStateProvinceResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByName(string name)
                {
                        ApiStateProvinceResponseModel response = await this.StateProvinceService.ByName(name);

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
                [Route("byStateProvinceCodeCountryRegionCode/{stateProvinceCode}/{countryRegionCode}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiStateProvinceResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
                {
                        ApiStateProvinceResponseModel response = await this.StateProvinceService.ByStateProvinceCodeCountryRegionCode(stateProvinceCode, countryRegionCode);

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
                [Route("{stateProvinceID}/Addresses")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiStateProvinceResponseModel>), 200)]
                public async virtual Task<IActionResult> Addresses(int stateProvinceID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiAddressResponseModel> response = await this.StateProvinceService.Addresses(stateProvinceID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiStateProvinceRequestModel> CreatePatch(ApiStateProvinceRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiStateProvinceRequestModel>();
                        patch.Replace(x => x.CountryRegionCode, model.CountryRegionCode);
                        patch.Replace(x => x.IsOnlyStateProvinceFlag, model.IsOnlyStateProvinceFlag);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.StateProvinceCode, model.StateProvinceCode);
                        patch.Replace(x => x.TerritoryID, model.TerritoryID);
                        return patch;
                }

                private async Task<ApiStateProvinceRequestModel> PatchModel(int id, JsonPatchDocument<ApiStateProvinceRequestModel> patch)
                {
                        var record = await this.StateProvinceService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiStateProvinceRequestModel request = this.StateProvinceModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>01681023155bd05243fed3323f6f077d</Hash>
</Codenesium>*/