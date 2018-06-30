using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDeploymentEnvironmentRequestModelValidator : AbstractApiDeploymentEnvironmentRequestModelValidator, IApiDeploymentEnvironmentRequestModelValidator
        {
                public ApiDeploymentEnvironmentRequestModelValidator(IDeploymentEnvironmentRepository deploymentEnvironmentRepository)
                        : base(deploymentEnvironmentRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentEnvironmentRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.NameRules();
                        this.SortOrderRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentEnvironmentRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.NameRules();
                        this.SortOrderRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>96d00f0a290d8ff54f913724c794b45f</Hash>
</Codenesium>*/