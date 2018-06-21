using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>c0e1bc98099e269d6a2e038f40d0aefd</Hash>
</Codenesium>*/