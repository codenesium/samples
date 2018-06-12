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
        public abstract class AbstractProjectGroupController: AbstractApiController
        {
                protected IProjectGroupService ProjectGroupService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProjectGroupController(
                        ServiceSettings settings,
                        ILogger<AbstractProjectGroupController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProjectGroupService projectGroupService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProjectGroupService = projectGroupService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProjectGroupResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProjectGroupResponseModel> response = await this.ProjectGroupService.All(query.Offset, query.Limit);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProjectGroupResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiProjectGroupResponseModel response = await this.ProjectGroupService.Get(id);

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
                [ProducesResponseType(typeof(ApiProjectGroupResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProjectGroupRequestModel model)
                {
                        CreateResponse<ApiProjectGroupResponseModel> result = await this.ProjectGroupService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/ProjectGroups/{result.Record.Id.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiProjectGroupResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProjectGroupRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProjectGroupResponseModel> records = new List<ApiProjectGroupResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProjectGroupResponseModel> result = await this.ProjectGroupService.Create(model);

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
                [ProducesResponseType(typeof(ApiProjectGroupResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiProjectGroupRequestModel model)
                {
                        ActionResponse result = await this.ProjectGroupService.Update(id, model);

                        if (result.Success)
                        {
                                ApiProjectGroupResponseModel response = await this.ProjectGroupService.Get(id);

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
                        ActionResponse result = await this.ProjectGroupService.Delete(id);

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
                [Route("getName/{name}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProjectGroupResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetName(string name)
                {
                        ApiProjectGroupResponseModel response = await this.ProjectGroupService.GetName(name);

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
                [Route("getDataVersion/{dataVersion}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProjectGroupResponseModel>), 200)]
                public async virtual Task<IActionResult> GetDataVersion(byte[] dataVersion)
                {
                        List<ApiProjectGroupResponseModel> response = await this.ProjectGroupService.GetDataVersion(dataVersion);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>9d0f3c66d5a96a9dffb07c5aa7c79c38</Hash>
</Codenesium>*/