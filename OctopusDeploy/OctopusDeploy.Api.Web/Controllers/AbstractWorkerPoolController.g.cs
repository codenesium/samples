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
        public abstract class AbstractWorkerPoolController : AbstractApiController
        {
                protected IWorkerPoolService WorkerPoolService { get; private set; }

                protected IApiWorkerPoolModelMapper WorkerPoolModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractWorkerPoolController(
                        ApiSettings settings,
                        ILogger<AbstractWorkerPoolController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkerPoolService workerPoolService,
                        IApiWorkerPoolModelMapper workerPoolModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.WorkerPoolService = workerPoolService;
                        this.WorkerPoolModelMapper = workerPoolModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiWorkerPoolResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiWorkerPoolResponseModel> response = await this.WorkerPoolService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiWorkerPoolResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiWorkerPoolResponseModel response = await this.WorkerPoolService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiWorkerPoolResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiWorkerPoolRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiWorkerPoolResponseModel> records = new List<ApiWorkerPoolResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiWorkerPoolResponseModel> result = await this.WorkerPoolService.Create(model);

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
                [ProducesResponseType(typeof(ApiWorkerPoolResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiWorkerPoolRequestModel model)
                {
                        CreateResponse<ApiWorkerPoolResponseModel> result = await this.WorkerPoolService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/WorkerPools/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiWorkerPoolResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiWorkerPoolRequestModel> patch)
                {
                        ApiWorkerPoolResponseModel record = await this.WorkerPoolService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiWorkerPoolRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.WorkerPoolService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiWorkerPoolResponseModel response = await this.WorkerPoolService.Get(id);

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
                [ProducesResponseType(typeof(ApiWorkerPoolResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiWorkerPoolRequestModel model)
                {
                        ApiWorkerPoolRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.WorkerPoolService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiWorkerPoolResponseModel response = await this.WorkerPoolService.Get(id);

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
                        ActionResponse result = await this.WorkerPoolService.Delete(id);

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
                [ProducesResponseType(typeof(ApiWorkerPoolResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByName(string name)
                {
                        ApiWorkerPoolResponseModel response = await this.WorkerPoolService.ByName(name);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                private JsonPatchDocument<ApiWorkerPoolRequestModel> CreatePatch(ApiWorkerPoolRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiWorkerPoolRequestModel>();
                        patch.Replace(x => x.IsDefault, model.IsDefault);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.SortOrder, model.SortOrder);
                        return patch;
                }

                private async Task<ApiWorkerPoolRequestModel> PatchModel(string id, JsonPatchDocument<ApiWorkerPoolRequestModel> patch)
                {
                        var record = await this.WorkerPoolService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiWorkerPoolRequestModel request = this.WorkerPoolModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>1c218010abe8762c5c2f61137162b7b5</Hash>
</Codenesium>*/