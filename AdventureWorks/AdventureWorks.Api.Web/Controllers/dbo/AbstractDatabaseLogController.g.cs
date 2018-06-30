using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
        public abstract class AbstractDatabaseLogController : AbstractApiController
        {
                protected IDatabaseLogService DatabaseLogService { get; private set; }

                protected IApiDatabaseLogModelMapper DatabaseLogModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractDatabaseLogController(
                        ApiSettings settings,
                        ILogger<AbstractDatabaseLogController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDatabaseLogService databaseLogService,
                        IApiDatabaseLogModelMapper databaseLogModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.DatabaseLogService = databaseLogService;
                        this.DatabaseLogModelMapper = databaseLogModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiDatabaseLogResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiDatabaseLogResponseModel> response = await this.DatabaseLogService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiDatabaseLogResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiDatabaseLogResponseModel response = await this.DatabaseLogService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiDatabaseLogResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDatabaseLogRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiDatabaseLogResponseModel> records = new List<ApiDatabaseLogResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiDatabaseLogResponseModel> result = await this.DatabaseLogService.Create(model);

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
                [ProducesResponseType(typeof(ApiDatabaseLogResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiDatabaseLogRequestModel model)
                {
                        CreateResponse<ApiDatabaseLogResponseModel> result = await this.DatabaseLogService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/DatabaseLogs/{result.Record.DatabaseLogID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiDatabaseLogResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiDatabaseLogRequestModel> patch)
                {
                        ApiDatabaseLogResponseModel record = await this.DatabaseLogService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiDatabaseLogRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.DatabaseLogService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiDatabaseLogResponseModel response = await this.DatabaseLogService.Get(id);

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
                [ProducesResponseType(typeof(ApiDatabaseLogResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiDatabaseLogRequestModel model)
                {
                        ApiDatabaseLogRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.DatabaseLogService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiDatabaseLogResponseModel response = await this.DatabaseLogService.Get(id);

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
                public virtual async Task<IActionResult> Delete(int id)
                {
                        ActionResponse result = await this.DatabaseLogService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiDatabaseLogRequestModel> CreatePatch(ApiDatabaseLogRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiDatabaseLogRequestModel>();
                        patch.Replace(x => x.DatabaseUser, model.DatabaseUser);
                        patch.Replace(x => x.@Event, model.@Event);
                        patch.Replace(x => x.@Object, model.@Object);
                        patch.Replace(x => x.PostTime, model.PostTime);
                        patch.Replace(x => x.Schema, model.Schema);
                        patch.Replace(x => x.TSQL, model.TSQL);
                        patch.Replace(x => x.XmlEvent, model.XmlEvent);
                        return patch;
                }

                private async Task<ApiDatabaseLogRequestModel> PatchModel(int id, JsonPatchDocument<ApiDatabaseLogRequestModel> patch)
                {
                        var record = await this.DatabaseLogService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiDatabaseLogRequestModel request = this.DatabaseLogModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b9738acaac694dfe2c1aa821492517ed</Hash>
</Codenesium>*/