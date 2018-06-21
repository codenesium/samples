using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>0c10d1709991a4ee9988ce0b59abafe1</Hash>
</Codenesium>*/