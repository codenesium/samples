using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDeploymentProcessRequestModelValidator : AbstractApiDeploymentProcessRequestModelValidator, IApiDeploymentProcessRequestModelValidator
        {
                public ApiDeploymentProcessRequestModelValidator(IDeploymentProcessRepository deploymentProcessRepository)
                        : base(deploymentProcessRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentProcessRequestModel model)
                {
                        this.IsFrozenRules();
                        this.JSONRules();
                        this.OwnerIdRules();
                        this.RelatedDocumentIdsRules();
                        this.VersionRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentProcessRequestModel model)
                {
                        this.IsFrozenRules();
                        this.JSONRules();
                        this.OwnerIdRules();
                        this.RelatedDocumentIdsRules();
                        this.VersionRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>ba3858d34fe9f8b13dc17d1ecf20cf63</Hash>
</Codenesium>*/