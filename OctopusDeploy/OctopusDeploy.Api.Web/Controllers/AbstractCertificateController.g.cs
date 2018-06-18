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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        public abstract class AbstractCertificateController: AbstractApiController
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
                [Route("")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiCertificateResponseModel), 200)]
                [ProducesResponseType(typeof(CreateResponse<string>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiCertificateRequestModel model)
                {
                        CreateResponse<ApiCertificateResponseModel> result = await this.CertificateService.Create(model);

                        if (result.Success)
                        {
                                this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.Id.ToString());
                                this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Certificates/{result.Record.Id.ToString()}");
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
                [Route("getCreated/{created}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> GetCreated(DateTimeOffset created)
                {
                        List<ApiCertificateResponseModel> response = await this.CertificateService.GetCreated(created);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getDataVersion/{dataVersion}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> GetDataVersion(byte[] dataVersion)
                {
                        List<ApiCertificateResponseModel> response = await this.CertificateService.GetDataVersion(dataVersion);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getNotAfter/{notAfter}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> GetNotAfter(DateTimeOffset notAfter)
                {
                        List<ApiCertificateResponseModel> response = await this.CertificateService.GetNotAfter(notAfter);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("getThumbprint/{thumbprint}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiCertificateResponseModel>), 200)]
                public async virtual Task<IActionResult> GetThumbprint(string thumbprint)
                {
                        List<ApiCertificateResponseModel> response = await this.CertificateService.GetThumbprint(thumbprint);

                        return this.Ok(response);
                }
        }
}

/*<Codenesium>
    <Hash>9cc307b3625e91a39bb79e3e6a450a79</Hash>
</Codenesium>*/