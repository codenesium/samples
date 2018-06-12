using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDeploymentProcessRequestModelValidator: AbstractApiDeploymentProcessRequestModelValidator, IApiDeploymentProcessRequestModelValidator
        {
                public ApiDeploymentProcessRequestModelValidator()
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>4225b18cfecd3ea66853db2757184601</Hash>
</Codenesium>*/