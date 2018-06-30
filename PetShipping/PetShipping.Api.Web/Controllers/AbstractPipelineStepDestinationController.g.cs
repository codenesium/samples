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
        public abstract class AbstractPipelineStepDestinationController : AbstractApiController
        {
                protected IPipelineStepDestinationService PipelineStepDestinationService { get; private set; }

                protected IApiPipelineStepDestinationModelMapper PipelineStepDestinationModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPipelineStepDestinationController(
                        ApiSettings settings,
                        ILogger<AbstractPipelineStepDestinationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepDestinationService pipelineStepDestinationService,
                        IApiPipelineStepDestinationModelMapper pipelineStepDestinationModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PipelineStepDestinationService = pipelineStepDestinationService;
                        this.PipelineStepDestinationModelMapper = pipelineStepDestinationModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPipelineStepDestinationResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPipelineStepDestinationResponseModel> response = await this.PipelineStepDestinationService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPipelineStepDestinationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPipelineStepDestinationResponseModel response = await this.PipelineStepDestinationService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiPipelineStepDestinationResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStepDestinationRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPipelineStepDestinationResponseModel> records = new List<ApiPipelineStepDestinationResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPipelineStepDestinationResponseModel> result = await this.PipelineStepDestinationService.Create(model);

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
                [ProducesResponseType(typeof(ApiPipelineStepDestinationResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStepDestinationRequestModel model)
                {
                        CreateResponse<ApiPipelineStepDestinationResponseModel> result = await this.PipelineStepDestinationService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/PipelineStepDestinations/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiPipelineStepDestinationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStepDestinationRequestModel> patch)
                {
                        ApiPipelineStepDestinationResponseModel record = await this.PipelineStepDestinationService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiPipelineStepDestinationRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.PipelineStepDestinationService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiPipelineStepDestinationResponseModel response = await this.PipelineStepDestinationService.Get(id);

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
                [ProducesResponseType(typeof(ApiPipelineStepDestinationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStepDestinationRequestModel model)
                {
                        ApiPipelineStepDestinationRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.PipelineStepDestinationService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiPipelineStepDestinationResponseModel response = await this.PipelineStepDestinationService.Get(id);

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
                        ActionResponse result = await this.PipelineStepDestinationService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiPipelineStepDestinationRequestModel> CreatePatch(ApiPipelineStepDestinationRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPipelineStepDestinationRequestModel>();
                        patch.Replace(x => x.DestinationId, model.DestinationId);
                        patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
                        return patch;
                }

                private async Task<ApiPipelineStepDestinationRequestModel> PatchModel(int id, JsonPatchDocument<ApiPipelineStepDestinationRequestModel> patch)
                {
                        var record = await this.PipelineStepDestinationService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiPipelineStepDestinationRequestModel request = this.PipelineStepDestinationModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>bd9c02a5138e981c7a3a5b102d34061f</Hash>
</Codenesium>*/