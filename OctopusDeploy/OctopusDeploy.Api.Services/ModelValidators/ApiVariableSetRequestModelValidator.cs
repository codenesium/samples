using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiVariableSetRequestModelValidator: AbstractApiVariableSetRequestModelValidator, IApiVariableSetRequestModelValidator
        {
                public ApiVariableSetRequestModelValidator(IVariableSetRepository variableSetRepository)
                        : base(variableSetRepository)
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
    <Hash>51a31696c289e1d639c0c059e7ad60c8</Hash>
</Codenesium>*/