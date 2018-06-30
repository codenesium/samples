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
        public abstract class AbstractApiKeyController : AbstractApiController
        {
                protected IApiKeyService ApiKeyService { get; private set; }

                protected IApiApiKeyModelMapper ApiKeyModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractApiKeyController(
                        ApiSettings settings,
                        ILogger<AbstractApiKeyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IApiKeyService apiKeyService,
                        IApiApiKeyModelMapper apiKeyModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ApiKeyService = apiKeyService;
                        this.ApiKeyModelMapper = apiKeyModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiApiKeyResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiApiKeyResponseModel> response = await this.ApiKeyService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiApiKeyResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiApiKeyResponseModel response = await this.ApiKeyService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiApiKeyResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiApiKeyRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiApiKeyResponseModel> records = new List<ApiApiKeyResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiApiKeyResponseModel> result = await this.ApiKeyService.Create(model);

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
                [ProducesResponseType(typeof(ApiApiKeyResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiApiKeyRequestModel model)
                {
                        CreateResponse<ApiApiKeyResponseModel> result = await this.ApiKeyService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ApiKeys/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiApiKeyResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiApiKeyRequestModel> patch)
                {
                        ApiApiKeyResponseModel record = await this.ApiKeyService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiApiKeyRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ApiKeyService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiApiKeyResponseModel response = await this.ApiKeyService.Get(id);

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
                [ProducesResponseType(typeof(ApiApiKeyResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiApiKeyRequestModel model)
                {
                        ApiApiKeyRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ApiKeyService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiApiKeyResponseModel response = await this.ApiKeyService.Get(id);

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
                        ActionResponse result = await this.ApiKeyService.Delete(id);

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
                [Route("byApiKeyHashed/{apiKeyHashed}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiApiKeyResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByApiKeyHashed(string apiKeyHashed)
                {
                        ApiApiKeyResponseModel response = await this.ApiKeyService.ByApiKeyHashed(apiKeyHashed);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                private JsonPatchDocument<ApiApiKeyRequestModel> CreatePatch(ApiApiKeyRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiApiKeyRequestModel>();
                        patch.Replace(x => x.ApiKeyHashed, model.ApiKeyHashed);
                        patch.Replace(x => x.Created, model.Created);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.UserId, model.UserId);
                        return patch;
                }

                private async Task<ApiApiKeyRequestModel> PatchModel(string id, JsonPatchDocument<ApiApiKeyRequestModel> patch)
                {
                        var record = await this.ApiKeyService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiApiKeyRequestModel request = this.ApiKeyModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>977c21e18160129596c3b70bbd96f860</Hash>
</Codenesium>*/