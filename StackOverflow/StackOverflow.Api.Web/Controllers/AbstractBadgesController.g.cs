using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
        public abstract class AbstractBadgesController : AbstractApiController
        {
                protected IBadgesService BadgesService { get; private set; }

                protected IApiBadgesModelMapper BadgesModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractBadgesController(
                        ApiSettings settings,
                        ILogger<AbstractBadgesController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBadgesService badgesService,
                        IApiBadgesModelMapper badgesModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.BadgesService = badgesService;
                        this.BadgesModelMapper = badgesModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBadgesResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBadgesResponseModel> response = await this.BadgesService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiBadgesResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiBadgesResponseModel response = await this.BadgesService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiBadgesResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBadgesRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiBadgesResponseModel> records = new List<ApiBadgesResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiBadgesResponseModel> result = await this.BadgesService.Create(model);

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
                [ProducesResponseType(typeof(ApiBadgesResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiBadgesRequestModel model)
                {
                        CreateResponse<ApiBadgesResponseModel> result = await this.BadgesService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Badges/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiBadgesResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiBadgesRequestModel> patch)
                {
                        ApiBadgesResponseModel record = await this.BadgesService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiBadgesRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.BadgesService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiBadgesResponseModel response = await this.BadgesService.Get(id);

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
                [ProducesResponseType(typeof(ApiBadgesResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBadgesRequestModel model)
                {
                        ApiBadgesRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.BadgesService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiBadgesResponseModel response = await this.BadgesService.Get(id);

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
                        ActionResponse result = await this.BadgesService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiBadgesRequestModel> CreatePatch(ApiBadgesRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiBadgesRequestModel>();
                        patch.Replace(x => x.Date, model.Date);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.UserId, model.UserId);
                        return patch;
                }

                private async Task<ApiBadgesRequestModel> PatchModel(int id, JsonPatchDocument<ApiBadgesRequestModel> patch)
                {
                        var record = await this.BadgesService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiBadgesRequestModel request = this.BadgesModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c45b4e6b71c7819a8c7dd49c305d2ffd</Hash>
</Codenesium>*/