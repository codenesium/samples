using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Web
{
        public abstract class AbstractPaymentTypeController : AbstractApiController
        {
                protected IPaymentTypeService PaymentTypeService { get; private set; }

                protected IApiPaymentTypeModelMapper PaymentTypeModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPaymentTypeController(
                        ApiSettings settings,
                        ILogger<AbstractPaymentTypeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPaymentTypeService paymentTypeService,
                        IApiPaymentTypeModelMapper paymentTypeModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PaymentTypeService = paymentTypeService;
                        this.PaymentTypeModelMapper = paymentTypeModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPaymentTypeResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPaymentTypeResponseModel> response = await this.PaymentTypeService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPaymentTypeResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPaymentTypeResponseModel response = await this.PaymentTypeService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiPaymentTypeResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPaymentTypeRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPaymentTypeResponseModel> records = new List<ApiPaymentTypeResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPaymentTypeResponseModel> result = await this.PaymentTypeService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiPaymentTypeResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPaymentTypeRequestModel model)
                {
                        CreateResponse<ApiPaymentTypeResponseModel> result = await this.PaymentTypeService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/PaymentTypes/{result.Record.Id}", result);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(UpdateResponse<ApiPaymentTypeResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiPaymentTypeRequestModel> patch)
                {
                        ApiPaymentTypeResponseModel record = await this.PaymentTypeService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiPaymentTypeRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiPaymentTypeResponseModel> result = await this.PaymentTypeService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiPaymentTypeResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPaymentTypeRequestModel model)
                {
                        ApiPaymentTypeRequestModel request = await this.PatchModel(id, this.PaymentTypeModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiPaymentTypeResponseModel> result = await this.PaymentTypeService.Update(id, request);

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
                        ActionResponse result = await this.PaymentTypeService.Delete(id);

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
                [Route("{paymentTypeId}/Sales")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPaymentTypeResponseModel>), 200)]
                public async virtual Task<IActionResult> Sales(int paymentTypeId, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSaleResponseModel> response = await this.PaymentTypeService.Sales(paymentTypeId, query.Limit, query.Offset);

                        return this.Ok(response);
                }

                private async Task<ApiPaymentTypeRequestModel> PatchModel(int id, JsonPatchDocument<ApiPaymentTypeRequestModel> patch)
                {
                        var record = await this.PaymentTypeService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiPaymentTypeRequestModel request = this.PaymentTypeModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>078bab16fbd2d2b31d774c3d71d0cbdb</Hash>
</Codenesium>*/