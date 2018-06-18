using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        public abstract class AbstractEmployeeController: AbstractApiController
        {
                protected IEmployeeService EmployeeService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractEmployeeController(
                        ApiSettings settings,
                        ILogger<AbstractEmployeeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmployeeService employeeService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.EmployeeService = employeeService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmployeeResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEmployeeResponseModel> response = await this.EmployeeService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEmployeeResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiEmployeeResponseModel response = await this.EmployeeService.Get(id);

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
                [ProducesResponseType(typeof(ApiEmployeeResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiEmployeeRequestModel model)
                {
                        CreateResponse<ApiEmployeeResponseModel> result = await this.EmployeeService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Employees/{result.Record.BusinessEntityID.ToString()}");
                                return this.Ok(result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPost]
                [Route("BulkInsert")]
                [UnitOfWork]
                [ProducesResponseType(typeof(List<ApiEmployeeResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEmployeeRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiEmployeeResponseModel> records = new List<ApiEmployeeResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiEmployeeResponseModel> result = await this.EmployeeService.Create(model);

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
                [ProducesResponseType(typeof(ApiEmployeeResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEmployeeRequestModel model)
                {
                        ActionResponse result = await this.EmployeeService.Update(id, model);

                        if (result.Success)
                        {
                                ApiEmployeeResponseModel response = await this.EmployeeService.Get(id);

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
                        ActionResponse result = await this.EmployeeService.Delete(id);

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
                [Route("byLoginID/{loginID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEmployeeResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByLoginID(string loginID)
                {
                        ApiEmployeeResponseModel response = await this.EmployeeService.ByLoginID(loginID);

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
                [Route("byNationalIDNumber/{nationalIDNumber}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiEmployeeResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByNationalIDNumber(string nationalIDNumber)
                {
                        ApiEmployeeResponseModel response = await this.EmployeeService.ByNationalIDNumber(nationalIDNumber);

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
                [Route("{businessEntityID}/EmployeeDepartmentHistories")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmployeeResponseModel>), 200)]
                public async virtual Task<IActionResult> EmployeeDepartmentHistories(int businessEntityID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.EmployeeService.EmployeeDepartmentHistories(businessEntityID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{businessEntityID}/EmployeePayHistories")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmployeeResponseModel>), 200)]
                public async virtual Task<IActionResult> EmployeePayHistories(int businessEntityID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiEmployeePayHistoryResponseModel> response = await this.EmployeeService.EmployeePayHistories(businessEntityID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
                [HttpGet]
                [Route("{businessEntityID}/JobCandidates")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiEmployeeResponseModel>), 200)]
                public async virtual Task<IActionResult> JobCandidates(int businessEntityID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiJobCandidateResponseModel> response = await this.EmployeeService.JobCandidates(businessEntityID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>193213cab089cd8a7c09eecf16094b07</Hash>
</Codenesium>*/