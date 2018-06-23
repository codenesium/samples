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
        public abstract class AbstractSpecialOfferController : AbstractApiController
        {
                protected ISpecialOfferService SpecialOfferService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractSpecialOfferController(
                        ApiSettings settings,
                        ILogger<AbstractSpecialOfferController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpecialOfferService specialOfferService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.SpecialOfferService = specialOfferService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSpecialOfferResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSpecialOfferResponseModel> response = await this.SpecialOfferService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiSpecialOfferResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiSpecialOfferResponseModel response = await this.SpecialOfferService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiSpecialOfferResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiSpecialOfferRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiSpecialOfferResponseModel> records = new List<ApiSpecialOfferResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiSpecialOfferResponseModel> result = await this.SpecialOfferService.Create(model);

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
                [ProducesResponseType(typeof(ApiSpecialOfferResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiSpecialOfferRequestModel model)
                {
                        CreateResponse<ApiSpecialOfferResponseModel> result = await this.SpecialOfferService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/SpecialOffers/{result.Record.SpecialOfferID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiSpecialOfferResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiSpecialOfferRequestModel> patch)
                {
                        ApiSpecialOfferResponseModel record = await this.SpecialOfferService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiSpecialOfferRequestModel model = new ApiSpecialOfferRequestModel();
                                model.SetProperties(model.Category,
                                                    model.Description,
                                                    model.DiscountPct,
                                                    model.EndDate,
                                                    model.MaxQty,
                                                    model.MinQty,
                                                    model.ModifiedDate,
                                                    model.Rowguid,
                                                    model.StartDate,
                                                    model.Type);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.SpecialOfferService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiSpecialOfferResponseModel response = await this.SpecialOfferService.Get(id);

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
                [ProducesResponseType(typeof(ApiSpecialOfferResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiSpecialOfferRequestModel model)
                {
                        ActionResponse result = await this.SpecialOfferService.Update(id, model);

                        if (result.Success)
                        {
                                ApiSpecialOfferResponseModel response = await this.SpecialOfferService.Get(id);

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
                        ActionResponse result = await this.SpecialOfferService.Delete(id);

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
                [Route("{specialOfferID}/SpecialOfferProducts")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiSpecialOfferResponseModel>), 200)]
                public async virtual Task<IActionResult> SpecialOfferProducts(int specialOfferID, int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiSpecialOfferProductResponseModel> response = await this.SpecialOfferService.SpecialOfferProducts(specialOfferID, query.Limit, query.Offset);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>0deb7aca3947e4a3fef57651749d47a5</Hash>
</Codenesium>*/