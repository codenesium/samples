using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiLifecycleRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLifecycleRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiLifecycleRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>48eace123fffd1d0bbfc68b43f8ab27a</Hash>
</Codenesium>*/