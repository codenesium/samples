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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        public abstract class AbstractProvinceController : AbstractApiController
        {
                protected IProvinceService ProvinceService { get; private set; }

                protected IApiProvinceModelMapper ProvinceModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProvinceController(
                        ApiSettings settings,
                        ILogger<AbstractProvinceController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProvinceService provinceService,
                        IApiProvinceModelMapper provinceModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProvinceService = provinceService;
                        this.ProvinceModelMapper = provinceModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProvinceResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProvinceResponseModel> response = await this.ProvinceService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProvinceResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiProvinceResponseModel response = await this.ProvinceService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiProvinceResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProvinceRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProvinceResponseModel> records = new List<ApiProvinceResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProvinceResponseModel> result = await this.ProvinceService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiProvinceResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProvinceRequestModel model)
                {
                        CreateResponse<ApiProvinceResponseModel> result = await this.ProvinceService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Provinces/{result.Record.Id}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiProvinceResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProvinceRequestModel> patch)
                {
                        ApiProvinceResponseModel record = await this.ProvinceService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiProvinceRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiProvinceResponseModel> result = await this.ProvinceService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiProvinceResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProvinceRequestModel model)
                {
                        ApiProvinceRequestModel request = await this.PatchModel(id, this.ProvinceModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiProvinceResponseModel> result = await this.ProvinceService.Update(id, request);

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
                        ActionResponse result = await this.ProvinceService.Delete(id);

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
                [Route("byCountryId/{countryId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProvinceResponseModel>), 200)]
                public async virtual Task<IActionResult> ByCountryId(int countryId)
                {
                        List<ApiProvinceResponseModel> response = await this.ProvinceService.ByCountryId(countryId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{provinceId}/Cities")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProvinceResponseModel>), 200)]
                public async virtual Task<IActionResult> Cities(int provinceId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiCityResponseModel> response = await this.ProvinceService.Cities(provinceId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{provinceId}/Venues")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProvinceResponseModel>), 200)]
                public async virtual Task<IActionResult> Venues(int provinceId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiVenueResponseModel> response = await this.ProvinceService.Venues(provinceId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private async Task<ApiProvinceRequestModel> PatchModel(int id, JsonPatchDocument<ApiProvinceRequestModel> patch)
                {
                        var record = await this.ProvinceService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiProvinceRequestModel request = this.ProvinceModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f640b548414c8697abceb123699985a6</Hash>
</Codenesium>*/