using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>0cfd0eb9a8947ef4b5451e8b3cbbf384</Hash>
</Codenesium>*/