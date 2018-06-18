using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiTenantRequestModelValidator: AbstractApiTenantRequestModelValidator, IApiTenantRequestModelValidator
        {
                public ApiTenantRequestModelValidator(ITenantRepository tenantRepository)
                        : base(tenantRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTenantRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.NameRules();
                        this.ProjectIdsRules();
                        this.TenantTagsRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.NameRules();
                        this.ProjectIdsRules();
                        this.TenantTagsRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>8a64c9e96bb6c77329a3e0443c22dbd0</Hash>
</Codenesium>*/