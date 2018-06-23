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

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProvinceController(
                        ApiSettings settings,
                        ILogger<AbstractProvinceController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProvinceService provinceService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProvinceService = provinceService;
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
                [ProducesResponseType(typeof(ApiProvinceResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProvinceRequestModel model)
                {
                        CreateResponse<ApiProvinceResponseModel> result = await this.ProvinceService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Provinces/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiProvinceResponseModel), 200)]
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
                                ApiProvinceRequestModel model = new ApiProvinceRequestModel();
                                model.SetProperties(model.CountryId,
                                                    model.Name);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.ProvinceService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiProvinceResponseModel response = await this.ProvinceService.Get(id);

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
                [ProducesResponseType(typeof(ApiProvinceResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProvinceRequestModel model)
                {
                        ActionResponse result = await this.ProvinceService.Update(id, model);

                        if (result.Success)
                        {
                                ApiProvinceResponseModel response = await this.ProvinceService.Get(id);

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
                [Route("getCountryId/{countryId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProvinceResponseModel>), 200)]
                public async virtual Task<IActionResult> GetCountryId(int countryId)
                {
                        List<ApiProvinceResponseModel> response = await this.ProvinceService.GetCountryId(countryId);

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
        }
}

/*<Codenesium>
    <Hash>8e810056bc0c977ad623db6e635e7792</Hash>
</Codenesium>*/