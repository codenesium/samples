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
        public abstract class AbstractWorkOrderRoutingController : AbstractApiController
        {
                protected IWorkOrderRoutingService WorkOrderRoutingService { get; private set; }

                protected IApiWorkOrderRoutingModelMapper WorkOrderRoutingModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractWorkOrderRoutingController(
                        ApiSettings settings,
                        ILogger<AbstractWorkOrderRoutingController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkOrderRoutingService workOrderRoutingService,
                        IApiWorkOrderRoutingModelMapper workOrderRoutingModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.WorkOrderRoutingService = workOrderRoutingService;
                        this.WorkOrderRoutingModelMapper = workOrderRoutingModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiWorkOrderRoutingResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiWorkOrderRoutingResponseModel> response = await this.WorkOrderRoutingService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiWorkOrderRoutingResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiWorkOrderRoutingResponseModel response = await this.WorkOrderRoutingService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiWorkOrderRoutingResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiWorkOrderRoutingRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiWorkOrderRoutingResponseModel> records = new List<ApiWorkOrderRoutingResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiWorkOrderRoutingResponseModel> result = await this.WorkOrderRoutingService.Create(model);

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
                [ProducesResponseType(typeof(ApiWorkOrderRoutingResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiWorkOrderRoutingRequestModel model)
                {
                        CreateResponse<ApiWorkOrderRoutingResponseModel> result = await this.WorkOrderRoutingService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/WorkOrderRoutings/{result.Record.WorkOrderID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiWorkOrderRoutingResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiWorkOrderRoutingRequestModel> patch)
                {
                        ApiWorkOrderRoutingResponseModel record = await this.WorkOrderRoutingService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiWorkOrderRoutingRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.WorkOrderRoutingService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiWorkOrderRoutingResponseModel response = await this.WorkOrderRoutingService.Get(id);

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
                [ProducesResponseType(typeof(ApiWorkOrderRoutingResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiWorkOrderRoutingRequestModel model)
                {
                        ApiWorkOrderRoutingRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.WorkOrderRoutingService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiWorkOrderRoutingResponseModel response = await this.WorkOrderRoutingService.Get(id);

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
                        ActionResponse result = await this.WorkOrderRoutingService.Delete(id);

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
                [Route("byProductID/{productID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiWorkOrderRoutingResponseModel>), 200)]
                public async virtual Task<IActionResult> ByProductID(int productID)
                {
                        List<ApiWorkOrderRoutingResponseModel> response = await this.WorkOrderRoutingService.ByProductID(productID);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiWorkOrderRoutingRequestModel> CreatePatch(ApiWorkOrderRoutingRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiWorkOrderRoutingRequestModel>();
                        patch.Replace(x => x.ActualCost, model.ActualCost);
                        patch.Replace(x => x.ActualEndDate, model.ActualEndDate);
                        patch.Replace(x => x.ActualResourceHrs, model.ActualResourceHrs);
                        patch.Replace(x => x.ActualStartDate, model.ActualStartDate);
                        patch.Replace(x => x.LocationID, model.LocationID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.OperationSequence, model.OperationSequence);
                        patch.Replace(x => x.PlannedCost, model.PlannedCost);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.ScheduledEndDate, model.ScheduledEndDate);
                        patch.Replace(x => x.ScheduledStartDate, model.ScheduledStartDate);
                        return patch;
                }

                private async Task<ApiWorkOrderRoutingRequestModel> PatchModel(int id, JsonPatchDocument<ApiWorkOrderRoutingRequestModel> patch)
                {
                        var record = await this.WorkOrderRoutingService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiWorkOrderRoutingRequestModel request = this.WorkOrderRoutingModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5cdcc2085e5a90eb4ef1944e7c06f201</Hash>
</Codenesium>*/