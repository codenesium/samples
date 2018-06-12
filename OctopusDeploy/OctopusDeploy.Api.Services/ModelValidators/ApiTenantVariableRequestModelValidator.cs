using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiTenantVariableRequestModelValidator: AbstractApiTenantVariableRequestModelValidator, IApiTenantVariableRequestModelValidator
        {
                public ApiTenantVariableRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTenantVariableRequestModel model)
                {
                        this.EnvironmentIdRules();
                        this.JSONRules();
                        this.OwnerIdRules();
                        this.RelatedDocumentIdRules();
                        this.TenantIdRules();
                        this.VariableTemplateIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantVariableRequestModel model)
                {
                        this.EnvironmentIdRules();
                        this.JSONRules();
                        this.OwnerIdRules();
                        this.RelatedDocumentIdRules();
                        this.TenantIdRules();
                        this.VariableTemplateIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>c925b0bd4362fcb2e571b8bc71a5fcef</Hash>
</Codenesium>*/