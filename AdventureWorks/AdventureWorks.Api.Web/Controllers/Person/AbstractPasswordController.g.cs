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
        public abstract class AbstractPasswordController: AbstractApiController
        {
                protected IPasswordService PasswordService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractPasswordController(
                        ServiceSettings settings,
                        ILogger<AbstractPasswordController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPasswordService passwordService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.PasswordService = passwordService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiPasswordResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();

                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiPasswordResponseModel> response = await this.PasswordService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiPasswordResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiPasswordResponseModel response = await this.PasswordService.Get(id);

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
                [ProducesResponseType(typeof(ApiPasswordResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiPasswordRequestModel model)
                {
                        CreateResponse<ApiPasswordResponseModel> result = await this.PasswordService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Passwords/{result.Record.BusinessEntityID.ToString()}");
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
                [ProducesResponseType(typeof(List<ApiPasswordResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiPasswordRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiPasswordResponseModel> records = new List<ApiPasswordResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiPasswordResponseModel> result = await this.PasswordService.Create(model);

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
                [ProducesResponseType(typeof(ApiPasswordResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiPasswordRequestModel model)
                {
                        ActionResponse result = await this.PasswordService.Update(id, model);

                        if (result.Success)
                        {
                                ApiPasswordResponseModel response = await this.PasswordService.Get(id);

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
                        ActionResponse result = await this.PasswordService.Delete(id);

                        if (result.Success)
                        {
                                return this.NoContent();
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }
        }
}

/*<Codenesium>
    <Hash>2c8d580a9707ffeccae3373634f2019d</Hash>
</Codenesium>*/