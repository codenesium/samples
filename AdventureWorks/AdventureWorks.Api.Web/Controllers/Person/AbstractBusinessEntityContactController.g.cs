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
        public abstract class AbstractBusinessEntityContactController : AbstractApiController
        {
                protected IBusinessEntityContactService BusinessEntityContactService { get; private set; }

                protected IApiBusinessEntityContactModelMapper BusinessEntityContactModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractBusinessEntityContactController(
                        ApiSettings settings,
                        ILogger<AbstractBusinessEntityContactController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityContactService businessEntityContactService,
                        IApiBusinessEntityContactModelMapper businessEntityContactModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.BusinessEntityContactService = businessEntityContactService;
                        this.BusinessEntityContactModelMapper = businessEntityContactModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBusinessEntityContactResponseModel> response = await this.BusinessEntityContactService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiBusinessEntityContactResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiBusinessEntityContactResponseModel response = await this.BusinessEntityContactService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBusinessEntityContactRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiBusinessEntityContactResponseModel> records = new List<ApiBusinessEntityContactResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiBusinessEntityContactResponseModel> result = await this.BusinessEntityContactService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiBusinessEntityContactResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiBusinessEntityContactRequestModel model)
                {
                        CreateResponse<ApiBusinessEntityContactResponseModel> result = await this.BusinessEntityContactService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/BusinessEntityContacts/{result.Record.BusinessEntityID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiBusinessEntityContactResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiBusinessEntityContactRequestModel> patch)
                {
                        ApiBusinessEntityContactResponseModel record = await this.BusinessEntityContactService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiBusinessEntityContactRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiBusinessEntityContactResponseModel> result = await this.BusinessEntityContactService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiBusinessEntityContactResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBusinessEntityContactRequestModel model)
                {
                        ApiBusinessEntityContactRequestModel request = await this.PatchModel(id, this.BusinessEntityContactModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiBusinessEntityContactResponseModel> result = await this.BusinessEntityContactService.Update(id, request);

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
                        ActionResponse result = await this.BusinessEntityContactService.Delete(id);

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
                [Route("byContactTypeID/{contactTypeID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
                public async virtual Task<IActionResult> ByContactTypeID(int contactTypeID)
                {
                        List<ApiBusinessEntityContactResponseModel> response = await this.BusinessEntityContactService.ByContactTypeID(contactTypeID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byPersonID/{personID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBusinessEntityContactResponseModel>), 200)]
                public async virtual Task<IActionResult> ByPersonID(int personID)
                {
                        List<ApiBusinessEntityContactResponseModel> response = await this.BusinessEntityContactService.ByPersonID(personID);

                        return this.Ok(response);
                }

                private async Task<ApiBusinessEntityContactRequestModel> PatchModel(int id, JsonPatchDocument<ApiBusinessEntityContactRequestModel> patch)
                {
                        var record = await this.BusinessEntityContactService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiBusinessEntityContactRequestModel request = this.BusinessEntityContactModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5b484966264f2efa0123767d480fdb47</Hash>
</Codenesium>*/