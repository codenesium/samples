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
        public abstract class AbstractEmployeePayHistoryController : AbstractApiController
        {
                protected IEmployeePayHistoryService EmployeePayHistoryService { get; private set; }

                protected IApiEmployeePayHistoryModelMapper EmployeePayHistoryModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractEmployeePayHistoryController(
                        ApiSettings settings,
                        ILogger<AbstractEmployeePayHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmployeePayHistoryService employeePayHistoryService,
                        IApiEmployeePayHistoryModelMapper employeePayHistoryModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.EmployeePayHistoryService = employeePayHistoryService;
                        this.EmployeePayHistoryModelMapper = employeePayHistoryModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmployeePayHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEmployeePayHistoryResponseModel> response = await this.EmployeePayHistoryService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEmployeePayHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiEmployeePayHistoryResponseModel response = await this.EmployeePayHistoryService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiEmployeePayHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEmployeePayHistoryRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiEmployeePayHistoryResponseModel> records = new List<ApiEmployeePayHistoryResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiEmployeePayHistoryResponseModel> result = await this.EmployeePayHistoryService.Create(model);

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
                [ProducesResponseType(typeof(ApiEmployeePayHistoryResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiEmployeePayHistoryRequestModel model)
                {
                        CreateResponse<ApiEmployeePayHistoryResponseModel> result = await this.EmployeePayHistoryService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/EmployeePayHistories/{result.Record.BusinessEntityID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiEmployeePayHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiEmployeePayHistoryRequestModel> patch)
                {
                        ApiEmployeePayHistoryResponseModel record = await this.EmployeePayHistoryService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiEmployeePayHistoryRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.EmployeePayHistoryService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiEmployeePayHistoryResponseModel response = await this.EmployeePayHistoryService.Get(id);

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
                [ProducesResponseType(typeof(ApiEmployeePayHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEmployeePayHistoryRequestModel model)
                {
                        ApiEmployeePayHistoryRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.EmployeePayHistoryService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiEmployeePayHistoryResponseModel response = await this.EmployeePayHistoryService.Get(id);

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
                        ActionResponse result = await this.EmployeePayHistoryService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiEmployeePayHistoryRequestModel> CreatePatch(ApiEmployeePayHistoryRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiEmployeePayHistoryRequestModel>();
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.PayFrequency, model.PayFrequency);
                        patch.Replace(x => x.Rate, model.Rate);
                        patch.Replace(x => x.RateChangeDate, model.RateChangeDate);
                        return patch;
                }

                private async Task<ApiEmployeePayHistoryRequestModel> PatchModel(int id, JsonPatchDocument<ApiEmployeePayHistoryRequestModel> patch)
                {
                        var record = await this.EmployeePayHistoryService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiEmployeePayHistoryRequestModel request = this.EmployeePayHistoryModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b0ce517cdd928511703b377dd33c64e4</Hash>
</Codenesium>*/