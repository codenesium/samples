using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
        public abstract class AbstractWorkerTaskLeaseController : AbstractApiController
        {
                protected IWorkerTaskLeaseService WorkerTaskLeaseService { get; private set; }

                protected IApiWorkerTaskLeaseModelMapper WorkerTaskLeaseModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractWorkerTaskLeaseController(
                        ApiSettings settings,
                        ILogger<AbstractWorkerTaskLeaseController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkerTaskLeaseService workerTaskLeaseService,
                        IApiWorkerTaskLeaseModelMapper workerTaskLeaseModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.WorkerTaskLeaseService = workerTaskLeaseService;
                        this.WorkerTaskLeaseModelMapper = workerTaskLeaseModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiWorkerTaskLeaseResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiWorkerTaskLeaseResponseModel> response = await this.WorkerTaskLeaseService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiWorkerTaskLeaseResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiWorkerTaskLeaseResponseModel response = await this.WorkerTaskLeaseService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiWorkerTaskLeaseResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiWorkerTaskLeaseRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiWorkerTaskLeaseResponseModel> records = new List<ApiWorkerTaskLeaseResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiWorkerTaskLeaseResponseModel> result = await this.WorkerTaskLeaseService.Create(model);

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
                [ProducesResponseType(typeof(ApiWorkerTaskLeaseResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiWorkerTaskLeaseRequestModel model)
                {
                        CreateResponse<ApiWorkerTaskLeaseResponseModel> result = await this.WorkerTaskLeaseService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/WorkerTaskLeases/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiWorkerTaskLeaseResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiWorkerTaskLeaseRequestModel> patch)
                {
                        ApiWorkerTaskLeaseResponseModel record = await this.WorkerTaskLeaseService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiWorkerTaskLeaseRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.WorkerTaskLeaseService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiWorkerTaskLeaseResponseModel response = await this.WorkerTaskLeaseService.Get(id);

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
                [ProducesResponseType(typeof(ApiWorkerTaskLeaseResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiWorkerTaskLeaseRequestModel model)
                {
                        ApiWorkerTaskLeaseRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.WorkerTaskLeaseService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiWorkerTaskLeaseResponseModel response = await this.WorkerTaskLeaseService.Get(id);

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
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.WorkerTaskLeaseService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiWorkerTaskLeaseRequestModel> CreatePatch(ApiWorkerTaskLeaseRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiWorkerTaskLeaseRequestModel>();
                        patch.Replace(x => x.Exclusive, model.Exclusive);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.TaskId, model.TaskId);
                        patch.Replace(x => x.WorkerId, model.WorkerId);
                        return patch;
                }

                private async Task<ApiWorkerTaskLeaseRequestModel> PatchModel(string id, JsonPatchDocument<ApiWorkerTaskLeaseRequestModel> patch)
                {
                        var record = await this.WorkerTaskLeaseService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiWorkerTaskLeaseRequestModel request = this.WorkerTaskLeaseModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5f8b692053383e079f176fd12e610b3b</Hash>
</Codenesium>*/