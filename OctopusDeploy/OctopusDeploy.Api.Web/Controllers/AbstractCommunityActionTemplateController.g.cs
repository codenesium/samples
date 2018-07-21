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
        public abstract class AbstractCommunityActionTemplateController : AbstractApiController
        {
                protected ICommunityActionTemplateService CommunityActionTemplateService { get; private set; }

                protected IApiCommunityActionTemplateModelMapper CommunityActionTemplateModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractCommunityActionTemplateController(
                        ApiSettings settings,
                        ILogger<AbstractCommunityActionTemplateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICommunityActionTemplateService communityActionTemplateService,
                        IApiCommunityActionTemplateModelMapper communityActionTemplateModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.CommunityActionTemplateService = communityActionTemplateService;
                        this.CommunityActionTemplateModelMapper = communityActionTemplateModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCommunityActionTemplateResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiCommunityActionTemplateResponseModel> response = await this.CommunityActionTemplateService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCommunityActionTemplateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiCommunityActionTemplateResponseModel response = await this.CommunityActionTemplateService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiCommunityActionTemplateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCommunityActionTemplateRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiCommunityActionTemplateResponseModel> records = new List<ApiCommunityActionTemplateResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiCommunityActionTemplateResponseModel> result = await this.CommunityActionTemplateService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiCommunityActionTemplateResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiCommunityActionTemplateRequestModel model)
                {
                        CreateResponse<ApiCommunityActionTemplateResponseModel> result = await this.CommunityActionTemplateService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/CommunityActionTemplates/{result.Record.Id}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiCommunityActionTemplateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiCommunityActionTemplateRequestModel> patch)
                {
                        ApiCommunityActionTemplateResponseModel record = await this.CommunityActionTemplateService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiCommunityActionTemplateRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiCommunityActionTemplateResponseModel> result = await this.CommunityActionTemplateService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiCommunityActionTemplateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiCommunityActionTemplateRequestModel model)
                {
                        ApiCommunityActionTemplateRequestModel request = await this.PatchModel(id, this.CommunityActionTemplateModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiCommunityActionTemplateResponseModel> result = await this.CommunityActionTemplateService.Update(id, request);

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
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.CommunityActionTemplateService.Delete(id);

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
                [Route("byExternalId/{externalId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCommunityActionTemplateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByExternalId(Guid externalId)
                {
                        ApiCommunityActionTemplateResponseModel response = await this.CommunityActionTemplateService.ByExternalId(externalId);

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
                [Route("byName/{name}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCommunityActionTemplateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByName(string name)
                {
                        ApiCommunityActionTemplateResponseModel response = await this.CommunityActionTemplateService.ByName(name);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                private async Task<ApiCommunityActionTemplateRequestModel> PatchModel(string id, JsonPatchDocument<ApiCommunityActionTemplateRequestModel> patch)
                {
                        var record = await this.CommunityActionTemplateService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiCommunityActionTemplateRequestModel request = this.CommunityActionTemplateModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>ff43f8742dc23c4e877edf2a4e0d9fcf</Hash>
</Codenesium>*/