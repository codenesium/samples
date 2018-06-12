using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        public abstract class AbstractActionTemplateVersionController: AbstractApiController
        {
                protected IActionTemplateVersionService ActionTemplateVersionService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractActionTemplateVersionController(
                        ServiceSettings settings,
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
                        List<ApiActionTemplateVersionResponseModel> response = await this.ActionTemplateVersionService.All(query.Offset, query.Limit);

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
                [ProducesResponseType(typeof(ApiActionTemplateVersionResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiActionTemplateVersionRequestModel model)
                {
                        CreateResponse<ApiActionTemplateVersionResponseModel> result = await this.ActionTemplateVersionService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/ActionTemplateVersions/{result.Record.Id.ToString()}");
                                return this.Ok(result.Record);
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
    <Hash>81322e6686a4954bb6099ba29f8033e6</Hash>
</Codenesium>*/