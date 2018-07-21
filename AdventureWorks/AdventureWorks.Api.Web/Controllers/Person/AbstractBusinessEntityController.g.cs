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
        public abstract class AbstractBusinessEntityController : AbstractApiController
        {
                protected IBusinessEntityService BusinessEntityService { get; private set; }

                protected IApiBusinessEntityModelMapper BusinessEntityModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractBusinessEntityController(
                        ApiSettings settings,
                        ILogger<AbstractBusinessEntityController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityService businessEntityService,
                        IApiBusinessEntityModelMapper businessEntityModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.BusinessEntityService = businessEntityService;
                        this.BusinessEntityModelMapper = businessEntityModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBusinessEntityResponseModel> response = await this.BusinessEntityService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiBusinessEntityResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiBusinessEntityResponseModel response = await this.BusinessEntityService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiBusinessEntityResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBusinessEntityRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiBusinessEntityResponseModel> records = new List<ApiBusinessEntityResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiBusinessEntityResponseModel> result = await this.BusinessEntityService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiBusinessEntityResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiBusinessEntityRequestModel model)
                {
                        CreateResponse<ApiBusinessEntityResponseModel> result = await this.BusinessEntityService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/BusinessEntities/{result.Record.BusinessEntityID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiBusinessEntityResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiBusinessEntityRequestModel> patch)
                {
                        ApiBusinessEntityResponseModel record = await this.BusinessEntityService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiBusinessEntityRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiBusinessEntityResponseModel> result = await this.BusinessEntityService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiBusinessEntityResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBusinessEntityRequestModel model)
                {
                        ApiBusinessEntityRequestModel request = await this.PatchModel(id, this.BusinessEntityModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiBusinessEntityResponseModel> result = await this.BusinessEntityService.Update(id, request);

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
                public virtual async Task<IActionResult> Delete(int id)
                {
                        ActionResponse result = await this.BusinessEntityService.Delete(id);

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
                [Route("{businessEntityID}/BusinessEntityAddresses")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityResponseModel>), 200)]
                public async virtual Task<IActionResult> BusinessEntityAddresses(int businessEntityID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBusinessEntityAddressResponseModel> response = await this.BusinessEntityService.BusinessEntityAddresses(businessEntityID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{businessEntityID}/BusinessEntityContacts")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityResponseModel>), 200)]
                public async virtual Task<IActionResult> BusinessEntityContacts(int businessEntityID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBusinessEntityContactResponseModel> response = await this.BusinessEntityService.BusinessEntityContacts(businessEntityID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{businessEntityID}/People")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityResponseModel>), 200)]
                public async virtual Task<IActionResult> People(int businessEntityID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPersonResponseModel> response = await this.BusinessEntityService.People(businessEntityID, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private async Task<ApiBusinessEntityRequestModel> PatchModel(int id, JsonPatchDocument<ApiBusinessEntityRequestModel> patch)
                {
                        var record = await this.BusinessEntityService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiBusinessEntityRequestModel request = this.BusinessEntityModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a43490ecfba5dd2bbacf560bb62b8678</Hash>
</Codenesium>*/