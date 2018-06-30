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
        public abstract class AbstractNuGetPackageController : AbstractApiController
        {
                protected INuGetPackageService NuGetPackageService { get; private set; }

                protected IApiNuGetPackageModelMapper NuGetPackageModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractNuGetPackageController(
                        ApiSettings settings,
                        ILogger<AbstractNuGetPackageController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        INuGetPackageService nuGetPackageService,
                        IApiNuGetPackageModelMapper nuGetPackageModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.NuGetPackageService = nuGetPackageService;
                        this.NuGetPackageModelMapper = nuGetPackageModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiNuGetPackageResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiNuGetPackageResponseModel> response = await this.NuGetPackageService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiNuGetPackageResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiNuGetPackageResponseModel response = await this.NuGetPackageService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiNuGetPackageResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiNuGetPackageRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiNuGetPackageResponseModel> records = new List<ApiNuGetPackageResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiNuGetPackageResponseModel> result = await this.NuGetPackageService.Create(model);

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
                [ProducesResponseType(typeof(ApiNuGetPackageResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiNuGetPackageRequestModel model)
                {
                        CreateResponse<ApiNuGetPackageResponseModel> result = await this.NuGetPackageService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/NuGetPackages/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiNuGetPackageResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiNuGetPackageRequestModel> patch)
                {
                        ApiNuGetPackageResponseModel record = await this.NuGetPackageService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiNuGetPackageRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.NuGetPackageService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiNuGetPackageResponseModel response = await this.NuGetPackageService.Get(id);

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
                [ProducesResponseType(typeof(ApiNuGetPackageResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiNuGetPackageRequestModel model)
                {
                        ApiNuGetPackageRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.NuGetPackageService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiNuGetPackageResponseModel response = await this.NuGetPackageService.Get(id);

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
                        ActionResponse result = await this.NuGetPackageService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiNuGetPackageRequestModel> CreatePatch(ApiNuGetPackageRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiNuGetPackageRequestModel>();
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.PackageId, model.PackageId);
                        patch.Replace(x => x.Version, model.Version);
                        patch.Replace(x => x.VersionBuild, model.VersionBuild);
                        patch.Replace(x => x.VersionMajor, model.VersionMajor);
                        patch.Replace(x => x.VersionMinor, model.VersionMinor);
                        patch.Replace(x => x.VersionRevision, model.VersionRevision);
                        patch.Replace(x => x.VersionSpecial, model.VersionSpecial);
                        return patch;
                }

                private async Task<ApiNuGetPackageRequestModel> PatchModel(string id, JsonPatchDocument<ApiNuGetPackageRequestModel> patch)
                {
                        var record = await this.NuGetPackageService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiNuGetPackageRequestModel request = this.NuGetPackageModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>8af0a801584b6b8d1644eaad60256a9b</Hash>
</Codenesium>*/