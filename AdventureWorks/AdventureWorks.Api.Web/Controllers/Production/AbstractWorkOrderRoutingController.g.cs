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

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractWorkOrderRoutingController(
                        ApiSettings settings,
                        ILogger<AbstractWorkOrderRoutingController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkOrderRoutingService workOrderRoutingService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.WorkOrderRoutingService = workOrderRoutingService;
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
                                ApiWorkOrderRoutingRequestModel model = new ApiWorkOrderRoutingRequestModel();
                                model.SetProperties(model.ActualCost,
                                                    model.ActualEndDate,
                                                    model.ActualResourceHrs,
                                                    model.ActualStartDate,
                                                    model.LocationID,
                                                    model.ModifiedDate,
                                                    model.OperationSequence,
                                                    model.PlannedCost,
                                                    model.ProductID,
                                                    model.ScheduledEndDate,
                                                    model.ScheduledStartDate);
                                patch.ApplyTo(model);
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
        }
}

/*<Codenesium>
    <Hash>557d09fb94414241ef4b73145b0a2b35</Hash>
</Codenesium>*/