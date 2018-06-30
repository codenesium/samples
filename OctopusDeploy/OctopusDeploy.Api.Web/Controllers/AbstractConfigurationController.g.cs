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
        public abstract class AbstractConfigurationController : AbstractApiController
        {
                protected IConfigurationService ConfigurationService { get; private set; }

                protected IApiConfigurationModelMapper ConfigurationModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractConfigurationController(
                        ApiSettings settings,
                        ILogger<AbstractConfigurationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IConfigurationService configurationService,
                        IApiConfigurationModelMapper configurationModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ConfigurationService = configurationService;
                        this.ConfigurationModelMapper = configurationModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiConfigurationResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiConfigurationResponseModel> response = await this.ConfigurationService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiConfigurationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiConfigurationResponseModel response = await this.ConfigurationService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiConfigurationResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiConfigurationRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiConfigurationResponseModel> records = new List<ApiConfigurationResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiConfigurationResponseModel> result = await this.ConfigurationService.Create(model);

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
                [ProducesResponseType(typeof(ApiConfigurationResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiConfigurationRequestModel model)
                {
                        CreateResponse<ApiConfigurationResponseModel> result = await this.ConfigurationService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Configurations/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiConfigurationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiConfigurationRequestModel> patch)
                {
                        ApiConfigurationResponseModel record = await this.ConfigurationService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiConfigurationRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ConfigurationService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiConfigurationResponseModel response = await this.ConfigurationService.Get(id);

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
                [ProducesResponseType(typeof(ApiConfigurationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiConfigurationRequestModel model)
                {
                        ApiConfigurationRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ConfigurationService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiConfigurationResponseModel response = await this.ConfigurationService.Get(id);

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
                        ActionResponse result = await this.ConfigurationService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiConfigurationRequestModel> CreatePatch(ApiConfigurationRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiConfigurationRequestModel>();
                        patch.Replace(x => x.JSON, model.JSON);
                        return patch;
                }

                private async Task<ApiConfigurationRequestModel> PatchModel(string id, JsonPatchDocument<ApiConfigurationRequestModel> patch)
                {
                        var record = await this.ConfigurationService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiConfigurationRequestModel request = this.ConfigurationModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e797f1ec6109d1b323f472f82ac2be71</Hash>
</Codenesium>*/