using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>5eb80d4d4573560c2e8e006ed2fb5237</Hash>
</Codenesium>*/