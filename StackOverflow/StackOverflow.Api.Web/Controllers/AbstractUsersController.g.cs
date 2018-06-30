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
        public abstract class AbstractUsersController : AbstractApiController
        {
                protected IUsersService UsersService { get; private set; }

                protected IApiUsersModelMapper UsersModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractUsersController(
                        ApiSettings settings,
                        ILogger<AbstractUsersController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IUsersService usersService,
                        IApiUsersModelMapper usersModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.UsersService = usersService;
                        this.UsersModelMapper = usersModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiUsersResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiUsersResponseModel> response = await this.UsersService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiUsersResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiUsersResponseModel response = await this.UsersService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiUsersResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiUsersRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiUsersResponseModel> records = new List<ApiUsersResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiUsersResponseModel> result = await this.UsersService.Create(model);

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
                [ProducesResponseType(typeof(ApiUsersResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiUsersRequestModel model)
                {
                        CreateResponse<ApiUsersResponseModel> result = await this.UsersService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Users/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiUsersResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiUsersRequestModel> patch)
                {
                        ApiUsersResponseModel record = await this.UsersService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiUsersRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.UsersService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiUsersResponseModel response = await this.UsersService.Get(id);

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
                [ProducesResponseType(typeof(ApiUsersResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiUsersRequestModel model)
                {
                        ApiUsersRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.UsersService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiUsersResponseModel response = await this.UsersService.Get(id);

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
                        ActionResponse result = await this.UsersService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                private JsonPatchDocument<ApiUsersRequestModel> CreatePatch(ApiUsersRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiUsersRequestModel>();
                        patch.Replace(x => x.AboutMe, model.AboutMe);
                        patch.Replace(x => x.AccountId, model.AccountId);
                        patch.Replace(x => x.Age, model.Age);
                        patch.Replace(x => x.CreationDate, model.CreationDate);
                        patch.Replace(x => x.DisplayName, model.DisplayName);
                        patch.Replace(x => x.DownVotes, model.DownVotes);
                        patch.Replace(x => x.EmailHash, model.EmailHash);
                        patch.Replace(x => x.LastAccessDate, model.LastAccessDate);
                        patch.Replace(x => x.Location, model.Location);
                        patch.Replace(x => x.Reputation, model.Reputation);
                        patch.Replace(x => x.UpVotes, model.UpVotes);
                        patch.Replace(x => x.Views, model.Views);
                        patch.Replace(x => x.WebsiteUrl, model.WebsiteUrl);
                        return patch;
                }

                private async Task<ApiUsersRequestModel> PatchModel(int id, JsonPatchDocument<ApiUsersRequestModel> patch)
                {
                        var record = await this.UsersService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiUsersRequestModel request = this.UsersModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>6a4228913dddf68cc194bdc9d1c3e9a3</Hash>
</Codenesium>*/