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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        public abstract class AbstractSaleTicketsController: AbstractApiController
        {
                protected ISaleTicketsService SaleTicketsService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSaleTicketsController(
                        ServiceSettings settings,
                        ILogger<AbstractSaleTicketsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISaleTicketsService saleTicketsService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SaleTicketsService = saleTicketsService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSaleTicketsResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSaleTicketsResponseModel> response = await this.SaleTicketsService.All(query.Offset, query.Limit);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSaleTicketsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSaleTicketsResponseModel response = await this.SaleTicketsService.Get(id);

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
                [ProducesResponseType(typeof(ApiSaleTicketsResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSaleTicketsRequestModel model)
                {
                        CreateResponse<ApiSaleTicketsResponseModel> result = await this.SaleTicketsService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/SaleTickets/{result.Record.Id.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiSaleTicketsResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSaleTicketsRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSaleTicketsResponseModel> records = new List<ApiSaleTicketsResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSaleTicketsResponseModel> result = await this.SaleTicketsService.Create(model);

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
                [ProducesResponseType(typeof(ApiSaleTicketsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSaleTicketsRequestModel model)
                {
                        ActionResponse result = await this.SaleTicketsService.Update(id, model);

                        if (result.Success)
                        {
                                ApiSaleTicketsResponseModel response = await this.SaleTicketsService.Get(id);

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
                        ActionResponse result = await this.SaleTicketsService.Delete(id);

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
                [Route("getTicketId/{ticketId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSaleTicketsResponseModel>), 200)]
                public async virtual Task<IActionResult> GetTicketId(int ticketId)
                {
                        List<ApiSaleTicketsResponseModel> response = await this.SaleTicketsService.GetTicketId(ticketId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>2cdc7abb425234e6e53f336cb59116ea</Hash>
</Codenesium>*/