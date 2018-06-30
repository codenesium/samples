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
        public abstract class AbstractExtensionConfigurationController : AbstractApiController
        {
                protected IExtensionConfigurationService ExtensionConfigurationService { get; private set; }

                protected IApiExtensionConfigurationModelMapper ExtensionConfigurationModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractExtensionConfigurationController(
                        ApiSettings settings,
                        ILogger<AbstractExtensionConfigurationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IExtensionConfigurationService extensionConfigurationService,
                        IApiExtensionConfigurationModelMapper extensionConfigurationModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ExtensionConfigurationService = extensionConfigurationService;
                        this.ExtensionConfigurationModelMapper = extensionConfigurationModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiExtensionConfigurationResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiExtensionConfigurationResponseModel> response = await this.ExtensionConfigurationService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiExtensionConfigurationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiExtensionConfigurationResponseModel response = await this.ExtensionConfigurationService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiExtensionConfigurationResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiExtensionConfigurationRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiExtensionConfigurationResponseModel> records = new List<ApiExtensionConfigurationResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiExtensionConfigurationResponseModel> result = await this.ExtensionConfigurationService.Create(model);

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
                [ProducesResponseType(typeof(ApiExtensionConfigurationResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiExtensionConfigurationRequestModel model)
                {
                        CreateResponse<ApiExtensionConfigurationResponseModel> result = await this.ExtensionConfigurationService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ExtensionConfigurations/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiExtensionConfigurationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiExtensionConfigurationRequestModel> patch)
                {
                        ApiExtensionConfigurationResponseModel record = await this.ExtensionConfigurationService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiExtensionConfigurationRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ExtensionConfigurationService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiExtensionConfigurationResponseModel response = await this.ExtensionConfigurationService.Get(id);

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
                [ProducesResponseType(typeof(ApiExtensionConfigurationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiExtensionConfigurationRequestModel model)
                {
                        ApiExtensionConfigurationRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ExtensionConfigurationService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiExtensionConfigurationResponseModel response = await this.ExtensionConfigurationService.Get(id);

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
                        ActionResponse result = await this.ExtensionConfigurationService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiExtensionConfigurationRequestModel> CreatePatch(ApiExtensionConfigurationRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiExtensionConfigurationRequestModel>();
                        patch.Replace(x => x.ExtensionAuthor, model.ExtensionAuthor);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }

                private async Task<ApiExtensionConfigurationRequestModel> PatchModel(string id, JsonPatchDocument<ApiExtensionConfigurationRequestModel> patch)
                {
                        var record = await this.ExtensionConfigurationService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiExtensionConfigurationRequestModel request = this.ExtensionConfigurationModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f53576a9de345e3fd2183cd73c8e721e</Hash>
</Codenesium>*/