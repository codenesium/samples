using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiDeploymentEnvironmentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDeploymentEnvironmentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentEnvironmentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>bfcf7e477c615046d5104756a9996170</Hash>
</Codenesium>*/