using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
        public abstract class AbstractCountryRequirementController : AbstractApiController
        {
                protected ICountryRequirementService CountryRequirementService { get; private set; }

                protected IApiCountryRequirementModelMapper CountryRequirementModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractCountryRequirementController(
                        ApiSettings settings,
                        ILogger<AbstractCountryRequirementController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICountryRequirementService countryRequirementService,
                        IApiCountryRequirementModelMapper countryRequirementModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.CountryRequirementService = countryRequirementService;
                        this.CountryRequirementModelMapper = countryRequirementModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCountryRequirementResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiCountryRequirementResponseModel> response = await this.CountryRequirementService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCountryRequirementResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiCountryRequirementResponseModel response = await this.CountryRequirementService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiCountryRequirementResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCountryRequirementRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiCountryRequirementResponseModel> records = new List<ApiCountryRequirementResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiCountryRequirementResponseModel> result = await this.CountryRequirementService.Create(model);

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
                [ProducesResponseType(typeof(ApiCountryRequirementResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiCountryRequirementRequestModel model)
                {
                        CreateResponse<ApiCountryRequirementResponseModel> result = await this.CountryRequirementService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/CountryRequirements/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiCountryRequirementResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiCountryRequirementRequestModel> patch)
                {
                        ApiCountryRequirementResponseModel record = await this.CountryRequirementService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiCountryRequirementRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.CountryRequirementService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiCountryRequirementResponseModel response = await this.CountryRequirementService.Get(id);

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
                [ProducesResponseType(typeof(ApiCountryRequirementResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiCountryRequirementRequestModel model)
                {
                        ApiCountryRequirementRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.CountryRequirementService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiCountryRequirementResponseModel response = await this.CountryRequirementService.Get(id);

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
                        ActionResponse result = await this.CountryRequirementService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiCountryRequirementRequestModel> CreatePatch(ApiCountryRequirementRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiCountryRequirementRequestModel>();
                        patch.Replace(x => x.CountryId, model.CountryId);
                        patch.Replace(x => x.Details, model.Details);
                        return patch;
                }

                private async Task<ApiCountryRequirementRequestModel> PatchModel(int id, JsonPatchDocument<ApiCountryRequirementRequestModel> patch)
                {
                        var record = await this.CountryRequirementService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiCountryRequirementRequestModel request = this.CountryRequirementModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>9629d0e769889ebd5289e4905ae637e4</Hash>
</Codenesium>*/