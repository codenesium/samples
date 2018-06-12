using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiReleaseRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiReleaseRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiReleaseRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>9ffaba293ae39985480e89e31307161c</Hash>
</Codenesium>*/