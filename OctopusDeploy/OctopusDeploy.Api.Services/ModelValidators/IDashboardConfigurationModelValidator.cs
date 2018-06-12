using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiDashboardConfigurationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDashboardConfigurationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiDashboardConfigurationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>77e2e62e13e4b71011c7c53aba186275</Hash>
</Codenesium>*/