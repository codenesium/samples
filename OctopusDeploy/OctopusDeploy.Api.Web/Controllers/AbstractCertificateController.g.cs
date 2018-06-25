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
        public abstract class AbstractCertificateController : AbstractApiController
        {
                protected ICertificateService CertificateService { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractCertificateController(
                        ApiSettings settings,
                        ILogger<AbstractCertificateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICertificateService certificateService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.CertificateService = certificateService;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiCertificateResponseModel> response = await this.CertificateService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiCertificateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(string id)
                {
                        ApiCertificateResponseModel response = await this.CertificateService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiCertificateRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiCertificateResponseModel> records = new List<ApiCertificateResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiCertificateResponseModel> result = await this.CertificateService.Create(model);

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
                [ProducesResponseType(typeof(ApiCertificateResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiCertificateRequestModel model)
                {
                        CreateResponse<ApiCertificateResponseModel> result = await this.CertificateService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/Certificates/{result.Record.Id}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiCertificateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ApiCertificateRequestModel> patch)
                {
                        ApiCertificateResponseModel record = await this.CertificateService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiCertificateRequestModel model = new ApiCertificateRequestModel();
                                model.SetProperties(model.Archived,
                                                    model.Created,
                                                    model.DataVersion,
                                                    model.EnvironmentIds,
                                                    model.JSON,
                                                    model.Name,
                                                    model.NotAfter,
                                                    model.Subject,
                                                    model.TenantIds,
                                                    model.TenantTags,
                                                    model.Thumbprint);
                                patch.ApplyTo(model);
                                ActionResponse result = await this.CertificateService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiCertificateResponseModel response = await this.CertificateService.Get(id);

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
                [ProducesResponseType(typeof(ApiCertificateResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(string id, [FromBody] ApiCertificateRequestModel model)
                {
                        ActionResponse result = await this.CertificateService.Update(id, model);

                        if (result.Success)
                        {
                                ApiCertificateResponseModel response = await this.CertificateService.Get(id);

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
                        ActionResponse result = await this.CertificateService.Delete(id);

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
                [Route("byCreated/{created}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> ByCreated(DateTimeOffset created)
                {
                        List<ApiCertificateResponseModel> response = await this.CertificateService.ByCreated(created);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byDataVersion/{dataVersion}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> ByDataVersion(byte[] dataVersion)
                {
                        List<ApiCertificateResponseModel> response = await this.CertificateService.ByDataVersion(dataVersion);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byNotAfter/{notAfter}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> ByNotAfter(DateTimeOffset notAfter)
                {
                        List<ApiCertificateResponseModel> response = await this.CertificateService.ByNotAfter(notAfter);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("byThumbprint/{thumbprint}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> ByThumbprint(string thumbprint)
                {
                        List<ApiCertificateResponseModel> response = await this.CertificateService.ByThumbprint(thumbprint);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>ad131949365a06ab6ced58760e98f057</Hash>
</Codenesium>*/