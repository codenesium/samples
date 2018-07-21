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
        public abstract class AbstractVenueController : AbstractApiController
        {
                protected IVenueService VenueService { get; private set; }

                protected IApiVenueModelMapper VenueModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractVenueController(
                        ApiSettings settings,
                        ILogger<AbstractVenueController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVenueService venueService,
                        IApiVenueModelMapper venueModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.VenueService = venueService;
                        this.VenueModelMapper = venueModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiVenueResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiVenueResponseModel> response = await this.VenueService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiVenueResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiVenueResponseModel response = await this.VenueService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiVenueResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiVenueRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiVenueResponseModel> records = new List<ApiVenueResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiVenueResponseModel> result = await this.VenueService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiVenueResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiVenueRequestModel model)
                {
                        CreateResponse<ApiVenueResponseModel> result = await this.VenueService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Venues/{result.Record.Id}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiVenueResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiVenueRequestModel> patch)
                {
                        ApiVenueResponseModel record = await this.VenueService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiVenueRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiVenueResponseModel> result = await this.VenueService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiVenueResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiVenueRequestModel model)
                {
                        ApiVenueRequestModel request = await this.PatchModel(id, this.VenueModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiVenueResponseModel> result = await this.VenueService.Update(id, request);

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
                        ActionResponse result = await this.VenueService.Delete(id);

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
                [Route("byAdminId/{adminId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiVenueResponseModel>), 200)]
                public async virtual Task<IActionResult> ByAdminId(int adminId)
                {
                        List<ApiVenueResponseModel> response = await this.VenueService.ByAdminId(adminId);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byProvinceId/{provinceId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiVenueResponseModel>), 200)]
                public async virtual Task<IActionResult> ByProvinceId(int provinceId)
                {
                        List<ApiVenueResponseModel> response = await this.VenueService.ByProvinceId(provinceId);

                        return this.Ok(response);
                }

                private async Task<ApiVenueRequestModel> PatchModel(int id, JsonPatchDocument<ApiVenueRequestModel> patch)
                {
                        var record = await this.VenueService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiVenueRequestModel request = this.VenueModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c0fa50b5dc71eb9b04b8dcab397e7618</Hash>
</Codenesium>*/