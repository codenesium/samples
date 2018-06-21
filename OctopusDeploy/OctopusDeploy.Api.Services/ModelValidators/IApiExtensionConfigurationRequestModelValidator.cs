using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiExtensionConfigurationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiExtensionConfigurationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiExtensionConfigurationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>d99186730112df7fc13b5f05735ec9a9</Hash>
</Codenesium>*/