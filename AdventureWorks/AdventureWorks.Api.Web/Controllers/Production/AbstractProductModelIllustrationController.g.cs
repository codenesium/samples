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
        public abstract class AbstractProductModelIllustrationController : AbstractApiController
        {
                protected IProductModelIllustrationService ProductModelIllustrationService { get; private set; }

                protected IApiProductModelIllustrationModelMapper ProductModelIllustrationModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractProductModelIllustrationController(
                        ApiSettings settings,
                        ILogger<AbstractProductModelIllustrationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductModelIllustrationService productModelIllustrationService,
                        IApiProductModelIllustrationModelMapper productModelIllustrationModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.ProductModelIllustrationService = productModelIllustrationService;
                        this.ProductModelIllustrationModelMapper = productModelIllustrationModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiProductModelIllustrationResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiProductModelIllustrationResponseModel> response = await this.ProductModelIllustrationService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiProductModelIllustrationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiProductModelIllustrationResponseModel response = await this.ProductModelIllustrationService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiProductModelIllustrationResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductModelIllustrationRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiProductModelIllustrationResponseModel> records = new List<ApiProductModelIllustrationResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiProductModelIllustrationResponseModel> result = await this.ProductModelIllustrationService.Create(model);

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
                [ProducesResponseType(typeof(ApiProductModelIllustrationResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiProductModelIllustrationRequestModel model)
                {
                        CreateResponse<ApiProductModelIllustrationResponseModel> result = await this.ProductModelIllustrationService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/ProductModelIllustrations/{result.Record.ProductModelID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiProductModelIllustrationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiProductModelIllustrationRequestModel> patch)
                {
                        ApiProductModelIllustrationResponseModel record = await this.ProductModelIllustrationService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiProductModelIllustrationRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.ProductModelIllustrationService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiProductModelIllustrationResponseModel response = await this.ProductModelIllustrationService.Get(id);

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
                [ProducesResponseType(typeof(ApiProductModelIllustrationResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductModelIllustrationRequestModel model)
                {
                        ApiProductModelIllustrationRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.ProductModelIllustrationService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiProductModelIllustrationResponseModel response = await this.ProductModelIllustrationService.Get(id);

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
                        ActionResponse result = await this.ProductModelIllustrationService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiProductModelIllustrationRequestModel> CreatePatch(ApiProductModelIllustrationRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductModelIllustrationRequestModel>();
                        patch.Replace(x => x.IllustrationID, model.IllustrationID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        return patch;
                }

                private async Task<ApiProductModelIllustrationRequestModel> PatchModel(int id, JsonPatchDocument<ApiProductModelIllustrationRequestModel> patch)
                {
                        var record = await this.ProductModelIllustrationService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiProductModelIllustrationRequestModel request = this.ProductModelIllustrationModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c241de782c42cd02b878b8c557cc5512</Hash>
</Codenesium>*/