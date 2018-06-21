using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>0f665e8744c0237fe57fc4f3bfcb97e1</Hash>
</Codenesium>*/