using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>9f182605688aefec17401e98bf26a10e</Hash>
</Codenesium>*/