using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiInterruptionRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiInterruptionRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiInterruptionRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>1b62c34d0e4aa13037ef2f23b7bc8b1b</Hash>
</Codenesium>*/