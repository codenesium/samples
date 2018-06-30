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
        public abstract class AbstractScrapReasonController : AbstractApiController
        {
                protected IScrapReasonService ScrapReasonService { get; private set; }

                protected IApiScrapReasonModelMapper ScrapReasonModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractScrapReasonController(
                        ApiSettings settings,
                        ILogger<AbstractScrapReasonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IScrapReasonService scrapReasonService,
                        IApiScrapReasonModelMapper scrapReasonModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ScrapReasonService = scrapReasonService;
                        this.ScrapReasonModelMapper = scrapReasonModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiScrapReasonResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiScrapReasonResponseModel> response = await this.ScrapReasonService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiScrapReasonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(short id)
                {
                        ApiScrapReasonResponseModel response = await this.ScrapReasonService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiScrapReasonResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiScrapReasonRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiScrapReasonResponseModel> records = new List<ApiScrapReasonResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiScrapReasonResponseModel> result = await this.ScrapReasonService.Create(model);

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
                [ProducesResponseType(typeof(ApiScrapReasonResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<short>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiScrapReasonRequestModel model)
                {
                        CreateResponse<ApiScrapReasonResponseModel> result = await this.ScrapReasonService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ScrapReasons/{result.Record.ScrapReasonID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiScrapReasonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(short id, [FromBody] JsonPatchDocument<ApiScrapReasonRequestModel> patch)
                {
                        ApiScrapReasonResponseModel record = await this.ScrapReasonService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiScrapReasonRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ScrapReasonService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiScrapReasonResponseModel response = await this.ScrapReasonService.Get(id);

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
                [ProducesResponseType(typeof(ApiScrapReasonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(short id, [FromBody] ApiScrapReasonRequestModel model)
                {
                        ApiScrapReasonRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ScrapReasonService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiScrapReasonResponseModel response = await this.ScrapReasonService.Get(id);

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
                public virtual async Task<IActionResult> Delete(short id)
                {
                        ActionResponse result = await this.ScrapReasonService.Delete(id);

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
                [ProducesResponseType(typeof(ApiScrapReasonResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByName(string name)
                {
                        ApiScrapReasonResponseModel response = await this.ScrapReasonService.ByName(name);

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
                [Route("{scrapReasonID}/WorkOrders")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiScrapReasonResponseModel>), 200)]
                public async virtual Task<IActionResult> WorkOrders(short scrapReasonID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiWorkOrderResponseModel> response = await this.ScrapReasonService.WorkOrders(scrapReasonID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiScrapReasonRequestModel> CreatePatch(ApiScrapReasonRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiScrapReasonRequestModel>();
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }

                private async Task<ApiScrapReasonRequestModel> PatchModel(short id, JsonPatchDocument<ApiScrapReasonRequestModel> patch)
                {
                        var record = await this.ScrapReasonService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiScrapReasonRequestModel request = this.ScrapReasonModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f1853513224b8c6bb5575be312dc11d8</Hash>
</Codenesium>*/