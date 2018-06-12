using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiDeploymentHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDeploymentHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>85bc72cd5cce364a0a8af81692fb929c</Hash>
</Codenesium>*/