using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiDeploymentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>780aa57b0e26bdee62a213c39e0135f2</Hash>
</Codenesium>*/