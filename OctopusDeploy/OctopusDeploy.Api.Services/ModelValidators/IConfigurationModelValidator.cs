using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiConfigurationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiConfigurationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiConfigurationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>cf059923ca3d3f1e52be1e5837467e82</Hash>
</Codenesium>*/