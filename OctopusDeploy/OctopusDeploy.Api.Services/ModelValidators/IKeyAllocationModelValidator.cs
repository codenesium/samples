using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiKeyAllocationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiKeyAllocationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiKeyAllocationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>8fd654ea654b4c9ae802486735c14132</Hash>
</Codenesium>*/