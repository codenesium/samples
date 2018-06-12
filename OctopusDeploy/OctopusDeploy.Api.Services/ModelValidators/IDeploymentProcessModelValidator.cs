using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiDeploymentProcessRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDeploymentProcessRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentProcessRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>e4e0630a3c2b73d99921b50f45368dd0</Hash>
</Codenesium>*/