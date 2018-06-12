using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDashboardConfigurationRequestModelValidator: AbstractApiDashboardConfigurationRequestModelValidator, IApiDashboardConfigurationRequestModelValidator
        {
                public ApiDashboardConfigurationRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDashboardConfigurationRequestModel model)
                {
                        this.IncludedEnvironmentIdsRules();
                        this.IncludedProjectIdsRules();
                        this.IncludedTenantIdsRules();
                        this.IncludedTenantTagsRules();
                        this.JSONRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDashboardConfigurationRequestModel model)
                {
                        this.IncludedEnvironmentIdsRules();
                        this.IncludedProjectIdsRules();
                        this.IncludedTenantIdsRules();
                        this.IncludedTenantTagsRules();
                        this.JSONRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>9fe798a81b31f2aaf1d142ede50e769a</Hash>
</Codenesium>*/