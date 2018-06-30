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
        public abstract class AbstractLibraryVariableSetController : AbstractApiController
        {
                protected ILibraryVariableSetService LibraryVariableSetService { get; private set; }

                protected IApiLibraryVariableSetModelMapper LibraryVariableSetModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractLibraryVariableSetController(
                        ApiSettings settings,
                        ILogger<AbstractLibraryVariableSetController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILibraryVariableSetService libraryVariableSetService,
                        IApiLibraryVariableSetModelMapper libraryVariableSetModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.LibraryVariableSetService = libraryVariableSetService;
                        this.LibraryVariableSetModelMapper = libraryVariableSetModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiLibraryVariableSetResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiLibraryVariableSetResponseModel> response = await this.LibraryVariableSetService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiLibraryVariableSetResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiLibraryVariableSetResponseModel response = await this.LibraryVariableSetService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiLibraryVariableSetResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiLibraryVariableSetRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiLibraryVariableSetResponseModel> records = new List<ApiLibraryVariableSetResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiLibraryVariableSetResponseModel> result = await this.LibraryVariableSetService.Create(model);

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
                [ProducesResponseType(typeof(ApiLibraryVariableSetResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiLibraryVariableSetRequestModel model)
                {
                        CreateResponse<ApiLibraryVariableSetResponseModel> result = await this.LibraryVariableSetService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/LibraryVariableSets/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiLibraryVariableSetResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiLibraryVariableSetRequestModel> patch)
                {
                        ApiLibraryVariableSetResponseModel record = await this.LibraryVariableSetService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiLibraryVariableSetRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.LibraryVariableSetService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiLibraryVariableSetResponseModel response = await this.LibraryVariableSetService.Get(id);

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
                [ProducesResponseType(typeof(ApiLibraryVariableSetResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiLibraryVariableSetRequestModel model)
                {
                        ApiLibraryVariableSetRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.LibraryVariableSetService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiLibraryVariableSetResponseModel response = await this.LibraryVariableSetService.Get(id);

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
                        ActionResponse result = await this.LibraryVariableSetService.Delete(id);

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
                [Route("byName/{name}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiLibraryVariableSetResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByName(string name)
                {
                        ApiLibraryVariableSetResponseModel response = await this.LibraryVariableSetService.ByName(name);

                        if (response == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                return this.Ok(response);
                        }
                }

                private JsonPatchDocument<ApiLibraryVariableSetRequestModel> CreatePatch(ApiLibraryVariableSetRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLibraryVariableSetRequestModel>();
                        patch.Replace(x => x.ContentType, model.ContentType);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.VariableSetId, model.VariableSetId);
                        return patch;
                }

                private async Task<ApiLibraryVariableSetRequestModel> PatchModel(string id, JsonPatchDocument<ApiLibraryVariableSetRequestModel> patch)
                {
                        var record = await this.LibraryVariableSetService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiLibraryVariableSetRequestModel request = this.LibraryVariableSetModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>3b320a34c2a3c918ddf1074a1e7918d5</Hash>
</Codenesium>*/