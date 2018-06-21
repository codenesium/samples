using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>09a811492e3e7a87695254918893f294</Hash>
</Codenesium>*/