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
        public abstract class AbstractArtifactController : AbstractApiController
        {
                protected IArtifactService ArtifactService { get; private set; }

                protected IApiArtifactModelMapper ArtifactModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractArtifactController(
                        ApiSettings settings,
                        ILogger<AbstractArtifactController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IArtifactService artifactService,
                        IApiArtifactModelMapper artifactModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ArtifactService = artifactService;
                        this.ArtifactModelMapper = artifactModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiArtifactResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiArtifactResponseModel> response = await this.ArtifactService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiArtifactResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiArtifactResponseModel response = await this.ArtifactService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiArtifactResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiArtifactRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiArtifactResponseModel> records = new List<ApiArtifactResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiArtifactResponseModel> result = await this.ArtifactService.Create(model);

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
                [ProducesResponseType(typeof(ApiArtifactResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiArtifactRequestModel model)
                {
                        CreateResponse<ApiArtifactResponseModel> result = await this.ArtifactService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Artifacts/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiArtifactResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiArtifactRequestModel> patch)
                {
                        ApiArtifactResponseModel record = await this.ArtifactService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiArtifactRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ArtifactService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiArtifactResponseModel response = await this.ArtifactService.Get(id);

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
                [ProducesResponseType(typeof(ApiArtifactResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiArtifactRequestModel model)
                {
                        ApiArtifactRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ArtifactService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiArtifactResponseModel response = await this.ArtifactService.Get(id);

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
                        ActionResponse result = await this.ArtifactService.Delete(id);

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
                [Route("byTenantId/{tenantId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiArtifactResponseModel>), 200)]
                public async virtual Task<IActionResult> ByTenantId(string tenantId)
                {
                        List<ApiArtifactResponseModel> response = await this.ArtifactService.ByTenantId(tenantId);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiArtifactRequestModel> CreatePatch(ApiArtifactRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiArtifactRequestModel>();
                        patch.Replace(x => x.Created, model.Created);
                        patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
                        patch.Replace(x => x.Filename, model.Filename);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.ProjectId, model.ProjectId);
                        patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
                        patch.Replace(x => x.TenantId, model.TenantId);
                        return patch;
                }

                private async Task<ApiArtifactRequestModel> PatchModel(string id, JsonPatchDocument<ApiArtifactRequestModel> patch)
                {
                        var record = await this.ArtifactService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiArtifactRequestModel request = this.ArtifactModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>9d8bcd726b439d7fe2d4e6a5a903b521</Hash>
</Codenesium>*/