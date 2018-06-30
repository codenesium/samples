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
        public abstract class AbstractProductReviewController : AbstractApiController
        {
                protected IProductReviewService ProductReviewService { get; private set; }

                protected IApiProductReviewModelMapper ProductReviewModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProductReviewController(
                        ApiSettings settings,
                        ILogger<AbstractProductReviewController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductReviewService productReviewService,
                        IApiProductReviewModelMapper productReviewModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProductReviewService = productReviewService;
                        this.ProductReviewModelMapper = productReviewModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductReviewResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductReviewResponseModel> response = await this.ProductReviewService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProductReviewResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiProductReviewResponseModel response = await this.ProductReviewService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiProductReviewResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductReviewRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProductReviewResponseModel> records = new List<ApiProductReviewResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProductReviewResponseModel> result = await this.ProductReviewService.Create(model);

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
                [ProducesResponseType(typeof(ApiProductReviewResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProductReviewRequestModel model)
                {
                        CreateResponse<ApiProductReviewResponseModel> result = await this.ProductReviewService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductReviews/{result.Record.ProductReviewID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiProductReviewResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductReviewRequestModel> patch)
                {
                        ApiProductReviewResponseModel record = await this.ProductReviewService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiProductReviewRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ProductReviewService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiProductReviewResponseModel response = await this.ProductReviewService.Get(id);

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
                [ProducesResponseType(typeof(ApiProductReviewResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductReviewRequestModel model)
                {
                        ApiProductReviewRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ProductReviewService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiProductReviewResponseModel response = await this.ProductReviewService.Get(id);

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
                        ActionResponse result = await this.ProductReviewService.Delete(id);

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
                [Route("byCommentsProductIDReviewerName/{comments}/{productID}/{reviewerName}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductReviewResponseModel>), 200)]
                public async virtual Task<IActionResult> ByCommentsProductIDReviewerName(string comments, int productID, string reviewerName)
                {
                        List<ApiProductReviewResponseModel> response = await this.ProductReviewService.ByCommentsProductIDReviewerName(comments, productID, reviewerName);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiProductReviewRequestModel> CreatePatch(ApiProductReviewRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductReviewRequestModel>();
                        patch.Replace(x => x.Comments, model.Comments);
                        patch.Replace(x => x.EmailAddress, model.EmailAddress);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.Rating, model.Rating);
                        patch.Replace(x => x.ReviewDate, model.ReviewDate);
                        patch.Replace(x => x.ReviewerName, model.ReviewerName);
                        return patch;
                }

                private async Task<ApiProductReviewRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductReviewRequestModel> patch)
                {
                        var record = await this.ProductReviewService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiProductReviewRequestModel request = this.ProductReviewModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>718382e907ed00c78946fa10320e90ec</Hash>
</Codenesium>*/