using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiArtifactRequestModelValidator: AbstractApiArtifactRequestModelValidator, IApiArtifactRequestModelValidator
        {
                public ApiArtifactRequestModelValidator(IArtifactRepository artifactRepository)
                        : base(artifactRepository)
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
    <Hash>0eb5bac20a1b7aceee8145d31e2c34d2</Hash>
</Codenesium>*/