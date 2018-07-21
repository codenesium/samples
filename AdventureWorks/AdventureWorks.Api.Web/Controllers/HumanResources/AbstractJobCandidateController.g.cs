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
        public abstract class AbstractJobCandidateController : AbstractApiController
        {
                protected IJobCandidateService JobCandidateService { get; private set; }

                protected IApiJobCandidateModelMapper JobCandidateModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractJobCandidateController(
                        ApiSettings settings,
                        ILogger<AbstractJobCandidateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IJobCandidateService jobCandidateService,
                        IApiJobCandidateModelMapper jobCandidateModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.JobCandidateService = jobCandidateService;
                        this.JobCandidateModelMapper = jobCandidateModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiJobCandidateResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiJobCandidateResponseModel> response = await this.JobCandidateService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiJobCandidateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiJobCandidateResponseModel response = await this.JobCandidateService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiJobCandidateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiJobCandidateRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiJobCandidateResponseModel> records = new List<ApiJobCandidateResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiJobCandidateResponseModel> result = await this.JobCandidateService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiJobCandidateResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiJobCandidateRequestModel model)
                {
                        CreateResponse<ApiJobCandidateResponseModel> result = await this.JobCandidateService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/JobCandidates/{result.Record.JobCandidateID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiJobCandidateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiJobCandidateRequestModel> patch)
                {
                        ApiJobCandidateResponseModel record = await this.JobCandidateService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiJobCandidateRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiJobCandidateResponseModel> result = await this.JobCandidateService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiJobCandidateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiJobCandidateRequestModel model)
                {
                        ApiJobCandidateRequestModel request = await this.PatchModel(id, this.JobCandidateModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiJobCandidateResponseModel> result = await this.JobCandidateService.Update(id, request);

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
                        ActionResponse result = await this.JobCandidateService.Delete(id);

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
                [Route("byBusinessEntityID/{businessEntityID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiJobCandidateResponseModel>), 200)]
                public async virtual Task<IActionResult> ByBusinessEntityID(int? businessEntityID)
                {
                        List<ApiJobCandidateResponseModel> response = await this.JobCandidateService.ByBusinessEntityID(businessEntityID);

                        return this.Ok(response);
                }

                private async Task<ApiJobCandidateRequestModel> PatchModel(int id, JsonPatchDocument<ApiJobCandidateRequestModel> patch)
                {
                        var record = await this.JobCandidateService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiJobCandidateRequestModel request = this.JobCandidateModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>fb1af12e4614d704f793b7940713ff73</Hash>
</Codenesium>*/