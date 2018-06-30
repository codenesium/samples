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
        public abstract class AbstractPipelineStepNoteController : AbstractApiController
        {
                protected IPipelineStepNoteService PipelineStepNoteService { get; private set; }

                protected IApiPipelineStepNoteModelMapper PipelineStepNoteModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPipelineStepNoteController(
                        ApiSettings settings,
                        ILogger<AbstractPipelineStepNoteController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepNoteService pipelineStepNoteService,
                        IApiPipelineStepNoteModelMapper pipelineStepNoteModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PipelineStepNoteService = pipelineStepNoteService;
                        this.PipelineStepNoteModelMapper = pipelineStepNoteModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPipelineStepNoteResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPipelineStepNoteResponseModel> response = await this.PipelineStepNoteService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPipelineStepNoteResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPipelineStepNoteResponseModel response = await this.PipelineStepNoteService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiPipelineStepNoteResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPipelineStepNoteRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPipelineStepNoteResponseModel> records = new List<ApiPipelineStepNoteResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPipelineStepNoteResponseModel> result = await this.PipelineStepNoteService.Create(model);

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
                [ProducesResponseType(typeof(ApiPipelineStepNoteResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPipelineStepNoteRequestModel model)
                {
                        CreateResponse<ApiPipelineStepNoteResponseModel> result = await this.PipelineStepNoteService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/PipelineStepNotes/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiPipelineStepNoteResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPipelineStepNoteRequestModel> patch)
                {
                        ApiPipelineStepNoteResponseModel record = await this.PipelineStepNoteService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiPipelineStepNoteRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.PipelineStepNoteService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiPipelineStepNoteResponseModel response = await this.PipelineStepNoteService.Get(id);

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
                [ProducesResponseType(typeof(ApiPipelineStepNoteResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPipelineStepNoteRequestModel model)
                {
                        ApiPipelineStepNoteRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.PipelineStepNoteService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiPipelineStepNoteResponseModel response = await this.PipelineStepNoteService.Get(id);

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
                        ActionResponse result = await this.PipelineStepNoteService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiPipelineStepNoteRequestModel> CreatePatch(ApiPipelineStepNoteRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPipelineStepNoteRequestModel>();
                        patch.Replace(x => x.EmployeeId, model.EmployeeId);
                        patch.Replace(x => x.Note, model.Note);
                        patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
                        return patch;
                }

                private async Task<ApiPipelineStepNoteRequestModel> PatchModel(int id, JsonPatchDocument<ApiPipelineStepNoteRequestModel> patch)
                {
                        var record = await this.PipelineStepNoteService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiPipelineStepNoteRequestModel request = this.PipelineStepNoteModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>33b43ce1512d13f79bbf48c844d047d7</Hash>
</Codenesium>*/