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
        public abstract class AbstractPersonPhoneController : AbstractApiController
        {
                protected IPersonPhoneService PersonPhoneService { get; private set; }

                protected IApiPersonPhoneModelMapper PersonPhoneModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPersonPhoneController(
                        ApiSettings settings,
                        ILogger<AbstractPersonPhoneController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPersonPhoneService personPhoneService,
                        IApiPersonPhoneModelMapper personPhoneModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PersonPhoneService = personPhoneService;
                        this.PersonPhoneModelMapper = personPhoneModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPersonPhoneResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPersonPhoneResponseModel> response = await this.PersonPhoneService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPersonPhoneResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPersonPhoneResponseModel response = await this.PersonPhoneService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiPersonPhoneResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPersonPhoneRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPersonPhoneResponseModel> records = new List<ApiPersonPhoneResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPersonPhoneResponseModel> result = await this.PersonPhoneService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiPersonPhoneResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPersonPhoneRequestModel model)
                {
                        CreateResponse<ApiPersonPhoneResponseModel> result = await this.PersonPhoneService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/PersonPhones/{result.Record.BusinessEntityID}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiPersonPhoneResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPersonPhoneRequestModel> patch)
                {
                        ApiPersonPhoneResponseModel record = await this.PersonPhoneService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiPersonPhoneRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiPersonPhoneResponseModel> result = await this.PersonPhoneService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiPersonPhoneResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPersonPhoneRequestModel model)
                {
                        ApiPersonPhoneRequestModel request = await this.PatchModel(id, this.PersonPhoneModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiPersonPhoneResponseModel> result = await this.PersonPhoneService.Update(id, request);

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
                        ActionResponse result = await this.PersonPhoneService.Delete(id);

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
                [Route("byPhoneNumber/{phoneNumber}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPersonPhoneResponseModel>), 200)]
                public async virtual Task<IActionResult> ByPhoneNumber(string phoneNumber)
                {
                        List<ApiPersonPhoneResponseModel> response = await this.PersonPhoneService.ByPhoneNumber(phoneNumber);

                        return this.Ok(response);
                }

                private async Task<ApiPersonPhoneRequestModel> PatchModel(int id, JsonPatchDocument<ApiPersonPhoneRequestModel> patch)
                {
                        var record = await this.PersonPhoneService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiPersonPhoneRequestModel request = this.PersonPhoneModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>038642d996d72444f33ebe76e1789e21</Hash>
</Codenesium>*/