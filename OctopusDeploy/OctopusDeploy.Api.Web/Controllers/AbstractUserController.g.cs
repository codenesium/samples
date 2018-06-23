using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
        public abstract class AbstractUserController : AbstractApiController
        {
                protected IUserService UserService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractUserController(
                        ApiSettings settings,
                        ILogger<AbstractUserController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IUserService userService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.UserService = userService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiUserResponseModel> response = await this.UserService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiUserResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiUserResponseModel response = await this.UserService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiUserRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiUserResponseModel> records = new List<ApiUserResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiUserResponseModel> result = await this.UserService.Create(model);

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
                [ProducesResponseType(typeof(ApiUserResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiUserRequestModel model)
                {
                        CreateResponse<ApiUserResponseModel> result = await this.UserService.Create(model);

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
                [ProducesResponseType(typeof(ApiUserResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiUserRequestModel> patch)
                {
                        ApiUserResponseModel record = await this.UserService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiUserRequestModel model = new ApiUserRequestModel();
                                model.SetProperties(model.DisplayName,
                                                    model.EmailAddress,
                                                    model.ExternalId,
                                                    model.ExternalIdentifiers,
                                                    model.IdentificationToken,
                                                    model.IsActive,
                                                    model.IsService,
                                                    model.JSON,
                                                    model.Username);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.UserService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiUserResponseModel response = await this.UserService.Get(id);

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
                [ProducesResponseType(typeof(ApiUserResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiUserRequestModel model)
                {
                        ActionResponse result = await this.UserService.Update(id, model);

                        if (result.Success)
                        {
                                ApiUserResponseModel response = await this.UserService.Get(id);

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
                public virtual async Task<IActionResult> Delete(string id)
                {
                        ActionResponse result = await this.UserService.Delete(id);

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
                [Route("getUsername/{username}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiUserResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> GetUsername(string username)
                {
                        ApiUserResponseModel response = await this.UserService.GetUsername(username);

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
                [Route("getDisplayName/{displayName}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
                public async virtual Task<IActionResult> GetDisplayName(string displayName)
                {
                        List<ApiUserResponseModel> response = await this.UserService.GetDisplayName(displayName);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getEmailAddress/{emailAddress}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
                public async virtual Task<IActionResult> GetEmailAddress(string emailAddress)
                {
                        List<ApiUserResponseModel> response = await this.UserService.GetEmailAddress(emailAddress);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getExternalId/{externalId}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiUserResponseModel>), 200)]
                public async virtual Task<IActionResult> GetExternalId(string externalId)
                {
                        List<ApiUserResponseModel> response = await this.UserService.GetExternalId(externalId);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>b338160361c49b00b44f01bc3a748a28</Hash>
</Codenesium>*/