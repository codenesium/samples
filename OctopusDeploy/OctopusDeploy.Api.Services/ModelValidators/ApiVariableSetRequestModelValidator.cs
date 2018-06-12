using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiVariableSetRequestModelValidator: AbstractApiVariableSetRequestModelValidator, IApiVariableSetRequestModelValidator
        {
                public ApiVariableSetRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiVariableSetRequestModel model)
                {
                        this.IsFrozenRules();
                        this.JSONRules();
                        this.OwnerIdRules();
                        this.RelatedDocumentIdsRules();
                        this.VersionRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiVariableSetRequestModel model)
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
    <Hash>1be5d390454032722b7134788dfdd6e2</Hash>
</Codenesium>*/