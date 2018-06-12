using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>d8c96c257689ba3067ca108c9c964ccc</Hash>
</Codenesium>*/