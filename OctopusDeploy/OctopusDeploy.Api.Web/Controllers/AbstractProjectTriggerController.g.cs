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
        public abstract class AbstractProjectTriggerController : AbstractApiController
        {
                protected IProjectTriggerService ProjectTriggerService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProjectTriggerController(
                        ApiSettings settings,
                        ILogger<AbstractProjectTriggerController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProjectTriggerService projectTriggerService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProjectTriggerService = projectTriggerService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProjectTriggerResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProjectTriggerResponseModel> response = await this.ProjectTriggerService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProjectTriggerResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiProjectTriggerResponseModel response = await this.ProjectTriggerService.Get(id);

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
                [ProducesResponseType(typeof(ApiProjectTriggerResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProjectTriggerRequestModel model)
                {
                        CreateResponse<ApiProjectTriggerResponseModel> result = await this.ProjectTriggerService.Create(model);

                        if (result.Success)
                        {
                                return this.Created ($"{this.Settings.ExternalBaseUrl}/api/ProjectTriggers/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPost]
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiProjectTriggerResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProjectTriggerRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProjectTriggerResponseModel> records = new List<ApiProjectTriggerResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProjectTriggerResponseModel> result = await this.ProjectTriggerService.Create(model);

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
                [ProducesResponseType(typeof(ApiProjectTriggerResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiProjectTriggerRequestModel model)
                {
                        ActionResponse result = await this.ProjectTriggerService.Update(id, model);

                        if (result.Success)
                        {
                                ApiProjectTriggerResponseModel response = await this.ProjectTriggerService.Get(id);

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
                        ActionResponse result = await this.ProjectTriggerService.Delete(id);

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
                [Route("getProjectIdName/{projectId}/{name}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProjectTriggerResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetProjectIdName(string projectId, string name)
                {
                        ApiProjectTriggerResponseModel response = await this.ProjectTriggerService.GetProjectIdName(projectId, name);

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
                [Route("getProjectId/{projectId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProjectTriggerResponseModel>), 200)]
                public async virtual Task<IActionResult> GetProjectId(string projectId)
                {
                        List<ApiProjectTriggerResponseModel> response = await this.ProjectTriggerService.GetProjectId(projectId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>3c2683f19abddb7cae1e54990a82265f</Hash>
</Codenesium>*/