using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiCertificateRequestModelValidator: AbstractApiCertificateRequestModelValidator, IApiCertificateRequestModelValidator
        {
                public ApiCertificateRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCertificateRequestModel model)
                {
                        this.ArchivedRules();
                        this.CreatedRules();
                        this.DataVersionRules();
                        this.EnvironmentIdsRules();
                        this.JSONRules();
                        this.NameRules();
                        this.NotAfterRules();
                        this.SubjectRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        this.ThumbprintRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCertificateRequestModel model)
                {
                        this.ArchivedRules();
                        this.CreatedRules();
                        this.DataVersionRules();
                        this.EnvironmentIdsRules();
                        this.JSONRules();
                        this.NameRules();
                        this.NotAfterRules();
                        this.SubjectRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        this.ThumbprintRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>93f612932ee7f339763a9f8c95d75e6f</Hash>
</Codenesium>*/