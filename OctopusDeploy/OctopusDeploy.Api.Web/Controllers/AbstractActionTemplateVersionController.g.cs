using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
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
        public abstract class AbstractActionTemplateVersionController : AbstractApiController
        {
                protected IActionTemplateVersionService ActionTemplateVersionService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractActionTemplateVersionController(
                        ApiSettings settings,
                        ILogger<AbstractActionTemplateVersionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IActionTemplateVersionService actionTemplateVersionService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ActionTemplateVersionService = actionTemplateVersionService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiActionTemplateVersionResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiActionTemplateVersionResponseModel> response = await this.ActionTemplateVersionService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiActionTemplateVersionResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiActionTemplateVersionResponseModel response = await this.ActionTemplateVersionService.Get(id);

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
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiActionTemplateVersionResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiActionTemplateVersionRequestModel model)
                {
                        CreateResponse<ApiActionTemplateVersionResponseModel> result = await this.ActionTemplateVersionService.Create(model);

                        if (result.Success)
                        {
                                return this.Created ($"{this.Settings.ExternalBaseUrl}/api/ActionTemplateVersions/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPost]
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiActionTemplateVersionResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiActionTemplateVersionRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiActionTemplateVersionResponseModel> records = new List<ApiActionTemplateVersionResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiActionTemplateVersionResponseModel> result = await this.ActionTemplateVersionService.Create(model);

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

                [HttpPut]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiActionTemplateVersionResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiActionTemplateVersionRequestModel model)
                {
                        ActionResponse result = await this.ActionTemplateVersionService.Update(id, model);

                        if (result.Success)
                        {
                                ApiActionTemplateVersionResponseModel response = await this.ActionTemplateVersionService.Get(id);

                                return this.Ok(response);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpDelete]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(void), 204)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.ActionTemplateVersionService.Delete(id);

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
                [Route("getNameVersion/{name}/{version}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiActionTemplateVersionResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetNameVersion(string name, int version)
                {
                        ApiActionTemplateVersionResponseModel response = await this.ActionTemplateVersionService.GetNameVersion(name, version);

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
                [Route("getLatestActionTemplateId/{latestActionTemplateId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiActionTemplateVersionResponseModel>), 200)]
                public async virtual Task<IActionResult> GetLatestActionTemplateId(string latestActionTemplateId)
                {
                        List<ApiActionTemplateVersionResponseModel> response = await this.ActionTemplateVersionService.GetLatestActionTemplateId(latestActionTemplateId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>bc8523822fba35ee539fee5dd23627bd</Hash>
</Codenesium>*/