using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiServerTaskRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiServerTaskRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiServerTaskRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>7d6dc4a264763d08d6d3d4ba0446fc1a</Hash>
</Codenesium>*/