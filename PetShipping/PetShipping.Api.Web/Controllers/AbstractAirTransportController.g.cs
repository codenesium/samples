using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
        public abstract class AbstractAirTransportController : AbstractApiController
        {
                protected IAirTransportService AirTransportService { get; private set; }

                protected IApiAirTransportModelMapper AirTransportModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractAirTransportController(
                        ApiSettings settings,
                        ILogger<AbstractAirTransportController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAirTransportService airTransportService,
                        IApiAirTransportModelMapper airTransportModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.AirTransportService = airTransportService;
                        this.AirTransportModelMapper = airTransportModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiAirTransportResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiAirTransportResponseModel> response = await this.AirTransportService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiAirTransportResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiAirTransportResponseModel response = await this.AirTransportService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiAirTransportResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiAirTransportRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiAirTransportResponseModel> records = new List<ApiAirTransportResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiAirTransportResponseModel> result = await this.AirTransportService.Create(model);

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
                [ProducesResponseType(typeof(ApiAirTransportResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiAirTransportRequestModel model)
                {
                        CreateResponse<ApiAirTransportResponseModel> result = await this.AirTransportService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/AirTransports/{result.Record.AirlineId}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiAirTransportResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiAirTransportRequestModel> patch)
                {
                        ApiAirTransportResponseModel record = await this.AirTransportService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiAirTransportRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.AirTransportService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiAirTransportResponseModel response = await this.AirTransportService.Get(id);

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
                [ProducesResponseType(typeof(ApiAirTransportResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiAirTransportRequestModel model)
                {
                        ApiAirTransportRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.AirTransportService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiAirTransportResponseModel response = await this.AirTransportService.Get(id);

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
                        ActionResponse result = await this.AirTransportService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiAirTransportRequestModel> CreatePatch(ApiAirTransportRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiAirTransportRequestModel>();
                        patch.Replace(x => x.FlightNumber, model.FlightNumber);
                        patch.Replace(x => x.HandlerId, model.HandlerId);
                        patch.Replace(x => x.Id, model.Id);
                        patch.Replace(x => x.LandDate, model.LandDate);
                        patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
                        patch.Replace(x => x.TakeoffDate, model.TakeoffDate);
                        return patch;
                }

                private async Task<ApiAirTransportRequestModel> PatchModel(int id, JsonPatchDocument<ApiAirTransportRequestModel> patch)
                {
                        var record = await this.AirTransportService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiAirTransportRequestModel request = this.AirTransportModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>379ff0683ec3bdb9eb8aa36f09c0df5c</Hash>
</Codenesium>*/