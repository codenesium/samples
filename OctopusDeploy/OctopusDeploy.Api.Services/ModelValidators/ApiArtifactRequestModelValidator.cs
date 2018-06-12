using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiArtifactRequestModelValidator: AbstractApiArtifactRequestModelValidator, IApiArtifactRequestModelValidator
        {
                public ApiArtifactRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiArtifactRequestModel model)
                {
                        this.CreatedRules();
                        this.EnvironmentIdRules();
                        this.FilenameRules();
                        this.JSONRules();
                        this.ProjectIdRules();
                        this.RelatedDocumentIdsRules();
                        this.TenantIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiArtifactRequestModel model)
                {
                        this.CreatedRules();
                        this.EnvironmentIdRules();
                        this.FilenameRules();
                        this.JSONRules();
                        this.ProjectIdRules();
                        this.RelatedDocumentIdsRules();
                        this.TenantIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>e87167d374243ca8b4169f8f9d763d0a</Hash>
</Codenesium>*/