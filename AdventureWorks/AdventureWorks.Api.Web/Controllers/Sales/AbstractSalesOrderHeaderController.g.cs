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
        public abstract class AbstractSalesOrderHeaderController: AbstractApiController
        {
                protected ISalesOrderHeaderService SalesOrderHeaderService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSalesOrderHeaderController(
                        ServiceSettings settings,
                        ILogger<AbstractSalesOrderHeaderController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesOrderHeaderService salesOrderHeaderService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SalesOrderHeaderService = salesOrderHeaderService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSalesOrderHeaderResponseModel> response = await this.SalesOrderHeaderService.All(query.Offset, query.Limit);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesOrderHeaderResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSalesOrderHeaderResponseModel response = await this.SalesOrderHeaderService.Get(id);

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
                [ProducesResponseType(typeof(ApiSalesOrderHeaderResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSalesOrderHeaderRequestModel model)
                {
                        CreateResponse<ApiSalesOrderHeaderResponseModel> result = await this.SalesOrderHeaderService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.SalesOrderID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/SalesOrderHeaders/{result.Record.SalesOrderID.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSalesOrderHeaderRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSalesOrderHeaderResponseModel> records = new List<ApiSalesOrderHeaderResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSalesOrderHeaderResponseModel> result = await this.SalesOrderHeaderService.Create(model);

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
                [ProducesResponseType(typeof(ApiSalesOrderHeaderResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSalesOrderHeaderRequestModel model)
                {
                        ActionResponse result = await this.SalesOrderHeaderService.Update(id, model);

                        if (result.Success)
                        {
                                ApiSalesOrderHeaderResponseModel response = await this.SalesOrderHeaderService.Get(id);

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
                        ActionResponse result = await this.SalesOrderHeaderService.Delete(id);

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
                [Route("getSalesOrderNumber/{salesOrderNumber}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSalesOrderHeaderResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetSalesOrderNumber(string salesOrderNumber)
                {
                        ApiSalesOrderHeaderResponseModel response = await this.SalesOrderHeaderService.GetSalesOrderNumber(salesOrderNumber);

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
                [Route("getCustomerID/{customerID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
                public async virtual Task<IActionResult> GetCustomerID(int customerID)
                {
                        List<ApiSalesOrderHeaderResponseModel> response = await this.SalesOrderHeaderService.GetCustomerID(customerID);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getSalesPersonID/{salesPersonID}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSalesOrderHeaderResponseModel>), 200)]
                public async virtual Task<IActionResult> GetSalesPersonID(Nullable<int> salesPersonID)
                {
                        List<ApiSalesOrderHeaderResponseModel> response = await this.SalesOrderHeaderService.GetSalesPersonID(salesPersonID);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>580ca362527f8083ec899b27bd28d2cb</Hash>
</Codenesium>*/