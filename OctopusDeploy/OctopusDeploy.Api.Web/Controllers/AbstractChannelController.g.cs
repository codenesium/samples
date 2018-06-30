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
        public abstract class AbstractChannelController : AbstractApiController
        {
                protected IChannelService ChannelService { get; private set; }

                protected IApiChannelModelMapper ChannelModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractChannelController(
                        ApiSettings settings,
                        ILogger<AbstractChannelController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IChannelService channelService,
                        IApiChannelModelMapper channelModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ChannelService = channelService;
                        this.ChannelModelMapper = channelModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiChannelResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiChannelResponseModel> response = await this.ChannelService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiChannelResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiChannelResponseModel response = await this.ChannelService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiChannelResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiChannelRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiChannelResponseModel> records = new List<ApiChannelResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiChannelResponseModel> result = await this.ChannelService.Create(model);

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
                [ProducesResponseType(typeof(ApiChannelResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiChannelRequestModel model)
                {
                        CreateResponse<ApiChannelResponseModel> result = await this.ChannelService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Channels/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiChannelResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiChannelRequestModel> patch)
                {
                        ApiChannelResponseModel record = await this.ChannelService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiChannelRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ChannelService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiChannelResponseModel response = await this.ChannelService.Get(id);

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
                [ProducesResponseType(typeof(ApiChannelResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiChannelRequestModel model)
                {
                        ApiChannelRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ChannelService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiChannelResponseModel response = await this.ChannelService.Get(id);

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
                        ActionResponse result = await this.ChannelService.Delete(id);

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
                [Route("byNameProjectId/{name}/{projectId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiChannelResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByNameProjectId(string name, string projectId)
                {
                        ApiChannelResponseModel response = await this.ChannelService.ByNameProjectId(name, projectId);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                [HttpGet]
                [Route("byDataVersion/{dataVersion}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiChannelResponseModel>), 200)]
                public async virtual Task<IActionResult> ByDataVersion(byte[] dataVersion)
                {
                        List<ApiChannelResponseModel> response = await this.ChannelService.ByDataVersion(dataVersion);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byProjectId/{projectId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiChannelResponseModel>), 200)]
                public async virtual Task<IActionResult> ByProjectId(string projectId)
                {
                        List<ApiChannelResponseModel> response = await this.ChannelService.ByProjectId(projectId);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiChannelRequestModel> CreatePatch(ApiChannelRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiChannelRequestModel>();
                        patch.Replace(x => x.DataVersion, model.DataVersion);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.LifecycleId, model.LifecycleId);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.ProjectId, model.ProjectId);
                        patch.Replace(x => x.TenantTags, model.TenantTags);
                        return patch;
                }

                private async Task<ApiChannelRequestModel> PatchModel(string id, JsonPatchDocument<ApiChannelRequestModel> patch)
                {
                        var record = await this.ChannelService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiChannelRequestModel request = this.ChannelModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>1e7b2ef82a4a8c487846510b6f79250b</Hash>
</Codenesium>*/