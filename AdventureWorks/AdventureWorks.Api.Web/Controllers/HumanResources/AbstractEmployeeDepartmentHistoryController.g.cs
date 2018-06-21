using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
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
        public abstract class AbstractEmployeeDepartmentHistoryController : AbstractApiController
        {
                protected IEmployeeDepartmentHistoryService EmployeeDepartmentHistoryService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractEmployeeDepartmentHistoryController(
                        ApiSettings settings,
                        ILogger<AbstractEmployeeDepartmentHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmployeeDepartmentHistoryService employeeDepartmentHistoryService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.EmployeeDepartmentHistoryService = employeeDepartmentHistoryService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.EmployeeDepartmentHistoryService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEmployeeDepartmentHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiEmployeeDepartmentHistoryResponseModel response = await this.EmployeeDepartmentHistoryService.Get(id);

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
                [ProducesResponseType(typeof(ApiEmployeeDepartmentHistoryResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiEmployeeDepartmentHistoryRequestModel model)
                {
                        CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.EmployeeDepartmentHistoryService.Create(model);

                        if (result.Success)
                        {
                                return this.Created ($"{this.Settings.ExternalBaseUrl}/api/EmployeeDepartmentHistories/{result.Record.BusinessEntityID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPost]
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEmployeeDepartmentHistoryRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiEmployeeDepartmentHistoryResponseModel> records = new List<ApiEmployeeDepartmentHistoryResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.EmployeeDepartmentHistoryService.Create(model);

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
                [ProducesResponseType(typeof(ApiEmployeeDepartmentHistoryResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEmployeeDepartmentHistoryRequestModel model)
                {
                        ActionResponse result = await this.EmployeeDepartmentHistoryService.Update(id, model);

                        if (result.Success)
                        {
                                ApiEmployeeDepartmentHistoryResponseModel response = await this.EmployeeDepartmentHistoryService.Get(id);

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
                        ActionResponse result = await this.EmployeeDepartmentHistoryService.Delete(id);

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
                [Route("byDepartmentID/{departmentID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> ByDepartmentID(short departmentID)
                {
                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.EmployeeDepartmentHistoryService.ByDepartmentID(departmentID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byShiftID/{shiftID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmployeeDepartmentHistoryResponseModel>), 200)]
                public async virtual Task<IActionResult> ByShiftID(int shiftID)
                {
                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.EmployeeDepartmentHistoryService.ByShiftID(shiftID);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>3e41d45f7723dab5c6b5152bd3da8703</Hash>
</Codenesium>*/